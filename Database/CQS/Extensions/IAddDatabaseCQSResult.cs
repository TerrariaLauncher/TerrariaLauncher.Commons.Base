using System.Reflection;

namespace TerrariaLauncher.Commons.Database.CQS.Extensions
{
    public interface IAddDatabaseCQSResult
    {
        IAddDatabaseCQSResult AddHandlers(Assembly assembly);
    }
}
