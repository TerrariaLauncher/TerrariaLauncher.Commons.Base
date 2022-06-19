namespace TerrariaLauncher.Commons.Consul.API.CQS.Request
{
    public abstract class ConsulResult: IConsulResult
    {
        public ConsulResultMeta Meta { get; set; }
    }
}
