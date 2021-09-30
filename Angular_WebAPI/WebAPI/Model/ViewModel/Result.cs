using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model.ViewModel
{
    public class Result
    {
        public Result()
        {
            header = new ResultHeader();
        }
        public ResultHeader header { get; set; }
        public dynamic data { get; set; }
    }
}
