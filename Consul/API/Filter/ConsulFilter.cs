using System;
using System.Collections.Generic;
using System.Text;
using TerrariaLauncher.Commons.Consul.API.Filter;

namespace TerrariaLauncher.Commons.Consul.Filter
{
    public class ConsulFilter : ConsulExpression
    {
        public ConsulExpression Expression { get; set; }

        public override string ToString()
        {
            return this.Expression.ToString();
        }
    }
}
