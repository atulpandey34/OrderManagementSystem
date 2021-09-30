using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model.ViewModel
{
    public class ResultHeader
    {
        public bool success { get; set; }
        public int code { get; set; }
        public string message { get; set; }
    }
}
