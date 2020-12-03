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
using Mapping.model_TemChi.KDV_Chi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KiemDinhCongTo_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KDV_ChiController : ControllerBase
    {
        DBconnect _db;
        IMapper _mapper;
        public KDV_ChiController(DBconnect db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<PagingQueryResult<KDV_ChiDTO>> GetList([FromQuery] int skipCount, [FromQuery] int maxCount,
              [FromQuery] string sortBy, [FromQuery] bool? ascSorting, [FromQuery] string thenSortBy,
              [FromQuery] string keyWord)
        {
            IQueryable<KDV_Chi> kDV_Chis = _db.KDV_Chis;
            if (!string.IsNullOrEmpty(keyWord))
            {
                //kDV_Chis = kDV_Chis.Where(p => p.KDV_ID.Contains(keyWord) || p.Serial.Contains(keyWord));
            }
            var result = new PagingQueryResult<KDV_ChiDTO>();
            result.Total = kDV_Chis.Count();
            IOrderedQueryable<KDV_Chi> kDV_Chis1;
            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = "Name";
            }
            if (maxCount <= 0)
            {
                maxCount = 50;
            }
            Expression<Func<KDV_Chi, object>> property_exp = ExpressionHelper.GetProperty<KDV_Chi>(sortBy);
            if (property_exp != null)
            {
                if (ascSorting ?? true)
                {
                    kDV_Chis1 = kDV_Chis.OrderBy(property_exp);
                }
                else
                {
                    kDV_Chis1 = kDV_Chis.OrderByDescending(property_exp);
                }

                if (!string.IsNullOrEmpty(thenSortBy))
                {
                    property_exp = ExpressionHelper.GetProperty<KDV_Chi>(thenSortBy);
                    if (property_exp != null)
                    {
                        kDV_Chis1 = kDV_Chis1.ThenBy(property_exp);
                    }
                }
                kDV_Chis = kDV_Chis1;
            }
            kDV_Chis = kDV_Chis.Skip(skipCount).Take(maxCount);

            result.Items = await _mapper.ProjectTo<KDV_ChiDTO>(kDV_Chis).ToListAsync();
            return result;
        }

        [HttpPost("create")]
        public async Task<KDV_ChiDTO> Create([FromBody] CreateKDV_Chi input)
        {
            if (ModelState.IsValid)
            {
                var entry = _mapper.Map<KDV_Chi>(input);
                _db.KDV_Chis.Add(entry);
                await _db.SaveChangesAsync();
                var result = _mapper.Map<KDV_ChiDTO>(entry);
                return result;
            }
            throw new ArgumentException("Du lieu ko hop le");

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<KDV_ChiDTO> Update([FromRoute] long id, [FromBody] KDV_ChiDTO input)
        {
            if (ModelState.IsValid)
            {
                var entry = _db.KDV_Chis.FirstOrDefault(p => p.id == id);
                if (entry != null)
                {
                    _mapper.Map(input, entry);
                    await _db.SaveChangesAsync();
                    var result = _mapper.Map<KDV_ChiDTO>(entry);
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
            var entry = _db.KDV_Chis.FirstOrDefault(p => p.id == id);
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
        public async Task<KDV_ChiDTO> GetDetail([FromRoute] long id)
        {
            var entry = _db.KDV_Chis
                .FirstOrDefault(p => p.id == id);
            if (entry != null)
            {

                return _mapper.Map<KDV_ChiDTO>(entry);

            }
            throw new Exception("not found");
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<KDV_ChiDTO>> GetAll()
        {
            return await _mapper.ProjectTo<KDV_ChiDTO>(_db.KDV_Chis).ToListAsync();
        }
    }
}
