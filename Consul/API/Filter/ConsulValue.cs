namespace TerrariaLauncher.Commons.Consul.API.Filter
{
    public class ConsulValue : ConsulExpression
    {
        public string Value { get; set; }

        public override string ToString()
        {
            return $"\"{Value}\"";
        }
    }
}
