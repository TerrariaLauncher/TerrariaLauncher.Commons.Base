using System;
using System.Collections.Generic;
using System.Text;

namespace TerrariaLauncher.Commons.Consul.API.DTOs
{
    public class Check
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string Interval { get; set; }
        public string Notes { get; set; }
        public string DeregisterCriticalServiceAfter { get; set; }
        public string[] Args { get; set; }
        public string AliasNode { get; set; }
        public string AliasService { get; set; }
        public string DockerContainerID { get; set; }
        public string GRPC { get; set; }
        public bool GRPCUseTLS { get; set; }
        public string H2PING { get; set; }
        public string HTTP { get; set; }
        public string Method { get; set; }
        public string Body { get; set; }
        public IDictionary<string, IList<string>> Header { get; set; }
        public string Timeout { get; set; }
        public int OutputMaxSize { get; set; }
        public string TLSServerName { get; set; }
        public bool TLSSkipVerify { get; set; }
        public string TCP { get; set; }
        public string TTL { get; set; }
        public string ServiceID { get; set; }
        public string Status { get; set; }
        public int SuccessBeforePassing { get; set; }
        public int FailureBeforeCritical { get; set; }
    }
}
