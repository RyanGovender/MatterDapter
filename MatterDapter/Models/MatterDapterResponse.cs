using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterDapter.Models
{
    public class MatterDapterResponse<T>
    {
        public bool Success { get; init; }
        public string? Message { get; init; }
        public T? Source { get; init; }
        public string[]? Errors { get; init; }
    }

    public class MatterDapterResponse
    {
        public bool Success { get; init; }
        public string? Message { get; init; }
        public string[]? Errors { get; init; }
    }
}
