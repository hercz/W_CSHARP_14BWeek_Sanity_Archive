using System.IO;
using System.Windows.Forms;

namespace SanityArchive
{
    public class CopyAndMove
    {
        public void CopyFile(string sourcePath, string targetPath)
        {
            string fileName = new FileInfo(sourcePath).Name;
            string destFilePath = Path.Combine(targetPath, fileName);

            File.Copy(sourcePath, destFilePath, true);
        }

        public void CopyDirectory(string sourcePath, string targetPath)
        {
            string fileName;
            string destFilePath;

            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);

                foreach (string s in files)
                {
                    fileName = Path.GetFileName(s);
                    destFilePath = Path.Combine(targetPath, fileName);
                    File.Copy(s, destFilePath, true);
                }
            }
            else
            {
                MessageBox.Show("Source path does not exist!");
            }
        }
    }
}