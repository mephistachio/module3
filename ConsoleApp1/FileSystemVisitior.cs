using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace module3
{
    public class FileSystemVisitior
    {
        public event EventHandler<StartEventArgs> Start;
        public event EventHandler<FinishEventArgs> Finish;
        public event EventHandler<ItemFindedEventArgs<FileInfo>> FileFinded;
        public event EventHandler<ItemFindedEventArgs<FileInfo>> FilteredFileFinded;
        public event EventHandler<ItemFindedEventArgs<DirectoryInfo>> DirectoryFinded;
        public event EventHandler<ItemFindedEventArgs<DirectoryInfo>> FilteredDirectoryFinded;

        public FileSystemVisitior()
        {

        }

        public List<string> GetDirectories(string startDir)
        {
            var result = new List<string>();
            result = LoadSubDirs(startDir);
            return result;
        }

        private List<string> LoadSubDirs(string dir)

        {
            var result = new List<string>();
            string[] subdirectoryEntries = Directory.GetDirectories(dir);
            result.AddRange(subdirectoryEntries);
            foreach (string item in subdirectoryEntries)
            {
                foreach (string f in Directory.GetFiles(item))
                {
                    List<string> dirs = LoadSubDirs(item);
                    List<string> files = LoadSubDirs(f);
                    result.AddRange(dirs);
                    result.AddRange(files);
                }
            }
            return result;

        }

        private class CurrentAction
        {
            public ActionType Action { get; set; }
            public static CurrentAction ContinueSearch
                => new CurrentAction { Action = ActionType.ContinueSearch };
        }


    }
}
