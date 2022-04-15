using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TacGia
    { 
        public string MaTG { get; set; }
        public string TenTG { get; set; }
        public string DiaChi { get; set; }
        public string phone { get; set; }

        public override string ToString()
        {
            return this.TenTG;
        }
    }
}
