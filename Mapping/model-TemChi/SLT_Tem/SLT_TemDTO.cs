using System;
using System.Collections.Generic;
using System.Text;

namespace Mapping.model_TemChi.SLT_Tem
{
    public class SLT_TemDTO
    {
        public long id { get; set; }
        public DateTimeOffset Ngay_Cap_Phat { get; set; }
        public long? KDV_ID { get; set; }
        public long? Tem_ID { get; set; }
        public int? SoLuong { get; set; }
        public int? SoLuongTem { get; set; }
        public int? SoLuongTem_Huy { get; set; }
        public int? SoLuongTem_Ton { get; set; }
    }
}
