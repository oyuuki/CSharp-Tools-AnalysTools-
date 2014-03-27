using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Text.RegularExpressions;

using OyuLib;
using OyuLib.IO;
using OyuLib.Documents.Sources;
using OyuLib.Documents.Sources.Analysis;
using OyuLib.Documents.Sources.Analysis.InputFields;

using AnalysisVBFormApl.Interface;


namespace AnalysisVBFormApl
{
    public partial class Form3 : Form
    {
        private Hashtable _table = null;

        public Form3()
        {
            InitializeComponent();
        }

        private String[] GetFilePaths(string folderPath)
        {
            var retList = new List<String>();

            foreach (var filepath in Directory.GetFiles(folderPath))
            {
                string fileName = Path.GetFileName(filepath);

                if (fileName.StartsWith("frm") && fileName.EndsWith(".frm"))
                {
                    retList.Add(filepath);
                }
            }

            return retList.ToArray();
        }


        private Hashtable ReadSource()
        {
            string targetSourceDirectory = @"C:\Users\PASEO\Desktop\Paseo\現行ソース\";

            var table = new Hashtable();

            foreach (var path in this.GetFilePaths(targetSourceDirectory))
            {
                SourceDocumentVB6 source = new SourceDocumentVB6(path, CharSet.ShiftJis);

                AnalysisInputFieldItemManager ana = new AnalysisInputFieldItemManager(source);
                WinFrmInputField[] items = ana.GetSourceAnalysisWinFrmFields<AnalysisWinFrmFieldManagerVb6>();

                if (items == null)
                {
                    continue;
                }

                var list = new List<KeyValuePair<string, string>>();

                foreach(var item in items)
                {
                    if(item.GetExType().StartsWith("im"))
                    {
                        list.Add(new KeyValuePair<string, string>(item.GetExType(), item.SourceText));
                    }
                }

                table.Add(Path.GetFileName(path), list);
            }

            return table;
        }

        private void Anarisis()
        {
            var table =  ReadSource();
            _table = this.CheckSameValueInCodes(table);
        }

        private void GetTrancedPropertyCodeTextAlign()
        {
            var table = ReadSource();
            _table = this.GetPropertyCodeTableTextAlign(table);
        }

        private void GetTrancedPropertyCodeImeMode()
        {
            var table = ReadSource();
            _table = this.GetPropertyCodeTableImeMode(table);
        }

        private void GetTrancedPropertyCode()
        {
            var table =  ReadSource();
            _table = this.GetPropertyCodeTable(table);
        }

        private void GetTrancedFontPropertyCode()
        {
            var table = ReadSource();
            _table = this.GetFontPropertyCodeTable(table);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.exListBox1.Items.Clear();

            this.Anarisis();

            foreach(string key in this._table.Keys)
            {
                var dic = (Dictionary<string, string>)this._table[key];
                this.exListBox1.Items.Add("    TYPE：" + key);

                foreach(var dicKey in dic.Keys)
                {
                    this.exListBox1.Items.Add(dicKey + "：" + dic[dicKey]);
                }
            }
        }

        private void ShowData()
        {
            foreach (string key in this._table.Keys)
            {
                var dic = (Dictionary<string, string>)this._table[key];
                this.exListBox1.Items.Add("    TYPE：" + key);

                foreach (var dicKey in dic.Keys)
                {
                    this.exListBox1.Items.Add(dicKey + "：" + dic[dicKey]);
                }
            }
        }


        private Hashtable CheckSameValueInCodes(Hashtable table)
        {
            var dictable = new Hashtable();

            foreach(string key in table.Keys)
            {
                var keyValueList = (List<KeyValuePair<string, string>>)table[key];

                foreach (KeyValuePair<string, string> keyValue in keyValueList)
                {
                    var typeName = keyValue.Key;
                    var sourceText = keyValue.Value;

                    var dic = new Dictionary<string, string>();

                    if(dictable.ContainsKey(typeName))
                    {
                        dic = (Dictionary<string, string>)dictable[typeName];
                    }
                    else
                    {
                        dictable.Add(typeName, dic);
                    }


                    SourceDocumentVB6 source = new SourceDocumentVB6(sourceText, true, true);


                    foreach(var code in source.GetCodes())
                    {
                        var codeString = code.CodeString;

                        if(codeString.IndexOf("Begin") >= 0
                            || codeString.IndexOf("End") >= 0
                            || codeString.Trim().StartsWith("'")
                            || string.IsNullOrEmpty(codeString.Trim()))
                        {
                            continue;
                        }

                        var strArray = codeString.Split(new string[] { "=" }, StringSplitOptions.None);

                        if(strArray == null ||
                            strArray.Length <= 1)
                        {
                            continue;
                        }

                        var propertyName = strArray[0].Trim();
                        var propertyValue = strArray[1].Trim();

                        if(dic.ContainsKey(propertyName))
                        {
                            if(!dic[propertyName].Equals(propertyValue))
                            {
                                if (propertyName.IndexOf("FirstMonth") >= 0)
                                {
                                    int a = 1;
                                }

                                string value = dic[propertyName].Replace("違う値が存在する：", string.Empty);

                                bool isFindSameValue = false;


                                foreach(var str in  new StringSpilitter(value).GetSpilitStringNoChilds("ふぁふぁふぁあふぁふぁふぁふぁふぁっふぁふぁっふぁふぁｆ", new ManagerStringNested("[", "]")))
                                {
                                    if(str.Equals(propertyValue))
                                    {
                                        isFindSameValue = true;
                                        break;
                                    }
                                }

                                if (!isFindSameValue)
                                {
                                    dic[propertyName] = "違う値が存在する：" + value + "[" + propertyValue + "] ";
                                }
                            }
                        }
                        else
                        {
                            dic.Add(propertyName, propertyValue);
                        }
                    }
                }
            }

            return dictable;
        }

        private Hashtable GetPropertyCodeTable(Hashtable table)
        {
            var dictable = new Hashtable();

            foreach (string key in table.Keys)
            {
                
                var keyValueList = (List<KeyValuePair<string, string>>)table[key];
                var list = new List<List<string>>();

                

                foreach (KeyValuePair<string, string> keyValue in keyValueList)
                {
                    string indexValue = string.Empty;
                    var typeName = keyValue.Key;
                    var sourceText = keyValue.Value;

                    SourceDocumentVB6 source = new SourceDocumentVB6(sourceText, true, true);

                    int beginCount = 0;
                    var valiableName = string.Empty;
                    var loclist = new List<string>();

                    var appearanceString = string.Empty;
                    var borderStyleString = string.Empty;

                    foreach (var code in source.GetCodes())
                    {
                        var codeString = code.CodeString;

                        if (codeString.IndexOf("Begin ") >= 0
                            || codeString.IndexOf("BeginProperty") >=0)
                        {   
                            beginCount++;

                            if(beginCount == 1)
                            {
                                valiableName = new StringSpilitter(codeString).GetStringRangeSpilit(" ")[2].GetStringSpilited().Trim();
                            }

                            continue;
                        }

                        if (codeString.IndexOf(" End") >= 0)
                        {
                            beginCount--;
                            continue;
                        }

                        if (beginCount == 2)
                        {
                            continue;
                        }

                        if (beginCount == 0)
                        {
                            break;
                        }

                        if (codeString.Trim().StartsWith("'")
                            || string.IsNullOrEmpty(codeString.Trim()))
                        {
                            continue;
                        }

                        var strArray = codeString.Split(new string[] { "=" }, StringSplitOptions.None);

                        if (strArray == null ||
                            strArray.Length <= 1)
                        {
                            continue;
                        }

                        var propertyName = strArray[0].Trim();
                        var propertyValue = strArray[1].Trim();

                        if (propertyValue.IndexOf("'") >= 0)
                        {
                            propertyValue = propertyValue.Substring(0, propertyValue.IndexOf("'")).Trim();
                        }

                        if(propertyName.Equals("Index"))
                        {
                            indexValue = propertyValue;
                        }

                        string[] addCodes = null;

                        if(propertyName.Equals("Appearance"))
                        {
                            appearanceString = propertyValue;
                        }
                        else if(propertyName.Equals("BorderStyle"))
                        {
                            borderStyleString = propertyValue;
                        }


                        if (!string.IsNullOrEmpty(appearanceString)
                            && !string.IsNullOrEmpty(borderStyleString))
                        {
                            var addValue = string.Empty;

                            if (appearanceString.Equals("0") &&
                                borderStyleString.Equals("0"))
                            {
                                 addValue = ".BorderStyle = BorderStyle.None";
                            }
                            else if (appearanceString.Equals("0") &&
                                borderStyleString.Equals("1"))
                            {
                                addValue = ".BorderStyle = BorderStyle.FixedSingle";
                            }
                            else if (appearanceString.Equals("1") &&
                                borderStyleString.Equals("0"))
                            {
                                addValue = ".BorderStyle = BorderStyle.None";
                            }
                            else if (appearanceString.Equals("1") &&
                                borderStyleString.Equals("1"))
                            {
                                addValue = ".BorderStyle = BorderStyle.Fixed3D";
                            }

                            loclist.Add(addValue);
                            appearanceString = string.Empty;
                            borderStyleString = string.Empty;
                            continue;
                        }

                        var trancedValueString = this.GetChangeCodeMap(valiableName, propertyName.Trim(), propertyValue.Trim(), typeName, out addCodes);

                        if(!string.IsNullOrEmpty(trancedValueString))
                        {
                            loclist.Add(trancedValueString);

                            if(addCodes != null)
                            {
                                foreach(var str in addCodes)
                                {
                                    loclist.Add(str);
                                }

                            }
                        }
                    }

                    for (int index = 0; index < loclist.Count; index++)
                    {
                        var valiableNameAndIndex = valiableName;

                        if(!string.IsNullOrEmpty(indexValue))
                        {
                            valiableNameAndIndex = "_" + valiableNameAndIndex + "_" + indexValue;
                        }

                        loclist[index] = "         Me." + valiableNameAndIndex + loclist[index];
                    }

                    list.Add(loclist);
                }

                var retList = new List<string>();

                foreach (var aalist in list)
                {
                    retList.AddRange(aalist.ToArray());
                }


                    dictable.Add(key, retList);
            }

            return dictable;
        }


        private Hashtable GetPropertyCodeTableTextAlign(Hashtable table)
        {
            var dictable = new Hashtable();

            foreach (string key in table.Keys)
            {

                var keyValueList = (List<KeyValuePair<string, string>>)table[key];
                var list = new List<List<string>>();

                foreach (KeyValuePair<string, string> keyValue in keyValueList)
                {
                    string indexValue = string.Empty;
                    var typeName = keyValue.Key;
                    var sourceText = keyValue.Value;

                    SourceDocumentVB6 source = new SourceDocumentVB6(sourceText, true, true);

                    int beginCount = 0;
                    var valiableName = string.Empty;
                    var loclist = new List<string>();

                    var alignVertical = string.Empty;
                    var alignHorizontal = string.Empty;

                    foreach (var code in source.GetCodes())
                    {
                        var codeString = code.CodeString;

                        if (codeString.IndexOf("Begin ") >= 0
                            || codeString.IndexOf("BeginProperty") >= 0)
                        {
                            beginCount++;

                            if (beginCount == 1)
                            {
                                valiableName = new StringSpilitter(codeString).GetStringRangeSpilit(" ")[2].GetStringSpilited().Trim();
                            }

                            continue;
                        }

                        if (codeString.IndexOf(" End") >= 0)
                        {
                            beginCount--;
                            continue;
                        }

                        if (beginCount == 2)
                        {
                            continue;
                        }

                        if (beginCount == 0)
                        {
                            break;
                        }

                        if (codeString.Trim().StartsWith("'")
                            || string.IsNullOrEmpty(codeString.Trim()))
                        {
                            continue;
                        }

                        var strArray = codeString.Split(new string[] { "=" }, StringSplitOptions.None);

                        if (strArray == null ||
                            strArray.Length <= 1)
                        {
                            continue;
                        }

                        var propertyName = strArray[0].Trim();
                        var propertyValue = strArray[1].Trim();

                        if (propertyValue.IndexOf("'") >= 0)
                        {
                            propertyValue = propertyValue.Substring(0, propertyValue.IndexOf("'")).Trim();
                        }

                        if (propertyName.Equals("Index"))
                        {
                            indexValue = propertyValue;
                        }

                        string[] addCodes = null;

                        if (propertyName.Equals("AlignVertical"))
                        {
                            alignVertical = propertyValue;
                        }
                        else if (propertyName.Equals("AlignHorizontal"))
                        {
                            alignHorizontal = propertyValue;
                        }


                        if (!string.IsNullOrEmpty(alignVertical)
                            && !string.IsNullOrEmpty(alignHorizontal))
                        {
                            var addValue = this.GetTextAlignTable(typeName)[int.Parse(alignVertical)][int.Parse(alignHorizontal)];

                            loclist.Add(addValue);
                            alignVertical = string.Empty;
                            alignHorizontal = string.Empty;
                            continue;
                        }
                    }

                    for (int index = 0; index < loclist.Count; index++)
                    {
                        var valiableNameAndIndex = valiableName;

                        if (!string.IsNullOrEmpty(indexValue))
                        {
                            valiableNameAndIndex = "_" + valiableNameAndIndex + "_" + indexValue;
                        }

                        loclist[index] = "         Me." + valiableNameAndIndex + loclist[index];
                    }

                    list.Add(loclist);
                }

                var retList = new List<string>();

                foreach (var aalist in list)
                {
                    retList.AddRange(aalist.ToArray());
                }


                dictable.Add(key, retList);
            }

            return dictable;
        }

        private string[][] GetTextAlignTable(string typeName)
        {
            var retList = new List<string[]>(); 
            var propName = string.Empty;
            propName = ".ContentAlignment";
            

            retList.Add(new string[]{ 
                propName + " = System.Drawing.ContentAlignment.TopLeft",                
                propName + " = System.Drawing.ContentAlignment.TopRight",
                propName + " = System.Drawing.ContentAlignment.TopCenter"
            });

            retList.Add(new string[]{ 
                propName + " = System.Drawing.ContentAlignment.BottomLeft",
                propName + " = System.Drawing.ContentAlignment.BottomRight",
                propName + " = System.Drawing.ContentAlignment.BottomCenter"
            });

            retList.Add(new string[]{ 
                propName + " = System.Drawing.ContentAlignment.MiddleLeft",
                propName + " = System.Drawing.ContentAlignment.MiddleRight",
                propName + " = System.Drawing.ContentAlignment.MiddleCenter"
            });

            return retList.ToArray();
        }


        private Hashtable GetPropertyCodeTableImeMode(Hashtable table)
        {
            var dictable = new Hashtable();

            foreach (string key in table.Keys)
            {

                var keyValueList = (List<KeyValuePair<string, string>>)table[key];
                var list = new List<List<string>>();

                foreach (KeyValuePair<string, string> keyValue in keyValueList)
                {
                    string indexValue = string.Empty;
                    var typeName = keyValue.Key;
                    var sourceText = keyValue.Value;

                    SourceDocumentVB6 source = new SourceDocumentVB6(sourceText, true, true);

                    int beginCount = 0;
                    var valiableName = string.Empty;
                    var loclist = new List<string>();

                    var appearanceString = string.Empty;
                    var borderStyleString = string.Empty;

                    foreach (var code in source.GetCodes())
                    {
                        var codeString = code.CodeString;

                        if (codeString.IndexOf("Begin ") >= 0
                            || codeString.IndexOf("BeginProperty") >= 0)
                        {
                            beginCount++;

                            if (beginCount == 1)
                            {
                                valiableName = new StringSpilitter(codeString).GetStringRangeSpilit(" ")[2].GetStringSpilited().Trim();
                            }

                            continue;
                        }

                        if (codeString.IndexOf(" End") >= 0)
                        {
                            beginCount--;
                            continue;
                        }

                        if (beginCount == 2)
                        {
                            continue;
                        }

                        if (beginCount == 0)
                        {
                            break;
                        }

                        if (codeString.Trim().StartsWith("'")
                            || string.IsNullOrEmpty(codeString.Trim()))
                        {
                            continue;
                        }

                        var strArray = codeString.Split(new string[] { "=" }, StringSplitOptions.None);

                        if (strArray == null ||
                            strArray.Length <= 1)
                        {
                            continue;
                        }

                        var propertyName = strArray[0].Trim();
                        var propertyValue = strArray[1].Trim();

                        if (propertyValue.IndexOf("'") >= 0)
                        {
                            propertyValue = propertyValue.Substring(0, propertyValue.IndexOf("'")).Trim();
                        }

                        if (propertyName.Equals("Index"))
                        {
                            indexValue = propertyValue;
                        }

                        string[] addCodes = null;

                        var trancedValueString = this.GetChangeCodeMapImeMode(valiableName, propertyName.Trim(), propertyValue.Trim(), typeName);

                        if (!string.IsNullOrEmpty(trancedValueString))
                        {
                            loclist.Add(trancedValueString);
                        }
                    }

                    for (int index = 0; index < loclist.Count; index++)
                    {
                        var valiableNameAndIndex = valiableName;

                        if (!string.IsNullOrEmpty(indexValue))
                        {
                            valiableNameAndIndex = "_" + valiableNameAndIndex + "_" + indexValue;
                        }

                        loclist[index] = "         Me." + valiableNameAndIndex + loclist[index];
                    }

                    list.Add(loclist);
                }

                var retList = new List<string>();

                foreach (var aalist in list)
                {
                    retList.AddRange(aalist.ToArray());
                }


                dictable.Add(key, retList);
            }

            return dictable;
        }

        private Hashtable GetFontPropertyCodeTable(Hashtable table)
        {
            var dictable = new Hashtable();

            foreach (string key in table.Keys)
            {

                var keyValueList = (List<KeyValuePair<string, string>>)table[key];
                var list = new List<List<string>>();



                foreach (KeyValuePair<string, string> keyValue in keyValueList)
                {
                    string indexValue = string.Empty;
                    var typeName = keyValue.Key;
                    var sourceText = keyValue.Value;

                    SourceDocumentVB6 source = new SourceDocumentVB6(sourceText, true, true);

                    bool fontFlg = false;
                    var valiableName = string.Empty;
                    var fontName = string.Empty;
                    var fontSize = string.Empty;

                    var loclist = new List<string>();

                    foreach (var code in source.GetCodes())
                    {
                        var codeString = code.CodeString;

                        if (codeString.IndexOf("Begin ") >= 0)
                        {
                            valiableName = new StringSpilitter(codeString).GetStringRangeSpilit(" ")[2].GetStringSpilited().Trim();
                            continue;
                        }

                        if (codeString.IndexOf("BeginProperty") >= 0)
                        {
                            fontFlg = true;
                            continue;
                        }

                        var strArray = codeString.Split(new string[] { "=" }, StringSplitOptions.None);

                        if (strArray == null ||
                            strArray.Length <= 1)
                        {
                            continue;
                        }

                        var propertyName = strArray[0].Trim();
                        var propertyValue = strArray[1].Trim();

                        if (propertyValue.IndexOf("'") >= 0)
                        {
                            propertyValue = propertyValue.Substring(0, propertyValue.IndexOf("'")).Trim();
                        }

                        if (propertyName.Equals("Index"))
                        {
                            indexValue = propertyValue;
                        }


                        if (fontFlg)
                        {
                            strArray = codeString.Split(new string[] { "=" }, StringSplitOptions.None);

                            if (strArray == null ||
                                strArray.Length <= 1)
                            {
                                continue;
                            }

                            propertyName = strArray[0].Trim();
                            propertyValue = strArray[1].Trim();

                            if (propertyValue.IndexOf("'") >= 0)
                            {
                                propertyValue = propertyValue.Substring(0, propertyValue.IndexOf("'")).Trim();
                            }

                            if (propertyName.Equals("Name"))
                            {
                                fontName = propertyValue;
                            }
                            else if (propertyName.Equals("Size"))
                            {
                                fontSize = propertyValue;
                            }

                            if (!string.IsNullOrEmpty(fontName) && !string.IsNullOrEmpty(fontSize))
                            {
                                var valiableNameAndIndex = valiableName;

                                if (!string.IsNullOrEmpty(indexValue))
                                {
                                    valiableNameAndIndex = "_" + valiableNameAndIndex + "_" + indexValue;
                                }

                                loclist.Add("        Me." + valiableNameAndIndex + ".Font = New Font(" + fontName + ", " + fontSize + ")");
                                break;
                            }

                        }
                    }

                    list.Add(loclist);
                }

                var retList = new List<string>();

                foreach (var aalist in list)
                {
                    retList.AddRange(aalist.ToArray());
                }


                dictable.Add(key, retList);
            }

            return dictable;
        }

        private string GetChangeCodeMapImeMode(string valiableName, string propertyName, string value, string typeName)
        {
            var list = new List<KeyValuePair<string, string>>();

            list.Add(new KeyValuePair<string, string>("IMEMode", ".ImeMode = {0}"));
            list.Add(new KeyValuePair<string, string>("MultiLine", ".MultiLine = {0}"));
            

            if (propertyName.Equals("LengthAsByte"))
            {
                if (value.Equals("-1"))
                {
                    return ".MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.Byte";
                }
            }

            foreach (var val in list.ToArray())
            {
                if (val.Key.Equals(propertyName))
                {
                    return string.Format(val.Value, this.GetTranceValue(propertyName, value));
                }
            }

            return string.Empty;
        }

        private string GetChangeCodeMap(string valiableName, string propertyName, string value, string typeName, out string[] addCode)
        {
            addCode = null;

            var list = new List<KeyValuePair<string, string>>();

            list.Add(new KeyValuePair<string,string>("BackColor", ".BackColor = ColorTranslator.FromWin32({0})"));
            list.Add(new KeyValuePair<string,string>("EditMode", ".EditMode = {0}"));
            list.Add(new KeyValuePair<string,string>("ForeColor", ".ForeColor = ColorTranslator.FromWin32({0})"));
            list.Add(new KeyValuePair<string,string>("ReadOnly", ".ReadOnly = {0}"));
            list.Add(new KeyValuePair<string,string>("Enabled", ".Enabled = {0}"));
            list.Add(new KeyValuePair<string,string>("Multiline", ".Multiline = {0}"));
            list.Add(new KeyValuePair<string,string>("ScrollBars", ".ScrollBars = {0}"));
            list.Add(new KeyValuePair<string,string>("AllowSpace", ".AllowSpace = {0}"));
            list.Add(new KeyValuePair<string,string>("MaxLength", ".MaxLength = {0}"));
            list.Add(new KeyValuePair<string,string>("LengthAsByte", ".MaxLengthUnit = {0}"));
            list.Add(new KeyValuePair<string,string>("HighlightText", ".HighlightText = {0}"));
            list.Add(new KeyValuePair<string, string>("IMEMode", ".ImeMode = {0}"));
            list.Add(new KeyValuePair<string,string>("ScrollBarMode", ".ScrollBarMode = {0}"));
            list.Add(new KeyValuePair<string, string>("DisplayFormat", ".SetDisplayFieldsAddRange({0})"));
            list.Add(new KeyValuePair<string,string>("MaxValue", ".MaxValue = {0}"));
            list.Add(new KeyValuePair<string,string>("MinValue", ".MinValue = {0}"));
            list.Add(new KeyValuePair<string,string>("ReadOnly", ".ReadOnly = {0}"));

            if (propertyName.Equals("AllowSpace"))
            {
                if (value.Equals("-1"))
                {
                    return string.Empty;
                }
            }

            if (propertyName.Equals("LengthAsByte"))
            {
                if (value.Equals("-1"))
                {
                    return ".MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.Byte";
                }
            }

            if (typeName.IndexOf("imNumber") >= 0
                && (propertyName.Equals("Format")
                || propertyName.Equals("DisplayFormat")))
            {
                string formatString = string.Empty;
                string nullDisplayStriung = string.Empty;


                if (value.IndexOf(";;") >= 0)
                {
                    var ranges = new StringSpilitter(value).GetStringRangeSpilit(";;");
                    formatString = ranges[0].GetStringSpilited();
                    nullDisplayStriung = ranges[1].GetStringSpilited();
                }
                else
                {
                    formatString = value;
                }

                formatString = formatString.Replace("\"", string.Empty);

                string retString = string.Empty;

                if (propertyName.Equals("Format"))
                {
                    retString = string.Format(".Fields.SetFields(\"{0},,,-,\")", formatString);
                }
                else
                {
                    retString = string.Format(".DisplayFields.AddRange(\"{0},,,-,\")", formatString);
                }

                if(!string.IsNullOrEmpty(nullDisplayStriung))
                {
                    addCode = new string[] { 
                        string.Format(".AlternateText.DisplayNull.Text = \"{0}\"", nullDisplayStriung.Replace("\"", string.Empty)),
                        string.Format(".AlternateText.Null.Text = \"{0}\"", nullDisplayStriung.Replace("\"", string.Empty))};
                }

                return retString;
            }


            if (propertyName.Equals("Format"))
            {
                if (typeName.IndexOf("imDate") >= 0)
                {
                    return string.Format(".SetFieldsAddRange({0})", value.Replace("m", "M"));
                }
                else
                {
                    return string.Format(".Format = {0}", value);
                }
            }

            foreach(var val in list.ToArray())
            {
                if(val.Key.Equals(propertyName))
                {
                    return string.Format(val.Value, this.GetTranceValue(propertyName, value));
                }
            }

            return string.Empty;
        }

        private string GetTranceValue(string propertyName, string value)
        {
            Dictionary<string, KeyValuePair<string, string>[]> dic = new Dictionary<string,KeyValuePair<string, string>[]>();

            dic.Add("EditMode", GetTranceValueCollectionEditMode());
            dic.Add("Enabled", GetTranceValueCollectionEnabled());
            dic.Add("HighlightText", GetTranceValueCollectionHighlightText());
            dic.Add("ReadOnly", GetTranceValueCollectionReadOnly());
            dic.Add("ScrollBars", GetTranceValueCollectionScrollBars());
            dic.Add("AllowSpace", GetTranceValueCollectionAllowSpace());
            dic.Add("LengthAsByte", GetTranceValueCollectionMaxLengthUnit());
            dic.Add("ScrollBarMode", GetTranceValueCollectionScrollBarMode());
            dic.Add("Multiline", GetTranceValueCollectionEnabled());
            dic.Add("IMEMode", GetTranceValueCollectionImemode());
            

            if (propertyName.Equals("Format")
                || propertyName.Equals("DisplayFormat"))
            {
                return value.Replace("m", "M");
            }

            if(!dic.ContainsKey(propertyName))
            {
                return value;
            }

            foreach (var val in dic[propertyName].ToArray())
            {
                if (val.Key.Equals(value.Trim()))
                {
                    return val.Value;
                }
            }

            return value;
        }

        private KeyValuePair<string, string>[] GetTranceValueCollectionEditMode()
        {
            var list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("0", "GrapeCity.Win.Editors.EditMode.Insert"));
            list.Add(new KeyValuePair<string, string>("1", "GrapeCity.Win.Editors.EditMode.Overwrite"));
            list.Add(new KeyValuePair<string, string>("2", "GrapeCity.Win.Editors.EditMode.FixedInsert"));
            list.Add(new KeyValuePair<string, string>("3", "GrapeCity.Win.Editors.EditMode.FixedOverwrite"));
            return list.ToArray();
        }

        private KeyValuePair<string, string>[] GetTranceValueCollectionEnabled()
        {
            var list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("-1", "True"));
            list.Add(new KeyValuePair<string, string>("0", "False"));
            return list.ToArray();
        }

        private KeyValuePair<string, string>[] GetTranceValueCollectionHighlightText()
        {
            var list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("0", "GrapeCity.Win.Editors.HighlightText.None"));
            list.Add(new KeyValuePair<string, string>("1", "GrapeCity.Win.Editors.HighlightText.Field"));
            list.Add(new KeyValuePair<string, string>("2", "GrapeCity.Win.Editors.HighlightText.All"));
            return list.ToArray();
        }

        private KeyValuePair<string, string>[] GetTranceValueCollectionReadOnly()
        {
            var list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("-1", "True"));
            list.Add(new KeyValuePair<string, string>("0", "False"));
            return list.ToArray();
        }

        private KeyValuePair<string, string>[] GetTranceValueCollectionScrollBars()
        {
            var list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("0", "ScrollBars.None"));
            list.Add(new KeyValuePair<string, string>("1", "ScrollBars.Horizontal"));
            list.Add(new KeyValuePair<string, string>("2", "ScrollBars.Vertical"));
            list.Add(new KeyValuePair<string, string>("3", "ScrollBars.Both"));
            
            return list.ToArray();
        }

        private KeyValuePair<string, string>[] GetTranceValueCollectionAllowSpace()
        {
            var list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("0", "GrapeCity.Win.Editors.AllowSpace.None"));
            list.Add(new KeyValuePair<string, string>("1", "GrapeCity.Win.Editors.AllowSpace.Narrow"));
            list.Add(new KeyValuePair<string, string>("2", "GrapeCity.Win.Editors.AllowSpace.Wide"));
            list.Add(new KeyValuePair<string, string>("3", "GrapeCity.Win.Editors.AllowSpace.Both"));
            return list.ToArray();
        }

        private KeyValuePair<string, string>[] GetTranceValueCollectionMaxLengthUnit()
        {
            var list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("0", "GrapeCity.Win.Editors.LengthUnit.Char"));
            list.Add(new KeyValuePair<string, string>("1", "GrapeCity.Win.Editors.LengthUnit.Byte"));
            list.Add(new KeyValuePair<string, string>("2", "GrapeCity.Win.Editors.LengthUnit.TextElement"));
            return list.ToArray();
        }

        private KeyValuePair<string, string>[] GetTranceValueCollectionScrollBarMode()
        {
            var list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("0", "GrapeCity.Win.Editors.ScrollBarMode.Fixed"));
            list.Add(new KeyValuePair<string, string>("1", "GrapeCity.Win.Editors.ScrollBarMode.Automatic"));
            return list.ToArray();
        }

        private KeyValuePair<string, string>[] GetTranceValueCollectionImemode()
        {
            var list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("2", "Windows.Forms.ImeMode.Off"));
            list.Add(new KeyValuePair<string, string>("1", "Windows.Forms.ImeMode.On"));
            list.Add(new KeyValuePair<string, string>("0", "Windows.Forms.ImeMode.NoControl"));
            list.Add(new KeyValuePair<string, string>("3", "Windows.Forms.ImeMode.Disable"));
            list.Add(new KeyValuePair<string, string>("4", "Windows.Forms.ImeMode.Hiragana"));
            list.Add(new KeyValuePair<string, string>("7", "Windows.Forms.ImeMode.AlphaFull"));
            list.Add(new KeyValuePair<string, string>("-1", "Windows.Forms.ImeMode.Inherit"));
            list.Add(new KeyValuePair<string, string>("5", "Windows.Forms.ImeMode.Katakana"));
            list.Add(new KeyValuePair<string, string>("6", "Windows.Forms.ImeMode.KatakanaHalf"));
            
            return list.ToArray();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ShowData();
        }

        private void exListBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                for (int x = exListBox1.SelectedIndices.Count - 1; x >= 0; x--)
                {
                    int idx = exListBox1.SelectedIndices[x];
                    exListBox1.Items.RemoveAt(idx);
                } 
            }
        }

        private void exListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = string.Empty;

            foreach(string item in this.exListBox1.Items)
            {
                str = str + item + "\n";
            }

            Clipboard.SetText(str);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.exListBox1.Items.Clear();

            this.GetTrancedPropertyCode();

            foreach (string key in this._table.Keys)
            {
                var list = (List<string>)this._table[key];

                if(list.Count == 0)
                {
                    continue;
                }

                this.exListBox1.Items.Add("ファイル名：" + key);

                foreach (var value in list.ToArray())
                {
                    if ((value.IndexOf("Format") >= 0 || value.IndexOf("Fields") >= 0) && value.IndexOf("imn") >= 0)
                    {

                        this.exListBox1.Items.Add(value);
                    }
                }
                this.exListBox1.Items.Add("");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.exListBox1.Items.Clear();

            this.GetTrancedPropertyCode();

            foreach (string key in this._table.Keys)
            {
                var list = (List<string>)this._table[key];
                if (list.Count == 0)
                {
                    continue;
                }

                var designerPath = @"C:\Users\PASEO\Desktop\Paseo\02_ソース\次期システム\Freemarket\FreeMarket.NET\" + key.Replace(".frm", string.Empty) + ".Designer.vb";

                if(!File.Exists(designerPath))
                {
                    this.exListBox1.Items.Add("このファイルに対応する次期のソースファイルがありません。  ファイル名：" + key);
                    continue;
                }

                var mana = new AnalysisSourceDocumentManagerVBDotNet(designerPath);

                mana.AddSourceCodeInfoMethod("InitializeComponent", list.ToArray(), "Controls", "Add");
                mana.CreateAnalysisSourceFile(@"C:\Users\PASEO\Desktop\Paseo\02_ソース\次期システム\Freemarket\FreeMarket.NET\Test\" + key.Replace(".frm", string.Empty) + ".Designer.vb");

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.exListBox1.Items.Clear();

            this.GetTrancedPropertyCodeImeMode();

            foreach (string key in this._table.Keys)
            {
                var list = (List<string>)this._table[key];
                if (list.Count == 0)
                {
                    continue;
                }

                var designerPath = @"C:\Users\PASEO\Desktop\Paseo\02_ソース\次期システム\Freemarket\FreeMarket.NET\" + key.Replace(".frm", string.Empty) + ".Designer.vb";

                if (!File.Exists(designerPath))
                {
                    this.exListBox1.Items.Add("このファイルに対応する次期のソースファイルがありません。  ファイル名：" + key);
                    continue;
                }

                var mana = new AnalysisSourceDocumentManagerVBDotNet(designerPath);

                mana.AddSourceCodeInfoMethod("InitializeComponent", list.ToArray(), "Controls", "Add");
                mana.CreateAnalysisSourceFile(@"C:\Users\PASEO\Desktop\Paseo\02_ソース\次期システム\Freemarket\FreeMarket.NET\Test\" + key.Replace(".frm", string.Empty) + ".Designer.vb");

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.exListBox1.Items.Clear();

            this.GetTrancedPropertyCodeTextAlign();

            foreach (string key in this._table.Keys)
            {
                var list = (List<string>)this._table[key];
                if (list.Count == 0)
                {
                    continue;
                }

                var designerPath = @"C:\Users\PASEO\Desktop\Paseo\02_ソース\次期システム\Freemarket\FreeMarket.NET\" + key.Replace(".frm", string.Empty) + ".Designer.vb";

                if (!File.Exists(designerPath))
                {
                    this.exListBox1.Items.Add("このファイルに対応する次期のソースファイルがありません。  ファイル名：" + key);
                    continue;
                }

                var mana = new AnalysisSourceDocumentManagerVBDotNet(designerPath);

                mana.AddSourceCodeInfoMethod("InitializeComponent", list.ToArray(), "Controls", "Add");
                mana.CreateAnalysisSourceFile(@"C:\Users\PASEO\Desktop\Paseo\02_ソース\次期システム\Freemarket\FreeMarket.NET\Test\" + key.Replace(".frm", string.Empty) + ".Designer.vb");

            }
        }
    }
}
