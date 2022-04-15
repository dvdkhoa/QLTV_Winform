using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BoMon
    {
        public string MaBoMon { get; set; }
        public string TenBoMon { get; set; }
        public string MaKhoa { get; set; }
        public override string ToString()
        {
            return this.TenBoMon;
        }
    }
}
