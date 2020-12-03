using System;
using System.Collections.Generic;
using System.Text;

namespace Mapping.model_TemChi.KDV_Chi
{
    public class KDV_ChiDTO
    {
        public long id { get; set; }
        public DateTimeOffset Ngay_Su_Dung { get; set; }
        public long? KDV_ID { get; set; }
        public string TenKDV_name { get; set; }
        public long? Chi_ID { get; set; }
        public string LoaiChi_name { get; set; }
        public int? SoLuongChi { get; set; }
        public int? SoLuongChi_Huy { get; set; }
    }
}
