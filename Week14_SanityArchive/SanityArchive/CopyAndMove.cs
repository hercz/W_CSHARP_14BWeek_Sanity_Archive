using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SanityArchive
{
    public class CopyAndMove
    {
        public CopyAndMove()
        {
            
        }

        public void CopyFile(string sourceFilePath, string targetFilePath)
        {
            string fileName = Path.GetFileName(sourceFilePath);
            string destFilePath = Path.Combine(targetFilePath, fileName);

            File.Copy(sourceFilePath, destFilePath, true);
        }

        public void CopyDirectory(string sourceDirName, string destDirName)
        {
            try
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
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void MoveFile(string sourceFilePath, string targetFilePath)
        {
            CopyFile(sourceFilePath, targetFilePath);
            DeleteFunction(sourceFilePath);
        }

        public void MoveDirectory(string sourceDirName, string destDirName)
        {
            CopyDirectory(sourceDirName, destDirName);
            DeleteFunction(sourceDirName);
        }

        public void DeleteFunction(string sourcePath)
        {
            FileAttributes fa = File.GetAttributes(sourcePath);

            if (fa == FileAttributes.Directory)
            {
                DirectoryInfo di = new DirectoryInfo(sourcePath);
                try
                {
                    di.Delete(true);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                FileInfo fi = new FileInfo(sourcePath);
                try
                {
                    fi.Delete();
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}