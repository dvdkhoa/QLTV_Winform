using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Nganh
    {
        public string MaNganh { get; set; }
        public string TenNganh { get; set; }
        public string MaBoMon { get; set; }

        public override string ToString()
        {
            return this.TenNganh;
        }
    }
}
