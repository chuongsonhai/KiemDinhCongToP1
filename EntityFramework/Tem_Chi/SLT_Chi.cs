using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Tem_Chi
{
    public class SLT_Chi
    {
        public long id { get; set; }
        public DateTimeOffset Ngay_Cap_Phat { get; set; }
        public long? Chi_ID { get; set; }
        public DM_Chi DM_Chi { get; set; }
        public int? SoLuongChi { get; set; }
        public int? SoLuongChi_Huy { get; set; }
        public int? SoLuongChi_Ton { get; set; }
        public string NguoiCapNhat { get; set; }
        public DateTime TGian_CapNhat { get; set; }
    }
}
