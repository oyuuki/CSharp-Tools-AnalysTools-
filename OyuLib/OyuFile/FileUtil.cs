﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace OyuLib.OyuFile
{
    public static class FileUtil
    {
        #region const

        private const string ENCODING_SHIFT_JIS = "Shift_JIS";

        #endregion

        #region method

        #region gettext

        /// <summary>
        /// Get All Text From TextFile
        /// </summary>
        /// <param name="filePath"></param>
        public static string GetAllTextShiftJIS(string filePath)
        {
            return GetAllText(filePath, ENCODING_SHIFT_JIS);
        }

        /// <summary>
        /// Get All Text using encode shift_jis From TextFile 
        /// </summary>
        /// <param name="filePath"></param>
        private static string GetAllText(string filePath, string encodeString)
        {
            return File.ReadAllText(filePath, Encoding.GetEncoding(encodeString));
        }

        #endregion

        #region Check

        public static bool IsExistFileCheck(string filePath)
        {
            return File.Exists(filePath);
        }

        public static string[] GetFileList(string folderPath, string extensionPattern)
        {
            var retList = new List<string>();

            foreach (var fileName in Directory.GetFiles(folderPath))
            {
                if (IsIncludeExtension(fileName, extensionPattern))
                {
                    retList.Add(Path.Combine(folderPath, fileName));
                }
            }

            return retList.ToArray();
        }

        public static bool IsIncludeExtension(string fileName, string extension)
        {
            return extension.Trim().Equals(Path.GetExtension(fileName));
        }

        #endregion

        #region GetFilePathList

        public static string[] GetFilePathList(string folderPath)
        {
            var dInfo = new DirectoryInfo(folderPath);
            var retList = new List<string>();

            if (!dInfo.Exists)
            {
                return null;
            }

            foreach (var fileName in dInfo.GetFiles())
            {
                retList.Add(Path.Combine(folderPath, fileName.Name));
            }

            return retList.ToArray();
        }

        #endregion

        #endregion
    }
}
