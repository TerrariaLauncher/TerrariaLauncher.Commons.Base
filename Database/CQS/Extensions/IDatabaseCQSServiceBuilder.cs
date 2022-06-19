using System.Reflection;

namespace TerrariaLauncher.Commons.Database.CQS.Extensions
{
    public interface IDatabaseCQSServiceBuilder
    {
        IDatabaseCQSServiceBuilder AddHandlers(Assembly assembly);
    }
}
