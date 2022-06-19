using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TerrariaLauncher.Commons.Consul.API.CQS.Command;
using TerrariaLauncher.Commons.Consul.API.DTOs;

namespace TerrariaLauncher.Commons.Consul.API.Agent.Services.Commands
{
    public class RegisterServiceCommand : ConsulCommand
    {
        public RegisterServiceCommand() : base(new RegisterServiceCommandOptions()) { }
        public RegisterServiceCommand(RegisterServiceCommandOptions options) : base(options) { }

        public Registration Registration { get; set; }
        public bool ReplaceExistingChecks { get; set; }
    }

    public class RegisterServiceCommandOptions : ConsulCommandOptions
    {
        public override HttpOptions Http => new HttpOptions("agent/service/register", HttpMethod.Put);
    }
}
