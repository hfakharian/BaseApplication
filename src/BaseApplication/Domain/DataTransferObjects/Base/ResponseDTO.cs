using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects.Base
{
    public class ResponseDTO<T>
    {
        public ResponseDTO()
        {
        }
        public ResponseDTO(T data, string message = "")
        {
            IsSucceeded = true;
            Message = message;
            Data = data;
            Errors = default;
        }
        public ResponseDTO(string message, bool isSuccess = false)
        {
            IsSucceeded = isSuccess;
            Message = message;
            Data = default;
            Errors = default;
        }

        public ResponseDTO(string message, List<string> errors)
        {
            IsSucceeded = false;
            Message = message;
            Data = default;
            Errors = errors;
        }

        public void SetErrors(List<string> errors)
        {
            IsSucceeded = false;
            Errors = errors;
        }

        public bool IsSucceeded { get; private set; }
        public string? Message { get; private set; }
        public List<string>? Errors { get; private set; }
        public T? Data { get; private set; }
    }
}
