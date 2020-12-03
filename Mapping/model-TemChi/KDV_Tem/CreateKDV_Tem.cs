using System;
using System.Collections.Generic;
using System.Text;

namespace Mapping.model_TemChi.KDV_Tem
{
    public class CreateKDV_Tem
    {
        public DateTimeOffset Ngay_Su_Dung { get; set; }
        public int? SoLuong { get; set; }
        public long? KDV_ID { get; set; }
        public long? Tem_ID { get; set; }
        public string Seri_Dau { get; set; }
        public string Seri_Cuoi { get; set; }
        public int? SoLuong_Huy { get; set; }
        public string Seri_Tem_Huy { get; set; }
    }
}
