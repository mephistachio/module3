using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace module3
{
    class FileSystemService : IFileSystemService
    {
        public string[] GetDirectories(string path)
        {
            return Directory.GetDirectories(path);
        }

        public string[] GetFiles(string path)
        {
            return Directory.GetFiles(path);

        }
    }
}
