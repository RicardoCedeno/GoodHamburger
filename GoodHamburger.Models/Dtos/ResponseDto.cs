using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Models.Dtos
{
    public class ResponseDto<T> where T: class
    {
        public T? Data { get; set; }
        public bool IsSuccessful { get; set; } = false;
        public List<string> Errors { get; set; } = [];
    }
}
