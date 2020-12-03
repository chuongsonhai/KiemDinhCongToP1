﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Tem_Chi
{
   public class NQL_DayChi
    {
        public long id { get; set; }
        public DateTimeOffset Ngay_Cap_Phat { get; set; }
        public long? KDV_ID { get; set; }
        public TaiKhoan TaiKhoan { get; set; }
        public long? Daychi_ID { get; set; }
        public DM_DayChi DM_DayChi { get; set; }
        public long? NQL_ID { get; set; }

        //
        public int? SoLuong { get; set; }
        public string NguoiCapNhat { get; set; }
        public DateTime TGian_CapNhat { get; set; }
    }
}
