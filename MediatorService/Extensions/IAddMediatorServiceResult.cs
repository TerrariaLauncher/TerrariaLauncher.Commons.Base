using System.Reflection;

namespace TerrariaLauncher.Commons.MediatorService
{
    public interface IAddMediatorServiceResult
    {
        IAddMediatorServiceResult AddMediatorHandlers(Assembly assembly);
    }
}
