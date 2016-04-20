using System.IO;
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

        public void CopyDirectory()
        {
            string fileName;
            string destFilePath;

            if (!Directory.Exists(_targetPath))
            {
                Directory.CreateDirectory(_targetPath);
            }

            if (Directory.Exists(_sourcePath))
            {
                string[] files = Directory.GetFiles(_sourcePath);

                foreach (string s in files)
                {
                    fileName = Path.GetFileName(s);
                    destFilePath = Path.Combine(_targetPath, fileName);
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