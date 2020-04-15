using System;
using System.Collections.Generic;
using System.Text;

namespace module3
{
    public interface IFileSystemService
    {
        string[] GetDirectories(string path);
        string[] GetFiles(string path);
    }
}
