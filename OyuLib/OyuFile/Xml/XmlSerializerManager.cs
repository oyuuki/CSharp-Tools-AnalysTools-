using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;
using System.IO;

using OyuLib.OyuFile;


namespace OyuLib.OyuFile.Xml
{
    public static class XmlSerializerManager
    {
        //XMLファイルをSampleClassオブジェクトに復元する
        public static void WriteXmlFile<T>(string fileName, T[] array)
        {
            string writreFilePath = GetFileNameExecDir(fileName);

            //XMLファイルに保存する
            System.Xml.Serialization.XmlSerializer serializer1 =
                new System.Xml.Serialization.XmlSerializer(typeof(T[]));
            System.IO.FileStream fs1 =
                new System.IO.FileStream(writreFilePath, System.IO.FileMode.Create);
            serializer1.Serialize(fs1, array);
            fs1.Close();
        }

        public static T[] ReadXmlFile<T>(string fileName)
        {
            string readFilePath = GetFileNameExecDir(fileName);

            if (!FileUtil.IsExistFileCheck(readFilePath))
            {
                return new T[] { };
            }

            //保存した内容を復元する
            System.Xml.Serialization.XmlSerializer serializer2 =
                new System.Xml.Serialization.XmlSerializer(typeof(T[]));
            System.IO.FileStream fs2 =
                new System.IO.FileStream(readFilePath, FileMode.Open);
            T[] loadAry;
            loadAry = (T[])serializer2.Deserialize(fs2);
            fs2.Close();

            return loadAry;
        }

        public static Dictionary<string, string> ReadXmlFileDictionaly(string fileName)
        {
            Dictionary<string, string> retDic = new Dictionary<string, string>();

            foreach (XmlValueTypeKeyAndValue value in ReadXmlFile<XmlValueTypeKeyAndValue>(fileName))
            {
                string KaiTrance = value.Value.Replace("\n", "\r\n");

                retDic.Add(value.Key, KaiTrance);
            }

            return retDic;
        }

        private static string GetFileNameExecDir(string fileName)
        {
            Assembly myAssembly = Assembly.GetEntryAssembly();

            return Path.Combine(Path.GetDirectoryName(myAssembly.Location), fileName + ".xml");
        }
    }
}
