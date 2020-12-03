using System;
using System.Collections.Generic;
using System.Text;

namespace Mapping.model_TemChi.SLT_Chi
{
    public class CreateSLT_ChiDTO
    {
        public DateTimeOffset Ngay_Cap_Phat { get; set; }
        public long? Chi_ID { get; set; }
        public int? SoLuongChi { get; set; }
        public int? SoLuongChi_Huy { get; set; }
        public int? SoLuongChi_Ton { get; set; }
    }
}
