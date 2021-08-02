using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TerrariaLauncher.Commons.AsyncHelpers
{
    public class PauseTokenSource
    {
        private volatile TaskCompletionSource<bool> m_paused;
        public bool IsPause
        {
            get => this.m_paused != null;
            set
            {
                if (value)
                {
                    Interlocked.CompareExchange(ref m_paused, new TaskCompletionSource<bool>(), null);
                }
                else
                {
                    while (true)
                    {
                        var tcs = this.m_paused;
                        if (tcs == null) return;
                        if (Interlocked.CompareExchange(ref m_paused, null, tcs) == tcs)
                        {
                            tcs.SetResult(true);
                            break;
                        }
                    }
                }
            }
        }

        internal static readonly Task s_completedTask = Task.FromResult(true);
        internal Task WaitWhilePauseAsync()
        {
            var cur = this.m_paused;
            return cur != null ? cur.Task : s_completedTask;
        }

        public PauseToken Token { get => new PauseToken(this); }
    }
}
