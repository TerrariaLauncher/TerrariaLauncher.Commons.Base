namespace TerrariaLauncher.Commons.Consul.API.Filter
{
    public class ConsulBracket : ConsulExpression
    {
        public ConsulExpression Expression { get; set; }

        public override string ToString()
        {
            return $"({Expression.ToString()})";
        }
    }
}
