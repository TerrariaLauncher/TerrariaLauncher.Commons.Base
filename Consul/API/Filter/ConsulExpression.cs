using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TerrariaLauncher.Commons.Consul.API.Filter
{
    public enum ConsulOperator
    {
        Equal,
        NotEqual,
        In,
        NotIn,
        Matches,
        NotMaches,
        IsEmpty,
        IsNotEmpty,
        And,
        Or,
        Not
    }

    public abstract class ConsulExpression
    {
        public abstract new string ToString();

        protected static string OperatorAsString(ConsulOperator operation)
        {
            switch (operation)
            {
                case ConsulOperator.Equal:
                    return "equal";
                case ConsulOperator.NotEqual:
                    return "not equal";
                case ConsulOperator.In:
                    return "in";
                case ConsulOperator.NotIn:
                    return "not in";
                case ConsulOperator.Matches:
                    return "matches";
                case ConsulOperator.NotMaches:
                    return "not matches";
                case ConsulOperator.IsEmpty:
                    return "is empty";
                case ConsulOperator.IsNotEmpty:
                    return "is not empty";
                case ConsulOperator.And:
                    return "and";
                case ConsulOperator.Or:
                    return "or";
                case ConsulOperator.Not:
                    return "not";
                default:
                    throw new InvalidEnumArgumentException(nameof(operation));
            }
        }
    }

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

    public class ConsulUnaryExpression : ConsulExpression
    {
        public ConsulOperator Operator { get; set; }

        public ConsulExpression Operand { get; set; }

        public override string ToString()
        {
            return $"{Operand} {OperatorAsString(Operator)}";
        }
    }

    public class ConsulSelector : ConsulExpression
    {
        public string Selector { get; set; }

        public override string ToString()
        {
            return Selector;
        }
    }

    public class ConsulBracket : ConsulExpression
    {
        public ConsulExpression Expression { get; set; }

        public override string ToString()
        {
            return $"({Expression.ToString()})";
        }
    }

    public class ConsulValue : ConsulExpression
    {
        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}
