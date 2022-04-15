using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace DTO
{
    public class LoaiSach
    {
        public string MaLoaiSach { get; set; }
        public string TenLoaiSach { get; set; }

        public override string ToString()
        {
            return this.TenLoaiSach;
        }
    }
}
