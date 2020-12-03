using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Tem_Chi
{
    public class TaiKhoan
    {
        public long id { get; set; }
        public string TenDayDu { get; set; }
        public string TenDangNhap { get; set; }
        public string MaKDV { get; set; }
        public string CMIS_User_ID { get; set; } 
        public int  LaQuanLy { get; set; }
        public string MatKhau { get; set; }
        public IList<QL_CaiDat_CTDienTu> QL_CaiDat_CTDienTus { get; set; }
        public IList<KDV_DayChi> KDV_DayChis { get; set; }
        public IList<KDV_Chi> KDV_Chis { get; set; }
        public IList<KDV_Tem> KDV_Tems { get; set; }
        public IList<NQL_Chi> NQL_Chis { get; set; }
        public IList<NQL_DayChi> NQL_DayChis { get; set; }
        public IList<NQL_Tem> NQL_Tems { get; set; }
        public IList<DangKy_TemChi> DangKy_TemChis { get; set; }
        public string NguoiCapNhat { get; set; }
        public DateTime TGian_CapNhat { get; set; }
    }
}
