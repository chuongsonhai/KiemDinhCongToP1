using AutoMapper;
using constraint;
using Constraint;
using EntityFramework;
using EntityFramework.Tem_Chi;
using Mapping.model_TemChi.Dangkytemchi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KiemDinhCongToP1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DangKy_TemChiController : ControllerBase
    {
        DBconnect _db;
        IMapper _mapper;
        public DangKy_TemChiController(DBconnect db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<PagingQueryResult<DangKy_TemChiDTO>> GetList([FromQuery] int skipCount, [FromQuery] int maxCount,
         [FromQuery] string sortBy, [FromQuery] bool? ascSorting, [FromQuery] string thenSortBy,
         [FromQuery] string keyWord)
        {
            IQueryable<DangKy_TemChi> dangKy_TemChis = _db.DangKy_TemChis;
            if (!string.IsNullOrEmpty(keyWord))
            {
                //kDV_Chis = kDV_Chis.Where(p => p.KDV_ID.Contains(keyWord) || p.Serial.Contains(keyWord));
            }
            var result = new PagingQueryResult<DangKy_TemChiDTO>();
            result.Total = dangKy_TemChis.Count();
            IOrderedQueryable<DangKy_TemChi> dangKy_TemChis1;
            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = "Name";
            }
            if (maxCount <= 0)
            {
                maxCount = 50;
            }
            Expression<Func<DangKy_TemChi, object>> property_exp = ExpressionHelper.GetProperty<DangKy_TemChi>(sortBy);
            if (property_exp != null)
            {
                if (ascSorting ?? true)
                {
                    dangKy_TemChis1 = dangKy_TemChis.OrderBy(property_exp);
                }
                else
                {
                    dangKy_TemChis1 = dangKy_TemChis.OrderByDescending(property_exp);
                }

                if (!string.IsNullOrEmpty(thenSortBy))
                {
                    property_exp = ExpressionHelper.GetProperty<DangKy_TemChi>(thenSortBy);
                    if (property_exp != null)
                    {
                        dangKy_TemChis1 = dangKy_TemChis1.ThenBy(property_exp);
                    }
                }
                dangKy_TemChis = dangKy_TemChis1;
            }
            dangKy_TemChis = dangKy_TemChis.Skip(skipCount).Take(maxCount);

            result.Items = await _mapper.ProjectTo<DangKy_TemChiDTO>(dangKy_TemChis).ToListAsync();
            return result;
        }

        [HttpPost("create")]
        public async Task<DangKy_TemChiDTO> Create([FromBody] CreateDangKy_TemChiDTO input)
        {
            if (ModelState.IsValid)
            {
                var entry = _mapper.Map<DangKy_TemChi>(input);
                _db.DangKy_TemChis.Add(entry);
                await _db.SaveChangesAsync();
                var result = _mapper.Map<DangKy_TemChiDTO>(entry);
                return result;
            }
            throw new ArgumentException("Du lieu ko hop le");

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<DangKy_TemChiDTO> Update([FromRoute] long id, [FromBody] DangKy_TemChiDTO input)
        {
            if (ModelState.IsValid)
            {
                var entry = _db.DangKy_TemChis.FirstOrDefault(p => p.id == id);
                if (entry != null)
                {
                    _mapper.Map(input, entry);
                    await _db.SaveChangesAsync();
                    var result = _mapper.Map<DangKy_TemChiDTO>(entry);
                    return result;
                }
                throw new Exception("not found");
            }
            throw new ArgumentException("Du lieu ko hop le");

        }
        [HttpDelete]
        [Route("{id}")]
        public async Task Delete([FromRoute] long id)
        {
            var entry = _db.DangKy_TemChis.FirstOrDefault(p => p.id == id);
            if (entry != null)
            {
                _db.Remove(entry);
                await _db.SaveChangesAsync();
                return;

            }
            throw new Exception("not found");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<DangKy_TemChiDTO> GetDetail([FromRoute] long id)
        {
            var entry = _db.DangKy_TemChis
                .FirstOrDefault(p => p.id == id);
            if (entry != null)
            {

                return _mapper.Map<DangKy_TemChiDTO>(entry);

            }
            throw new Exception("not found");
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<DangKy_TemChiDTO>> GetAll()
        {
            return await _mapper.ProjectTo<DangKy_TemChiDTO>(_db.DangKy_TemChis).ToListAsync();
        }
    }
}

