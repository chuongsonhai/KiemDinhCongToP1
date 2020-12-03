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
using Mapping.model_TemChi.SLT_Chi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KiemDinhCongTo_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SLT_ChiController : ControllerBase
    {
        DBconnect _db;
        IMapper _mapper;
        public SLT_ChiController(DBconnect db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<PagingQueryResult<SLT_ChiDTO>> GetList([FromQuery] int skipCount, [FromQuery] int maxCount, [FromQuery] DateTime Date)
        {
            //IOrderedQueryable<SLT_Chi> sLT_Chis1;
            //IQueryable<SLT_Chi> sLT_Chis = _db.SLT_Chis;
            var pickedDate = Date.ToString("yyyy-MM-dd");


            var sLT_Chis = await (from NQL_Chi in _db.NQL_Chis
                                  join kdv in _db.KDV_Chis on new { NQL_Chi.KDV_ID, NQL_Chi.Chi_ID } equals new { kdv.KDV_ID, kdv.Chi_ID }
                                  where NQL_Chi.Ngay_Cap_Phat.Date.ToString() == pickedDate
                                  select new SLT_ChiDTO
                                  {
                                      Ngay_Cap_Phat = NQL_Chi.Ngay_Cap_Phat,
                                      KDV_ID = NQL_Chi.KDV_ID,
                                      Chi_ID = NQL_Chi.Chi_ID,
                                      SoLuong = NQL_Chi.SoLuong,
                                      SoLuongChi = kdv.SoLuongChi,
                                      SoLuongChi_Huy = kdv.SoLuongChi_Huy
                                  }).ToListAsync();

            //sLT_Chis = _db.SLT_Chis.Where(p => p.Ngay_Cap_Phat.Date == Date);

            var result = new PagingQueryResult<SLT_ChiDTO>();
            result.Total = sLT_Chis.Count();


            //sLT_Chis = sLT_Chis.Skip(skipCount).Take(maxCount);

            result.Items = sLT_Chis; // await _mapper.ProjectTo<SLT_ChiDTO>(sLT_Chis).ToListAsync();

            foreach (SLT_ChiDTO item in result.Items)
            {
                item.SoLuongChi_Ton = item.SoLuong - item.SoLuongChi;
            }
            return result;
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<SLT_ChiDTO>> GetAll()
        {
            return await _mapper.ProjectTo<SLT_ChiDTO>(_db.SLT_Chis).ToListAsync();
        }
    }
}