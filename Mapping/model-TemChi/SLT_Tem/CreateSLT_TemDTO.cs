using System;
using System.Collections.Generic;
using System.Text;

namespace Mapping.model_TemChi.SLT_Tem
{
    public class CreateSLT_TemDTO
    {
        public DateTimeOffset Ngay_Cap_Phat { get; set; }
        public long? Tem_ID { get; set; }
        public int? SoLuongTem { get; set; }
        public int? SoLuongTem_Huy { get; set; }
        public int? SoLuongTem_Ton { get; set; }
    }
}
