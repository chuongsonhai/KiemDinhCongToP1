using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Tem_Chi
{
    public class DangKy_TemChi
    {
        public long id { get; set; }
        public long? id_NguoiDKy { get; set; }
        public TaiKhoan TaiKhoan { get; set; }
        public int? nam { get; set; }
        public string Ten_DKy { get; set; }
        public int? SoLuong_Dky { get; set; }
        public long? Id_NguoiDuyet { get; set; }
       
        public int? TrangThaiDuyet { get; set; }
        public int? CapDuyet { get; set; }
        public DateTime ThoiGianDuyet { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string NguoiCapNhat { get; set; }

    }
}
