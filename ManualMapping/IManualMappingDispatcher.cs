namespace TerrariaLauncher.Commons.ManualMapping
{
    public interface IManualMappingDispatcher
    {
        TOutput Dispatch<TOutput, TInput>(TInput input);
    }
}
