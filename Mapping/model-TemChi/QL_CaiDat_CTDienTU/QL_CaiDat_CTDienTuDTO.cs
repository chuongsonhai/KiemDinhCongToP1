using System;
using System.Collections.Generic;
using System.Text;

namespace Mapping.model_TemChi.QL_CaiDat_CTDienTU
{
    public class QL_CaiDat_CTDienTuDTO
    {
        public long id { get; set; }
        public string DienLuc { get; set; }
        public string MaCongTo { get; set; }
        public DateTimeOffset Ngay_Cai { get; set; }
        public long? KDV_ID { get; set; }
        public string MaKDV_Name { get; set; }
        public long? NguoiCai { get; set; }
        public string NguoiCai_Name { get; set; }
        public string SoTem { get; set; }
        public string MaKim { get; set; }
        public int? SoLanCai { get; set; }
        public string GhiChu { get; set; }
    }
}
