using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace OyuLib.OyuIO.OyuFile
{
    public static class FileUtil
    {        
        #region method


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
