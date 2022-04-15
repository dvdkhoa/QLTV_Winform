using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KeSach
    {
        public string MaKeSach { get; set; }
        public string TenKeSach { get; set; }

        public override string ToString()
        {
            return this.TenKeSach;
        }
    }
}
