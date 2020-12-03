using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using constraint;
using Constraint;
using EntityFramework;
using EntityFramework.Tem_Chi;

using Mapping.model_TemChi.SLT_DayChi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KiemDinhCongTo_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SLT_DayChiController : ControllerBase
    {
        DBconnect _db;
        IMapper _mapper;
        public SLT_DayChiController(DBconnect db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<PagingQueryResult<SLT_DayChiDTO>> GetList([FromQuery] int skipCount, [FromQuery] int maxCount, [FromQuery] DateTime Date)
        {
            var pickedDate = Date.ToString("yyyy-MM-dd");


            var slt_DayChi = await (from NQL_DayChi in _db.NQL_DayChis
                                  join kdv in _db.KDV_DayChis on new { NQL_DayChi.KDV_ID, NQL_DayChi.Daychi_ID } equals new { kdv.KDV_ID, kdv.Daychi_ID }
                                  where NQL_DayChi.Ngay_Cap_Phat.Date.ToString() == pickedDate
                                  select new SLT_DayChiDTO
                                  {
                                      Ngay_Cap_Phat = NQL_DayChi.Ngay_Cap_Phat,
                                      KDV_ID = NQL_DayChi.KDV_ID,
                                      Daychi_ID = NQL_DayChi.Daychi_ID,
                                      SoLuong = NQL_DayChi.SoLuong,
                                      SoLuongDayChi = kdv.SoLuongDayChi,
                                      SoLuongDayChi_Huy = kdv.SoLuongDayChi_Huy
                                  }).ToListAsync();

      
            var result = new PagingQueryResult<SLT_DayChiDTO>();
            result.Total = slt_DayChi.Count();


        

            result.Items = slt_DayChi; 

            foreach (SLT_DayChiDTO item in result.Items)
            {
                item.SoLuongDayChi_Ton = item.SoLuong - item.SoLuongDayChi;
            }
            return result;
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<SLT_DayChiDTO>> GetAll()
        {
            return await _mapper.ProjectTo<SLT_DayChiDTO>(_db.SLT_DayChis).ToListAsync();
        }
    }
}