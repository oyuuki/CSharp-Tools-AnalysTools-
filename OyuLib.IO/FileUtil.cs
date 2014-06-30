using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace OyuLib.IO
{
    public static class FileUtil
    {        
        #region method

        #region Check

        public static bool IsExistFileCheck(string filePath)
        {
            return System.IO.File.Exists(filePath);
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

        public static SearchResult[] GetResultSearchFiles(string folderPath, string[] filenames)
        {
            var retList = new List<SearchResult>();

            foreach(var searchFileName in filenames)
            {
                var isFind = false;

                foreach (var filenamePath in Directory.GetFiles(folderPath))
                {
                    var filename = Path.GetFileName(filenamePath);

                    if(searchFileName.Equals(filename))
                    {
                        retList.Add(new SearchResult(filename, true));
                        isFind = true;
                        break;
                    }
                }

                if(!isFind)
                {
                    retList.Add(new SearchResult(searchFileName, false));
                }
            }

            return retList.ToArray();
        }

        public static void CopyAllFile(string dirpath, string copyDir, bool isForce)
        {
            if(Directory.Exists(copyDir))
            {
                if(isForce)
                {
                    DeleteDirectory(copyDir);
                    Directory.CreateDirectory(copyDir);    
                }
            }
            else
            {
                Directory.CreateDirectory(copyDir);
            }

            foreach(var filePath in Directory.GetFiles(dirpath))
            {
                File.Copy(filePath, Path.Combine(copyDir, Path.GetFileName(filePath)));
            }
        }


        public static void ChangeFileExtension(string[] filenames, string dir,  string taretExtension, string changeExtension)
        {
            if(filenames == null || filenames.Length <= 0)
            {
                throw new IOException("\"filenames\" hasn't any value");
            }

            var forderpath = dir;
            var copyfolder = Path.Combine(forderpath, "Backup");
            // create backup
            CopyAllFile (forderpath, copyfolder, true);

            foreach(var filepath in GetFileList(forderpath, taretExtension))
            {
                File.Move(filepath, filepath.Replace(taretExtension, changeExtension));
            }
        }

        public static string[] GetFileList(string folderPath)
        {
            var retList = new List<string>();

            foreach (var fileName in Directory.GetFiles(folderPath))
            {
                retList.Add(Path.Combine(folderPath, fileName));
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

        /// <summary>
        /// フォルダを根こそぎ削除する（ReadOnlyでも削除）
        /// </summary>
        /// <param name="dir">削除するフォルダ</param>
        public static void DeleteDirectory(string dir)
        {
            //DirectoryInfoオブジェクトの作成
            DirectoryInfo di = new DirectoryInfo(dir);

            //フォルダ以下のすべてのファイル、フォルダの属性を削除
            RemoveReadonlyAttribute(di);

            //フォルダを根こそぎ削除
            di.Delete(true);
        }

        public static void RemoveReadonlyAttribute(DirectoryInfo dirInfo)
        {
            //基のフォルダの属性を変更
            if ((dirInfo.Attributes & FileAttributes.ReadOnly) ==
                FileAttributes.ReadOnly)
                dirInfo.Attributes = FileAttributes.Normal;
            //フォルダ内のすべてのファイルの属性を変更
            foreach (FileInfo fi in dirInfo.GetFiles())
                if ((fi.Attributes & FileAttributes.ReadOnly) ==
                    FileAttributes.ReadOnly)
                    fi.Attributes = FileAttributes.Normal;
            //サブフォルダの属性を回帰的に変更
            foreach (DirectoryInfo di in dirInfo.GetDirectories())
                RemoveReadonlyAttribute(di);
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public class SearchResult
        {
            /// <summary>
            /// ファイル名
            /// </summary>
            private string _filename = string.Empty;

            /// <summary>
            /// 見つかったかどうかのフラグ
            /// </summary>
            private bool _isFind = false;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="filename">ファイル名</param>
            /// <param name="isFind">見つかったかどうかのフラグ</param>
            internal SearchResult(string filename, bool isFind)
            {
                this._isFind = isFind;
                this._filename = filename;
            }

            /// <summary>
            /// ファイル名を返す
            /// </summary>
            public string Filename
            {
                get { return this._filename; }
            }

            /// <summary>
            /// 見つかったかどうかのフラグ
            /// </summary>
            public bool IsFind
            {
                get { return this._isFind; }
            }
        }
    }
}
