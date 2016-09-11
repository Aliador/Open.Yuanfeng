using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yuanfeng.Smarty.Encrypt
{
    /// <summary>
    /// 文件夹加密类
    /// </summary>
    public class DirectoryEncrypt
    {
        #region 加密文件夹及其子文件夹中的所有文件
        /// <summary>
        /// 加密文件夹及其子文件夹中的所有文件
        /// </summary>
        public static void EncryptDirectory(string dirPath, string pwd, RefreshDirProgress refreshDirProgress, RefreshFileProgress refreshFileProgress)
        {
            string[] filePaths = Directory.GetFiles(dirPath, "*", SearchOption.AllDirectories);
            for (int i = 0; i < filePaths.Length; i++)
            {
                FileEncrypt.EncryptFile(filePaths[i], pwd, refreshFileProgress);
                refreshDirProgress(filePaths.Length, i + 1);
            }
        }
        #endregion
        #region 解密文件夹及其子文件夹中的所有文件
        /// <summary>
        /// 解密文件夹及其子文件夹中的所有文件
        /// </summary>
        public static void DecryptDirectory(string dirPath, string pwd, RefreshDirProgress refreshDirProgress, RefreshFileProgress refreshFileProgress)
        {
            string[] filePaths = Directory.GetFiles(dirPath, "*", SearchOption.AllDirectories);
            for (int i = 0; i < filePaths.Length; i++)
            {
                FileEncrypt.DecryptFile(filePaths[i], pwd, refreshFileProgress);
                refreshDirProgress(filePaths.Length, i + 1);
            }
        }
        #endregion
    }
    /// <summary>
    /// 更新文件夹加密进度
    /// </summary>
    public delegate void RefreshDirProgress(int max, int value);
}
