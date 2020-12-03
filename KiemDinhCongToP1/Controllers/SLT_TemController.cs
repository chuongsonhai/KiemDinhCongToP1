using AutoMapper;
using constraint;
using Constraint;
using EntityFramework;
using EntityFramework.Tem_Chi;
using Mapping.model_TemChi.SLT_Tem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KiemDinhCongTo_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SLT_TemController : ControllerBase
    {
        DBconnect _db;
        IMapper _mapper;
        public SLT_TemController(DBconnect db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<PagingQueryResult<SLT_TemDTO>> GetList([FromQuery] int skipCount, [FromQuery] int maxCount, [FromQuery] DateTime Date)
        {
            //IOrderedQueryable<SLT_Chi> sLT_Chis1;
            //IQueryable<SLT_Chi> sLT_Chis = _db.SLT_Chis;
            var pickedDate = Date.ToString("yyyy-MM-dd");


            var slt_Tem = await (from NQL_Tem in _db.NQL_Tems
                                    join kdv in _db.KDV_Tems on new { NQL_Tem.KDV_ID, NQL_Tem.Tem_ID } equals new { kdv.KDV_ID, kdv.Tem_ID }
                                    where NQL_Tem.Ngay_Cap_Phat.Date.ToString() == pickedDate
                                    select new SLT_TemDTO
                                    {
                                        Ngay_Cap_Phat = NQL_Tem.Ngay_Cap_Phat,
                                        KDV_ID = NQL_Tem.KDV_ID,
                                        Tem_ID = NQL_Tem.Tem_ID,
                                        SoLuong = NQL_Tem.SoLuong,
                                        SoLuongTem = kdv.SoLuongTem,
                                        SoLuongTem_Huy = kdv.SoLuongTem_Huy
                                    }).ToListAsync();

            //sLT_Chis = _db.SLT_Chis.Where(p => p.Ngay_Cap_Phat.Date == Date);

            var result = new PagingQueryResult<SLT_TemDTO>();
            result.Total = slt_Tem.Count();


            //sLT_Chis = sLT_Chis.Skip(skipCount).Take(maxCount);

            result.Items = slt_Tem; // await _mapper.ProjectTo<SLT_ChiDTO>(sLT_Chis).ToListAsync();

            foreach (SLT_TemDTO item in result.Items)
            {
                item.SoLuongTem_Ton = item.SoLuong - item.SoLuongTem;
            }
            return result;
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<SLT_TemDTO>> GetAll()
        {
            return await _mapper.ProjectTo<SLT_TemDTO>(_db.SLT_Tems).ToListAsync();
        }
    }
}