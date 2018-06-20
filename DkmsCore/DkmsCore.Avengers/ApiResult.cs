﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Avengers
{
    public class ApiResult
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
}
