using System;
using System.Collections.Generic;
using System.Text;

namespace Mapping.model_TemChi.KDV_Chi
{
    public class CreateKDV_Chi
    {

        public DateTimeOffset Ngay_Su_Dung { get; set; }
        public long? KDV_ID { get; set; }
        public long? Chi_ID { get; set; }
        public int? SoLuongChi { get; set; }
        public int? SoLuongChi_Huy { get; set; }
    }
}
