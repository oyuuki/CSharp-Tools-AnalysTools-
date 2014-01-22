using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using OyuLib.OyuAttribute;

namespace OyuLib.OyuWindows.Compornent
{
    public partial class ExComboBox : ComboBox, IValidateInputData
    {
        #region constructor

        public ExComboBox()
        {
            InitializeComponent();
        }

        #endregion

        #region OverRide

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        #endregion

        #region Method

        public void SetItemsFromEnumValue<T>()
        {
            this.SetItemsFromEnumValue<T>(false);
        }

        public void SetItemsFromEnumValue<T>(bool isDelBlank)
        {
            this.Items.Clear();

            foreach (var value in ConstAttributeManager<T>.GetEnumValuesWithKeyAndValue())
            {
                if (isDelBlank)
                {
                    if (string.IsNullOrEmpty(value.Value))
                    {
                        continue;
                    }
                }

                this.Items.Add(new ItemValue(value));
            }

            this.SelectedIndex = 0;
        }

        public void SetSelectedIndexBykey(string key)
        {
            for (int index = 0; index < this.Items.Count; index++)
            {
                var value = (ItemValue)this.Items[index];

                if (value.Key.Equals(key))
                {
                    this.SelectedIndex = index;
                    return;
                }
            }
        }

        public bool IsSeletedItem()
        {
            return this.SelectedItem != null;

        }

        public string GetSelectedItem()
        {
            if (!this.IsSeletedItem())
            {
                return null;
            }

            return ((ItemValue) this.SelectedItem).ToString().Trim();
        }

        public string GetSelectedItemKey()
        {
            if (!this.IsSeletedItem())
            {
                return null;
            }

            return ((ItemValue)this.SelectedItem).Key;
        }

        public T GetSelectedItemEnum<T>()
        {
            string value = this.GetSelectedItemKey();

            if (string.IsNullOrEmpty(value))
            {
                return default(T);
            }

            return ConstAttributeManager<T>.GetEnumValue(this.GetSelectedItemKey());
        }

        #endregion

        #region implement an interface

        public bool IsValidValue()
        {
            return !string.IsNullOrEmpty(this.GetSelectedItem());
        }

        #endregion

        #region InnerClass

        private class ItemValue
        {
            #region instanceVal

            /// <summary>
            /// store key of item
            /// </summary>
            private string _key = string.Empty;

            /// <summary>
            /// store value of item
            /// </summary>
            private string _value = string.Empty;

            #endregion

            #region Property

            public string Key
            {
                get { return this._key; }
            }

            #endregion

            #region constructor

            public ItemValue(string key, string value)
            {
                this._key = key;
                this._value = value;
            }

            public ItemValue(KeyValuePair<string, string> val)
            {
                this._key = val.Key;
                this._value = val.Value;
            }

            public override string ToString()
            {
                return this._value;
            }

            #endregion
        }

        #endregion
    }
}
