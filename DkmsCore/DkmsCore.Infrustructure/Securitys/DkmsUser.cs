using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Infrustructure.Securitys
{
    public class DkmsUser
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadIcon { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; set; }
    }
}
