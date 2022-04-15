using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChuDe
    {
        public string MaChuDe { get; set; }
        public string TenChuDe { get; set; }
        public override string ToString()
        {
            return this.TenChuDe;
        }
    }
}
