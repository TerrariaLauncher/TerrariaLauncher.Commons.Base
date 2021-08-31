using System;
using System.Collections.Generic;
using System.Text;

namespace TerrariaLauncher.Commons.Database.CQS.Request
{
    public abstract class Request : IRequest
    {
        public Guid CorrelationId { get; set; }

        protected Request()
        {
            this.CorrelationId = Guid.NewGuid();
        }
    }
}
