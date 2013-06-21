using System;
using System.Collections.Generic;

namespace app.web.core
{
  public class CommandRegistry : IFindCommands
  {
      private readonly IEnumerable<IProcessOneRequest> listOfCommands;

      public CommandRegistry(IEnumerable<IProcessOneRequest> listOfCommands)
      {
          this.listOfCommands = listOfCommands;
      }

    public IProcessOneRequest get_command_that_can_process(IContainRequestInformation request)
    {
        foreach (var command in listOfCommands)
        {
            if (command.can_process(request))
            {
                return command;
            }
        }

        // TBD - return a null object
        throw new Exception();
    }
  }
}