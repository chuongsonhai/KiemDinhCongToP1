using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Tem_Chi
{
    public class DM_DayChi
    {
        public long id { get; set; }
        public IList<KDV_DayChi> KDV_DayChis { get; set; }
        public IList<NQL_DayChi> NQL_DayChis { get; set; }
        public IList<SLT_DayChi> SLT_DayChis { get; set; }
        public string Ma_DayChi { get; set; }
        public string Loai_DayChi { get; set; }
        public string NguoiCapNhat { get; set; }
        public DateTime TGian_CapNhat { get; set; }
    }
}
