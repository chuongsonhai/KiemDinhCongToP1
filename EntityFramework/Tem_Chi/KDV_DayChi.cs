using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Tem_Chi
{
    public class KDV_DayChi
    {
        public long id { get; set; }
        public DateTimeOffset Ngay_Su_Dung { get; set; }
        public long? KDV_ID { get; set; }
        public TaiKhoan TaiKhoan { get; set; }
        public int? SoLuong { get; set; }
        public long? Daychi_ID  { get; set; }
        public DM_DayChi DM_DayChi { get; set; }
        public int? SoLuongDayChi { get; set; }
        public int? SoLuongDayChi_Huy { get; set; }
        public string  LoaiDayChi_Huy { get; set; }
        public int? SoLuong_Huy { get; set; }
        public string NguoiCapNhat { get; set; }
        public DateTime TGian_CapNhat { get; set; }

    }
}
