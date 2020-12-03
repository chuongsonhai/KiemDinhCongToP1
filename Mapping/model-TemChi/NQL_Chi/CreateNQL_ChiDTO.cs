using System;
using System.Collections.Generic;
using System.Text;

namespace Mapping.model_TemChi.NQL_Chi
{
    public class CreateNQL_ChiDTO
    {
        public DateTimeOffset Ngay_Cap_Phat { get; set; }
        public long? KDV_ID { get; set; }
        public long? Chi_ID { get; set; }
        public int? SoLuong { get; set; }

    }
}
