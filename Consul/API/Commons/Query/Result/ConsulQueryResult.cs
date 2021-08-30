namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public abstract class ConsulQueryResult : ConsulResult, IConsulQueryResult
    {
        protected ConsulQueryResult()
        {
            (this as IConsulQueryResult).Meta = new ConsulQueryResultMeta();
        }

        new public ConsulQueryResultMeta Meta
        {
            get => (this as IConsulResult).Meta as ConsulQueryResultMeta;
            set => (this as IConsulResult).Meta = value;
        }
    }
}
