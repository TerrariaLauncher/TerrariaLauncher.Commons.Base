namespace TerrariaLauncher.Commons.Consul.API.Filter
{
    public class ConsulUnaryExpression : ConsulExpression
    {
        public ConsulOperator Operator { get; set; }

        public ConsulExpression Operand { get; set; }

        public override string ToString()
        {
            return $"{Operand} {OperatorAsString(Operator)}";
        }
    }
}
