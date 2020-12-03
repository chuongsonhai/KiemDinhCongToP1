using System;
using System.Collections.Generic;
using System.Text;

namespace Mapping.model_TemChi.KDV_DayChi
{
    public class CreateKDV_DayChi
    {

        public DateTimeOffset Ngay_Su_Dung { get; set; }
        public long? KDV_ID { get; set; }
        public int? SoLuong { get; set; }
        public long? Daychi_ID { get; set; }
        public string LoaiDayChi_Huy { get; set; }
        public int? SoLuong_Huy { get; set; }
    }
}
