namespace TerrariaLauncher.Commons.ManualMapping
{
    public abstract class ManualMappingHandler<TOutput, TInput> : IManualMappingHandler<TOutput, TInput>
    {
        public TOutput Handle(TInput input)
        {
            return this.Implementation(input);
        }

        protected abstract TOutput Implementation(TInput input);
    }
}
