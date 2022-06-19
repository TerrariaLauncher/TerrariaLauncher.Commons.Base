namespace TerrariaLauncher.Commons.ManualMapping
{
    public interface IManualMappingHandler<TOutput, TInput>
    {
        TOutput Handle(TInput input);
    }
}
