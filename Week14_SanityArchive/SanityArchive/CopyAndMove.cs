using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SanityArchive
{
    public class CopyAndMove
    {
        private string _sourcePath;
        private string _targetPath;

        public CopyAndMove(string sourcePath, string targetPath)
        {
            _sourcePath = sourcePath;
            _targetPath = targetPath;
        }

        public void CopyFile()
        {
            string fileName = Path.GetFileName(_sourcePath);
            string destFilePath = Path.Combine(_targetPath, fileName);

            File.Copy(_sourcePath, destFilePath, true);
        }

        public void CopyDirectory(string sourceDirName, string destDirName)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destDirName, subdir.Name);
                CopyDirectory(subdir.FullName, temppath);
            }
        }

        public void MoveFile()
        {
            File.Move(_sourcePath, _targetPath);
        }

        public void MoveDirectory()
        {
            Directory.Move(_sourcePath, _targetPath);
        }
    }
}