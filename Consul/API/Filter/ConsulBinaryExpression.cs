namespace TerrariaLauncher.Commons.Consul.API.Filter
{
    public class ConsulBinaryExpression : ConsulExpression
    {
        public ConsulOperator Operator { get; set; }
        public ConsulExpression Left { get; set; }
        public ConsulExpression Right { get; set; }

        public override string ToString()
        {
            return $"{Left.ToString()} {OperatorAsString(Operator)} {Right.ToString()}";
        }
    }
}
