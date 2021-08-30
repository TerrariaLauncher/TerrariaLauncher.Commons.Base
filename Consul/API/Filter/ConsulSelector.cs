namespace TerrariaLauncher.Commons.Consul.API.Filter
{
    public class ConsulSelector : ConsulExpression
    {
        public string Selector { get; set; }

        public override string ToString()
        {
            return Selector;
        }
    }
}
