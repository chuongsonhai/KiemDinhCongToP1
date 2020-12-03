using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Tem_Chi
{
    public class KDV_Tem
    {
        public long id { get; set; }
        public DateTimeOffset Ngay_Su_Dung { get; set; }
        public int? SoLuong { get; set; }
        public long? KDV_ID { get; set; }
        public TaiKhoan TaiKhoan { get; set; }
        public long? Tem_ID { get; set; }
        public int? SoLuongTem { get; set; }
        public int? SoLuongTem_Huy { get; set; }
        public DM_Tem DM_Tem { get; set; }
        public string Seri_Dau { get; set; }
        public string Seri_Cuoi { get; set; }
        public int? SoLuong_Huy { get; set; }
        public string Seri_Tem_Huy { get; set; }
        public string NguoiCapNhat { get; set; }
        public DateTime TGian_CapNhat { get; set; }
    }
}
