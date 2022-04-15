using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HocPhan
    {
        public string MaHocPhan { get; set; }
        public string TenHocPhan { get; set; }

        public override string ToString()
        {
            return this.TenHocPhan;
        }
    }
}
