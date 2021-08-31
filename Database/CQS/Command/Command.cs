using System;
using System.Collections.Generic;
using System.Text;
using TerrariaLauncher.Commons.Database.CQS.Request;

namespace TerrariaLauncher.Commons.Database.CQS.Command
{
    public abstract class Command : Request.Request, ICommand
    {

    }
}
