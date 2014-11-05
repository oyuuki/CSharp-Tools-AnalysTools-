using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.IO
{
    public static class LogOut
    {
        private static DateTime dt = DateTime.Now;

        public static DateTime logDate
        {
            get{ return dt; }
            set{ dt = value; }
        }

        /// <summary>
        /// ログ出力
        /// </summary>
        /// <param name="msg">メッセージ</param>
        /// <remarks></remarks>
        public static void WriteTraceLog(String msg)
        {
            WriteTraceLog(msg, null);
        }

        /// <summary>
        /// ログ出力
        /// </summary>
        /// <param name="msg">メッセージ</param>
        /// <param name="ex">Exception(無指定の場合はメッセージのみ出力)</param>
        /// <remarks></remarks>
        private static void WriteTraceLog(String msg, Exception ex)
        {
            try
            {
                // ログフォルダ名作成

                String logFolder = System.AppDomain.CurrentDomain.BaseDirectory + "Log";

                // ログフォルダ名作成
                System.IO.Directory.CreateDirectory(logFolder);

                // ログファイル名作成
                String logFile = logFolder + "\\TraceLog" + dt.ToString("dd") + ".log";

                // 翌日分のログファイル削除(１ヶ月分のログファイルしか保存しないようにするため)
                String logNext = logFolder + "\\TraceLog" + dt.AddDays(1).ToString("dd") + ".log";
                System.IO.File.Delete(logNext);

                // ログ出力文字列作成
                String logStr;
                logStr = dt.ToString("yyyy/MM/dd HH:mm:ss") + "\t" + msg;
                if (ex != null)
                {
                    logStr = logStr + "\n" + ex.ToString();
                }

                // Shift-JISでログ出力
                System.IO.StreamWriter sw = null;
                try
                {
                    sw = new System.IO.StreamWriter(logFile, true,
                        System.Text.Encoding.GetEncoding("Shift-JIS"));
                    sw.WriteLine(logStr);
                }
                catch { }
                finally
                {
                    if (sw != null) sw.Close();
                }
            }
            catch
            {

            }
        }
    }
}

