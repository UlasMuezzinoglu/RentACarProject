using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
       
        public Result(bool success, string message) : this(success)
        {
            
            this.Message = message;
        }
        public Result(bool success)
        {
            this.Success = success;
            
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
