using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Tem_Chi
{
      public class QL_CaiDat_CTDienTu
    {
        public long id { get; set; }
        public string DienLuc { get; set; }
        public string MaCongTo { get; set; }
        public DateTimeOffset Ngay_Cai { get; set; }
        public long? KDV_ID { get; set; }
        public TaiKhoan TaiKhoan { get; set; }
        public long? NguoiCai { get; set; }
        public TaiKhoan TaiKhoans { get; set; }
        public string  SoTem { get; set; }
        public string MaKim { get; set; }
        public int? SoLanCai { get; set; }
        public string GhiChu { get; set; }

    }
}
