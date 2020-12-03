using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Tem_Chi
{
    public class DM_Chi
    {
        public long id { get; set; }
        public IList<KDV_Chi> KDV_Chis { get; set; }
        public IList<NQL_Chi> NQL_Chis { get; set; }
        public IList<SLT_Chi> SLT_Chis { get; set; }
        public string Ma_Chi { get; set; }
        public string Loai_Chi { get; set; }
        public string NguoiCapNhat { get; set; }
        public DateTime TGian_CapNhat { get; set; }
    }
}
