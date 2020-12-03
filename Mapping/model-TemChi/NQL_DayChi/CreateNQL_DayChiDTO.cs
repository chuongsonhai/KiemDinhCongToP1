using System;
using System.Collections.Generic;
using System.Text;

namespace Mapping.model_TemChi.NQL_DayChi
{
    public class CreateNQL_DayChiDTO
    {
        public DateTimeOffset Ngay_Cap_Phat { get; set; }
        public long? KDV_ID { get; set; }
        public long? Daychi_ID { get; set; }
        public int? SoLuong { get; set; }
    }
}
