using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterDapter.Models
{
    public class MatterDapterResponse<T>
    {
        public bool IsSuccess { get; init; }
        public string? Message { get; init; }
        public T? Source { get; init; }
        public Exception? Exception { get; init; }

        public MatterDapterResponse(T data)
        {
            IsSuccess = true;
            Source = data;
        }

        public MatterDapterResponse(T data, Exception exception)
        {
            IsSuccess=false;
            Message = exception.Message;
            Source = data;
            Exception = exception;
        }
    }

    public class MatterDapterResponse
    {
        public bool IsSuccess { get; init; }
        public string? Message { get; init; }
        public Exception? Exception { get; init; }

        public MatterDapterResponse()
        {
            IsSuccess = true;
        }

        public MatterDapterResponse(Exception ex)
        {
            IsSuccess = false;
            Message = ex.Message;
            Exception = ex;
        }
    }
}
