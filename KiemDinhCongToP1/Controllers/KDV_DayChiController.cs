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
using Mapping.model_TemChi.KDV_DayChi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KiemDinhCongTo_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KDV_DayChiController : ControllerBase
    {
        DBconnect _db;
        IMapper _mapper;
        public KDV_DayChiController(DBconnect db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
             [HttpGet]
        public async Task<PagingQueryResult<KDV_DayChiDTO>> GetList([FromQuery] int skipCount, [FromQuery] int maxCount,
              [FromQuery] string sortBy, [FromQuery] bool? ascSorting, [FromQuery] string thenSortBy,
              [FromQuery] string keyWord)
        {
            IQueryable<KDV_DayChi> kDV_DayChis = _db.KDV_DayChis;
            if (!string.IsNullOrEmpty(keyWord))
            {
                //kDV_Chis = kDV_Chis.Where(p => p.KDV_ID.Contains(keyWord) || p.Serial.Contains(keyWord));
            }
            var result = new PagingQueryResult<KDV_DayChiDTO>();
            result.Total = kDV_DayChis.Count();
            IOrderedQueryable<KDV_DayChi> kDV_DayChis1;
            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = "Name";
            }
            if (maxCount <= 0)
            {
                maxCount = 50;
            }
            Expression<Func<KDV_DayChi, object>> property_exp = ExpressionHelper.GetProperty<KDV_DayChi>(sortBy);
            if (property_exp != null)
            {
                if (ascSorting ?? true)
                {
                    kDV_DayChis1 = kDV_DayChis.OrderBy(property_exp);
                }
                else
                {
                    kDV_DayChis1 = kDV_DayChis.OrderByDescending(property_exp);
                }

                if (!string.IsNullOrEmpty(thenSortBy))
                {
                    property_exp = ExpressionHelper.GetProperty<KDV_DayChi>(thenSortBy);
                    if (property_exp != null)
                    {
                        kDV_DayChis1 = kDV_DayChis1.ThenBy(property_exp);
                    }
                }
                kDV_DayChis = kDV_DayChis1;
            }
            kDV_DayChis = kDV_DayChis.Skip(skipCount).Take(maxCount);

            result.Items = await _mapper.ProjectTo<KDV_DayChiDTO>(kDV_DayChis).ToListAsync();
            return result;
        }

        [HttpPost("create")]
        public async Task<KDV_DayChiDTO> Create([FromBody] CreateKDV_DayChi input)
        {
            if (ModelState.IsValid)
            {
                var entry = _mapper.Map<KDV_DayChi>(input);
                _db.KDV_DayChis.Add(entry);
                await _db.SaveChangesAsync();
                var result = _mapper.Map<KDV_DayChiDTO>(entry);
                return result;
            }
            throw new ArgumentException("Du lieu ko hop le");

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<KDV_DayChiDTO> Update([FromRoute] long id, [FromBody] KDV_DayChiDTO input)
        {
            if (ModelState.IsValid)
            {
                var entry = _db.KDV_DayChis.FirstOrDefault(p => p.id == id);
                if (entry != null)
                {
                    _mapper.Map(input, entry);
                    await _db.SaveChangesAsync();
                    var result = _mapper.Map<KDV_DayChiDTO>(entry);
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
            var entry = _db.KDV_DayChis.FirstOrDefault(p => p.id == id);
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
        public async Task<KDV_DayChiDTO> GetDetail([FromRoute] long id)
        {
            var entry = _db.KDV_DayChis
                .FirstOrDefault(p => p.id == id);
            if (entry != null)
            {

                return _mapper.Map<KDV_DayChiDTO>(entry);

            }
            throw new Exception("not found");
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<KDV_DayChiDTO>> GetAll()
        {
            return await _mapper.ProjectTo<KDV_DayChiDTO>(_db.KDV_DayChis).ToListAsync();
        }
    }
}
