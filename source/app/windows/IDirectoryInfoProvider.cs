using System.Collections.Generic;

namespace app.windows
{
    public interface IDirectoryInfoProvider
    {
        IEnumerable<string> get_directory_entries(string path);
    }
}