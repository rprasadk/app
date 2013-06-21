using System.Collections.Generic;
using System.Linq;

namespace app.web.core
{
  public class CommandRegistry : IFindCommands
  {
    IEnumerable<IProcessOneRequest> commands;
      private readonly ICreateTheMissingRequestCommand create_missing_request_command;

      public CommandRegistry(IEnumerable<IProcessOneRequest> commands,
          ICreateTheMissingRequestCommand create_missing_request_command)
    {
        this.commands = commands;
        this.create_missing_request_command = create_missing_request_command;
    }

      public IProcessOneRequest get_command_that_can_process(IContainRequestInformation request)
      {
          var command = commands.FirstOrDefault(c => c.can_process(request))
                        ?? create_missing_request_command(request);

          return command;
    }
  }
}