using System;
using System.Collections.Generic;
using System.Text;

namespace Mapping.model_TemChi.SLT_DayChi
{
    public class CreateSLT_DayChiDTO
    {
        public DateTimeOffset Ngay_Cap_Phat { get; set; }
        public long? Daychi_ID { get; set; }
        public int? SoLuongDayChi { get; set; }
        public int? SoLuongDayChi_Huy { get; set; }
        public int? SoLuongDayChi_Ton { get; set; }
    }
}
