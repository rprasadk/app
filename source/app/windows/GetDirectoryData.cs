using System.Collections.Generic;

namespace app.windows
{
    public class GetDirectoryData : IGetData
    {
        private readonly IDirectoryInfoProvider concrete_dir_info_provider;

        public GetDirectoryData(IDirectoryInfoProvider concrete_dir_info_provider)
        {
            this.concrete_dir_info_provider = concrete_dir_info_provider;
        }

        public IEnumerable<string> get_directory_entries(string path)
        {
            return concrete_dir_info_provider.get_directory_entries(path);
        }
    }
}