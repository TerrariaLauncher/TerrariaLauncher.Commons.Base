using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TerrariaLauncher.Commons.Consul.API.Commons;
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
        public override string Path => "agent/service/register";
        public override HttpMethod HttpMethod => HttpMethod.Put;
    }
}
