using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace ConstAttribute
{
    public static class ConstAttributeManager<T>
    {
        #region method

        #region GetValueSuggestConst

        public static string GetValueSuggestConst(string constString)
        {
            foreach (T value in Enum.GetValues(typeof(T)))
            {
                ConstValueAttribute[] infos = GetConstValueAttributeArray(value);

                if (infos.Length > 0)
                {
                    if (infos[0].GetConstStrValue().Equals(constString))
                    {
                        return infos[0].GetTranceValue();
                    }
                }
            }

            return string.Empty;
        }

        public static string GetConstByEnumValue(Enum enumValue)
        {
            foreach (T value in Enum.GetValues(typeof(T)))
            {
                ConstValueAttribute[] infos = GetConstValueAttributeArray(value);

                if (infos.Length > 0)
                {
                    if (value.Equals(enumValue))
                    {
                        return infos[0].GetConstStrValue();
                    }
                }
            }

            return string.Empty;
        }

        public static string GetValueByEnumValue(Enum enumValue)
        {
            foreach (T value in Enum.GetValues(typeof(T)))
            {
                ConstValueAttribute[] infos = GetConstValueAttributeArray(value);

                if (infos.Length > 0)
                {
                    if (value.Equals(enumValue))
                    {
                        return infos[0].GetTranceValue();
                    }
                }
            }

            return string.Empty;
        }

        #endregion

        #region GetEnumValue

        public static T GetEnumValue(string constString)
        {
            foreach (T value in Enum.GetValues(typeof(T)))
            {
                ConstValueAttribute[] infos = GetConstValueAttributeArray(value);

                if (infos.Length > 0)
                {
                    if (constString.Equals(infos[0].GetConstStrValue()))
                    {
                        return value;
                    }
                }
            }

            return default(T);
        }

        #endregion

        #region GetEnumValuesWithKeyAndValue

        /// <summary>
        /// return a Array with key and value to the Invoker 
        /// </summary>
        /// <param name="constString"></param>
        /// <returns></returns>
        public static KeyValuePair<string, string>[] GetEnumValuesWithKeyAndValue()
        {
            var retList = new List<KeyValuePair<string, string>>();

            foreach (T value in Enum.GetValues(typeof(T)))
            {
                ConstValueAttribute[] infos = GetConstValueAttributeArray(value);

                if (infos.Length > 0)
                {
                    retList.Add(new KeyValuePair<string, string>(infos[0].GetConstStrValue(), infos[0].GetTranceValue()));
                }
            }

            return retList.ToArray();
        }

        #endregion

        #region private

        private static ConstValueAttribute[] GetConstValueAttributeArray(T value)
        {
            return (ConstValueAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(ConstValueAttribute), false);
        }

        #endregion

        #endregion
    }
}
