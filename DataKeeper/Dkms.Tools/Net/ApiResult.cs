using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Tools.Net
{
    public class ApiResult : ApiResultBase
    {
        /// <summary>
        /// 结果对象
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// 返回正确结果
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResult Success(object data, string message = "")
        {
            return new ApiResult { Data = data, Code = 200, Message = message };
        }
        /// <summary>
        /// 返回错误结果
        /// </summary>
        /// <param name="code">错误code</param>
        /// <param name="message">错误信息</param>
        /// <returns></returns>
        public static ApiResult Fail(int code = 0, string message = "")
        {
            return new ApiResult { Code = code, Message = message };
        }
    }

    /// <summary>
    /// 回参
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResult<T> : ApiResultBase
    {
        /// <summary>
        /// 结果对象
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// 返回正确结果
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResult<T> Success(T data, string message = "")
        {
            return new ApiResult<T> { Data = data, Code = 200, Message = message };
        }
        /// <summary>
        /// 返回错误结果
        /// </summary>
        /// <param name="code">错误code</param>
        /// <param name="message">错误信息</param>
        /// <returns></returns>
        public static ApiResult<T> Fail(int code = 0, string message = "")
        {
            return new ApiResult<T> { Code = code, Message = message };
        }
    }
}
