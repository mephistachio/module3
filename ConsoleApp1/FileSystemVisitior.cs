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
        //public event EventHandler<ItemFindedEventArgs<FileInfo>> FileFinded;
        //public event EventHandler<ItemFindedEventArgs<FileInfo>> FilteredFileFinded;
        //public event EventHandler<ItemFindedEventArgs<DirectoryInfo>> DirectoryFinded;
        //public event EventHandler<ItemFindedEventArgs<DirectoryInfo>> FilteredDirectoryFinded;

        private IFileSystemService fileSystemService;

        public FileSystemVisitior()
        {
            
        }

        public FileSystemVisitior(IFileSystemService fileService)
        {
            fileSystemService = fileService;
        }


        private void onFireStart(StartEventArgs args)
        {
            if (Start!=null)
                Start.Invoke(this, args);
        }

        public List<string> GetDirectories(string startDir, string filter)
        {
            onFireStart(null);
            var result = new List<string>();
            result = LoadSubDirs(startDir, filter);
            return result;
        }

        

        private List<string> LoadSubDirs(string dir, string filter)

        {
            var result = new List<string>();
            string[] subdirectoryEntries = fileSystemService.GetDirectories(dir);
            var filteredDirs = FilterList(subdirectoryEntries, filter);
            result.AddRange(filteredDirs);
            string[] files = fileSystemService.GetFiles(dir);
            var filteredFiles = FilterList(files, filter);
            result.AddRange(filteredFiles);
            foreach (string item in subdirectoryEntries)
            {
                    List<string> dirs = LoadSubDirs(item, filter);
                    result.AddRange(dirs);
            }
            return result;

        }

        private List<string> FilterList(string[] originalList, string filter)
        {
            var result = new List<string>();
            for (int i = 0; i < originalList.Length; i++)
            {
                if (originalList[i].Contains(filter))
                {
                    result.Add(originalList[i]);
                }
                else
                {
                    Console.WriteLine("Nothing was found");
                }
               
            }
            return result;
        }
        private void onFireFinish(FinishEventArgs args)
        {
            if (Finish != null)
                Finish.Invoke(this, args);
        }

    }
}
