using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace OyuLib.Windows.Forms
{
    /// <summary>
    /// Provide Utility methods for DataGridView KeyDown, keyPress, Keyup
    /// </summary>
    public static class KeyUtil
    {
        /// <summary>
        /// 引数のキーと押下されたキーが同一かどうか判定する
        /// </summary>
        /// <param name="e"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsPushThisKey(Keys key1, Keys key2, bool isControl, bool isShift, bool isAlt)
        {
            if (((key1 & Keys.Control) == Keys.Control) != isControl)
            {
                return false;
            }

            if (((key1 & Keys.Shift) == Keys.Shift) != isShift)
            {
                return false;
            }

            if (((key1 & Keys.Alt) == Keys.Alt) != isAlt)
            {
                return false;
            }

            return IsPushThisKey(key1, key2);
        }

        /// <summary>
        /// 引数のキーと押下されたキーが同一かどうか判定する
        /// </summary>
        /// <param name="e"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsPushThisKey(Keys key1, Keys key2)
        {
            return (key1 & key2) == key2;
        }

        /// <summary>
        /// 引数のキーと押下されたキーが同一かどうか判定する
        /// </summary>
        /// <param name="e"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsPushThisKey(KeyEventArgs e, Keys key, bool isControl, bool isShift, bool isAlt)
        {
            if (e.Shift != isShift)
            {
                return false;
            }

            if (e.Control != isControl)
            {
                return false;
            }

            if (e.Alt != isAlt)
            {
                return false;
            }

            return IsPushThisKey(e.KeyCode, key);
        }


        /// <summary>
        /// 引数のキーと押下されたキーが同一かどうか判定する
        /// </summary>
        /// <param name="e"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsPushEnterKey(Keys key)
        {
            return IsPushThisKey(key, Keys.Enter | Keys.Enter & Keys.ShiftKey);
        }

        /// <summary>
        /// 引数のキーと押下されたキーが同一かどうか判定する
        /// </summary>
        /// <param name="e"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsPushEnterKey(KeyEventArgs e)
        {
            return IsPushEnterKey(e.KeyCode);
        }

        /// <summary>
        /// 引数のキーと押下されたキーが同一かどうか判定する
        /// </summary>
        /// <param name="e"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsPushDialogDownKey(Keys key)
        {
            return IsPushThisKey(key, Keys.Down);
        }
    }
}
