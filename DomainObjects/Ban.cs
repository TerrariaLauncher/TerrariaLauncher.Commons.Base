using System;
using System.Collections.Generic;
using System.Text;

namespace TerrariaLauncher.Commons.DomainObjects
{
    public class Ban
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public DateTimeOffset IssuedAt { get; set; }
        public DateTimeOffset Expiration { get; set; }
        public IList<BanDetails> BanDetails { get; set; }
    }

    public class BanDetails
    {
        public int BanId { get; set; }
        public string Type { get; set; }
        public string Identity { get; set; }
    }

    public class BanIdentityType
    {
        public const string IPv4 = "IPv4";
        public const string UUID = "UUID";
        public const string UserName = "UserName";
        public const string CharacterName = "CharacterName";
    }
}
