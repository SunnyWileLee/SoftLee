using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Tools.Net
{
    public class ApiResultBase
    {
        /// <summary>
        /// 默认正确的code
        /// </summary>
        public const int SuccessCode = 200;
        /// <summary>
        /// CODE
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess
        {
            get
            {
                return Code == SuccessCode;
            }
        }
    }
}
