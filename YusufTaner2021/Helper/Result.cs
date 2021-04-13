using System;
using System.Collections.Generic;
using System.Text;

namespace Helper
{
    public class Result<T>
    {
        public bool Succesfull { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public Result(bool Succesfull, string Message, T Data)
        {
            this.Succesfull = Succesfull;
            this.Message = Message;
            this.Data = Data;
        }
    }
}
