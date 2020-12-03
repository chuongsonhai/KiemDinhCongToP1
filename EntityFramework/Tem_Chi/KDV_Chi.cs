using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EntityFramework.Tem_Chi
{
    public class KDV_Chi
    {
        public long id { get; set; }
        public DateTimeOffset Ngay_Su_Dung { get; set; }
        public long? KDV_ID { get; set; }
        public TaiKhoan TaiKhoan { get; set; }
        public long? Chi_ID { get; set; }
        public DM_Chi DM_Chi { get; set; }
        public int? SoLuongChi { get; set; }
        public int? SoLuongChi_Huy { get; set; }
        public string NguoiCapNhat { get; set; }
        public DateTime TGian_CapNhat { get; set; }
    }
}
