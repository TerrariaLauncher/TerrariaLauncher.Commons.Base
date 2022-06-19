using Microsoft.Extensions.DependencyInjection;
using System;

namespace TerrariaLauncher.Commons.ManualMapping
{
    public class ManualMappingDispatcher: IManualMappingDispatcher
    {
        IServiceProvider serviceProvider;
        public ManualMappingDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public TOutput Dispatch<TOutput, TInput>(TInput input)
        {
            var handler = this.serviceProvider.GetRequiredService<IManualMappingHandler<TOutput, TInput>>();
            return handler.Handle(input);
        }
    }
}
