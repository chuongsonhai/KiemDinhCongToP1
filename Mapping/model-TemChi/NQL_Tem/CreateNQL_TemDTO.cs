using System;
using System.Collections.Generic;
using System.Text;

namespace Mapping.model_TemChi.NQL_Tem
{
    public class CreateNQL_TemDTO
    {
        public DateTimeOffset Ngay_Cap_Phat { get; set; }
        public long? KDV_ID { get; set; }
        public long? Tem_ID { get; set; }
        public int? SoLuong { get; set; }
        public string Seri_Dau { get; set; }
        public string Seri_Cuoi { get; set; }
    }
}
