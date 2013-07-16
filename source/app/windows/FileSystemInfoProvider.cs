using System;
using System.Collections.Generic;
using System.IO;

namespace app.windows
{
    public class FileSystemInfoProvider : IDirectoryInfoProvider
    {
        public IEnumerable<string> get_directory_entries(string path)
        {
            if (!Directory.Exists(path)) 
                throw new ArgumentException("Canot enumerate child nodes for a file");

            var di = new DirectoryInfo(path);                       

            foreach (var dir in di.GetDirectories())
                yield return dir.FullName;

            foreach (var file in di.GetFiles())
                yield return file.FullName;
        }       
    }
}