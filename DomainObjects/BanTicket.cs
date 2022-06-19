using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TerrariaLauncher.Commons.DomainObjects
{
    public class BanTicket
    {
        public int Id { get; set; }
        public Guid Uuid { get; set; }
        public string UnmanagedCharacterName { get; set; }
        public int? CharacterId { get; set; }
        public int? UserId { get; set; }
        public IPAddress ClientIp { get; set; }
        public Guid ClientUuid { get; set; }
        public int CreatedBy { get; set; }
        public string Reason { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? ChangedAt { get; set; }
        public DateTimeOffset? ValidUntil { get; set; }
    }
}
