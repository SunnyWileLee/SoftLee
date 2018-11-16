using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DkmsCore.Infrustructure.Securitys
{
    public class DkmsUserContext
    {
        /// <summary>
        /// 用户对象
        /// </summary>
        public DkmsUser User { get; set; }
        public string UserAgent { get; set; }
        public string Token { get; set; }

        /// <summary>
        /// 当前上下文
        /// </summary>
        public static DkmsUserContext Current
        {
            get
            {
                if (!(Thread.CurrentPrincipal is DkmsPrincipal principal))
                {
                    return null;
                }
                return principal.DkmsUserContext;
            }
        }

        public static bool IsAnonymous
        {
            get
            {
                return UserIdDefaultEmpty == Guid.Empty;
            }
        }

        public static Guid UserIdDefaultEmpty
        {
            get
            {
                return Current?.User?.Id ?? Guid.Empty; ;
            }
        }
    }
}
