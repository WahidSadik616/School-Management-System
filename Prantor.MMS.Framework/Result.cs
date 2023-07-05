using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prantor.MMS.Framework
{
    public class Result<T>
    {
        public T Data { get; set; }

        public string Message { get; set; }

        public bool HasError { get; set; }
    } 
}
