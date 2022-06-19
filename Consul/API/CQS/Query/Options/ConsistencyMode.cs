using System;

namespace TerrariaLauncher.Commons.Consul.API.CQS.Query
{
    public class ConsistencyMode: IEquatable<ConsistencyMode>
    {
        private string mode;
        public ConsistencyMode(string mode)
        {
            this.mode = mode;
        }

        private static readonly ConsistencyMode @default = new ConsistencyMode("default");
        private static readonly ConsistencyMode consistent = new ConsistencyMode("consistent");
        private static readonly ConsistencyMode stale = new ConsistencyMode("stale");

        public static ConsistencyMode Default { get => @default; }
        public static ConsistencyMode Consistent { get => consistent; }
        public static ConsistencyMode Stale { get => stale; }

        public bool Equals(ConsistencyMode other)
        {
            if (other is null)
            {
                return false;
            }

            if (object.ReferenceEquals(this.mode, other.mode))
            {
                return true;
            }

            return string.Compare(this.mode, other.mode, StringComparison.OrdinalIgnoreCase) == 0;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ConsistencyMode);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return this.mode;
        }

        public static bool operator == (ConsistencyMode left, ConsistencyMode right)
        {
            if (left is null)
            {
                if (right is null)
                {
                    return true;
                }
            }

            if (right is null)
            {
                if (left is null)
                {
                    return true;
                }
            }

            return left.Equals(right);
        }

        public static bool operator !=(ConsistencyMode left, ConsistencyMode right)
        {
            return !(left == right);
        }
    }
}
