using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Tem_Chi
{
    public class SLT_Tem
    {
        public long id { get; set; }
        public DateTimeOffset Ngay_Cap_Phat { get; set; }
        public long? Tem_ID { get; set; }
        public DM_Tem DM_Tem { get; set; }
        public int? SoLuongTem { get; set; }
        public int? SoLuongTem_Huy { get; set; }
        public int? SoLuongTem_Ton { get; set; }
        public string NguoiCapNhat { get; set; }
        public DateTime TGian_CapNhat { get; set; }
    }
}
