using System;
using System.Collections.Generic;
using System.Text;

namespace Mapping.model_TemChi.NQL_DayChi
{
    public class NQL_DayChiDTO
    {
        public long id { get; set; }
        public DateTimeOffset Ngay_Cap_Phat { get; set; }
        public long? KDV_ID { get; set; }
        public string TenKDV_name { get; set; }
        public long? NQL_ID { get; set; }
        public long? Daychi_ID { get; set; }
        public string LoaiDayChi_name { get; set; }
        public int? SoLuong { get; set; }
    }
}
