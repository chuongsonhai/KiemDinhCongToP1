using System;
using System.Collections.Generic;
using System.Text;

namespace Mapping.model_TemChi.NQL_Chi
{
     public class NQL_ChiDTO
    {
        public long id { get; set; }
        public DateTimeOffset Ngay_Cap_Phat { get; set; }
        public long? KDV_ID { get; set; }
        public string TenKDV_name { get; set; }
        public long? NQL_ID { get; set; }
        public long? Chi_ID { get; set; }
        public string LoaiChi_name { get; set; }
        public int? SoLuong { get; set; }

    }
}
