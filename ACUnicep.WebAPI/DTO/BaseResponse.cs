using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACUnicep.WebAPI.DTO
{
    public class BaseResponse
    {
        private bool Success { get; set; }
        private string Message { get; set; }
        private object Data { get; set; }

        public BaseResponse()
        {}

        public BaseResponse Ok(bool success, string message, object data)
        {
            return new BaseResponse
            {
                Success = success,
                Message = message,
                Data = data
            };
        }

        public BaseResponse BadRequest(bool success, string message)
        {
            return new BaseResponse
            {
                Success = success,
                Message = message
            };
        }
    }
}
