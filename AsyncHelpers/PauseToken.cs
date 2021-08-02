using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TerrariaLauncher.Commons.AsyncHelpers
{
    public struct PauseToken
    {
        private readonly PauseTokenSource m_source;
        internal PauseToken(PauseTokenSource source)
        {
            this.m_source = source;
        }

        public bool IsPause { get => this.m_source != null && this.m_source.IsPause; }
        
        public Task WaitWhilePauseAsync()
        {
            return this.IsPause ? this.m_source.WaitWhilePauseAsync() : PauseTokenSource.s_completedTask;
        }
    }
}
