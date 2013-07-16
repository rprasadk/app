using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Rhino.Mocks;
using app.windows;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs.windows
{
    [Subject(typeof(GetDirectoryData))]
    public class GetDataSpecs
    {
        public abstract class concern : Observes<GetDirectoryData>
        {
        }

        public class when_get_directory_entries_is_called : concern
        {
            Establish c = () =>
                {
                    path = "C:\\";
                    directory_info_provider = depends.on<IDirectoryInfoProvider>();

                    directory_info_provider.setup(x => x.get_directory_entries(Arg<string>.Is.Anything))
                        .Return(Enumerable.Range(1,10).Select(x => x.ToString()));
                };

            Because b = () =>
                {                    
                    result = sut.get_directory_entries(path);
                };

            It should_call_concrete_directory_info_provider = () =>
                   directory_info_provider.received(x => x.get_directory_entries(path));

            It should_return_correct_results = () =>
                {
                    result.Count().ShouldEqual(10);
                };

            static string path;
             static IDirectoryInfoProvider directory_info_provider;
            static IEnumerable<string> result;
        }
    }
}
