using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DauSach
    {
        public string MaDauSach { get; set; }
        public string TenDauSach { get; set; }
        public string MaLS { get; set; }
        public string MaChuDe { get; set; }
        public string MaTG { get; set; }
        public string MaNXB { get; set; }
        public int NamXB { get; set; }
        public int SL { get; set; }
        public string MaNganh { get; set; }
        public string MaHocPhan { get; set; }
        public string MaKeSach { get; set; }
        public int SoTrang { get; set; }
        public string KhoCo { get; set; }
        public string Tags { get; set; }
        public string MinhHoa { get; set; }
        public long GiaBia { get; set; }
        public string Nguon { get; set; }
        public string TenKhac { get; set; }
        public string TungThu { get; set; }
        public int SoTap { get; set; }
        public string TenTap { get; set; }
        public string DinhKem { get; set; }
        public string NgonNgu { get; set; }
        public string ISBN { get; set; }

        public override string ToString()
        {
            return this.MaDauSach;
        }
    }
}
