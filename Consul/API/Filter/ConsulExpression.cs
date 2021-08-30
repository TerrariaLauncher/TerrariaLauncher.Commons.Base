using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TerrariaLauncher.Commons.Consul.API.Filter
{
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
}
