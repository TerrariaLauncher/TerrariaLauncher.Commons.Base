namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public abstract class ConsulQueryResult : ConsulResult, IConsulQueryResult
    {
        protected ConsulQueryResult()
        {
            (this as IConsulQueryResult).Headers = new ConsulQueryResultHeaders();
        }

        new public ConsulQueryResultHeaders Headers
        {
            get => (this as IConsulResult).Headers as ConsulQueryResultHeaders;
            set => (this as IConsulResult).Headers = value;
        }
    }
}
