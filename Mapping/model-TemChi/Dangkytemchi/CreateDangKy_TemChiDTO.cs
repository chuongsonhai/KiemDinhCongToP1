using System;
using System.Collections.Generic;
using System.Text;

namespace Mapping.model_TemChi.Dangkytemchi
{
   public class CreateDangKy_TemChiDTO
    {
        public long? id_NguoiDKy { get; set; }
        public int? nam { get; set; }
        public string Ten_DKy { get; set; }
        public int? SoLuong_Dky { get; set; }
        public long? Id_NguoiDuyet { get; set; }
        public int? TrangThaiDuyet { get; set; }
        public int? CapDuyet { get; set; }
        public DateTime ThoiGianDuyet { get; set; }
    }
}
