using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Tem_Chi
{
    public class DM_Tem
    {
        public long id { get; set; }
        public IList<KDV_Tem> KDV_Tems { get; set; }
        public IList<NQL_Tem> NQL_Tems { get; set; }
        public IList<SLT_Tem> SLT_Tems { get; set; }
        public string Ma_Tem { get; set; }
        public string Loai_Tem { get; set; }
        public string NguoiCapNhat { get; set; }
        public DateTime TGian_CapNhat { get; set; }
    }
}
