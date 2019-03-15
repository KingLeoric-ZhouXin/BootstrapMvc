using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ResponseModel<T>
    {
        public bool success { get; set; }

        public int code { get; set; }

        public string msg { get; set; }

        public T data { get; set; }
    }
}
