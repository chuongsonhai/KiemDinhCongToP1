using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Tem_Chi
{
    public class SLT_DayChi
    {
        public long id { get; set; }
        public DateTimeOffset Ngay_Cap_Phat { get; set; }
        public long? Daychi_ID { get; set; }
        public DM_DayChi DM_DayChi { get; set; }
        public int? SoLuongDayChi { get; set; }
        public int? SoLuongDayChi_Huy { get; set; }
        public int? SoLuongDayChi_Ton { get; set; }
        public string NguoiCapNhat { get; set; }
        public DateTime TGian_CapNhat { get; set; }
    }
}
