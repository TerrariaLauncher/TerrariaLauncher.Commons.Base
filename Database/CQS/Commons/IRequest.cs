﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TerrariaLauncher.Commons.Database.CQS.Commons
{
    public interface IRequest
    {
        Guid CorrelationId { get; set; }
    }
}
