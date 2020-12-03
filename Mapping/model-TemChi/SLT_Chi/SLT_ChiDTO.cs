using System;
using System.Collections.Generic;
using System.Text;

namespace Mapping.model_TemChi.SLT_Chi
{
    public class SLT_ChiDTO
    {
        public long id { get; set; }
        public DateTimeOffset Ngay_Cap_Phat { get; set; }
        public long? KDV_ID { get; set; }
        public long? Chi_ID { get; set; }
        public int? SoLuong { get; set; }
        public int? SoLuongChi { get; set; }
        public int? SoLuongChi_Huy { get; set; }
        public int? SoLuongChi_Ton { get; set; }
    }
}
