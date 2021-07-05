using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TerrariaLauncher.Commons.Extensions
{
    public interface IErrorHandler
    {
        void HandleError(Exception exception);
    }

    public static class TaskUtilities
    {
        public static async void FireAndForgetSafeAsync(this Task task, IErrorHandler errorHandler = null)
        {
            try
            {
                await task.ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                errorHandler?.HandleError(exception);
            }
        }
    }
}
