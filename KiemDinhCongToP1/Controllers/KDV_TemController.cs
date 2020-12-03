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
using Mapping.model_TemChi.KDV_Tem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KiemDinhCongTo_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KDV_TemController : ControllerBase
    {
        DBconnect _db;
        IMapper _mapper;
        public KDV_TemController(DBconnect db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<PagingQueryResult<KDV_TemDTO>> GetList([FromQuery] int skipCount, [FromQuery] int maxCount,
    [FromQuery] string sortBy, [FromQuery] bool? ascSorting, [FromQuery] string thenSortBy,
    [FromQuery] string keyWord)
        {
            IQueryable<KDV_Tem> kDV_Tems = _db.KDV_Tems;
            if (!string.IsNullOrEmpty(keyWord))
            {
                //kDV_Chis = kDV_Chis.Where(p => p.KDV_ID.Contains(keyWord) || p.Serial.Contains(keyWord));
            }
            var result = new PagingQueryResult<KDV_TemDTO>();
            result.Total = kDV_Tems.Count();
            IOrderedQueryable<KDV_Tem> kDV_Tems1;
            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = "Name";
            }
            if (maxCount <= 0)
            {
                maxCount = 50;
            }
            Expression<Func<KDV_Tem, object>> property_exp = ExpressionHelper.GetProperty<KDV_Tem>(sortBy);
            if (property_exp != null)
            {
                if (ascSorting ?? true)
                {
                    kDV_Tems1 = kDV_Tems.OrderBy(property_exp);
                }
                else
                {
                    kDV_Tems1 = kDV_Tems.OrderByDescending(property_exp);
                }

                if (!string.IsNullOrEmpty(thenSortBy))
                {
                    property_exp = ExpressionHelper.GetProperty<KDV_Tem>(thenSortBy);
                    if (property_exp != null)
                    {
                        kDV_Tems1 = kDV_Tems1.ThenBy(property_exp);
                    }
                }
                kDV_Tems = kDV_Tems1;
            }
            kDV_Tems = kDV_Tems.Skip(skipCount).Take(maxCount);

            result.Items = await _mapper.ProjectTo<KDV_TemDTO>(kDV_Tems).ToListAsync();
            return result;
        }

        [HttpPost("create")]
        public async Task<KDV_TemDTO> Create([FromBody] CreateKDV_Tem input)
        {
            if (ModelState.IsValid)
            {
                var entry = _mapper.Map<KDV_Tem>(input);
                _db.KDV_Tems.Add(entry);
                await _db.SaveChangesAsync();
                var result = _mapper.Map<KDV_TemDTO>(entry);
                return result;
            }
            throw new ArgumentException("Du lieu ko hop le");

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<KDV_TemDTO> Update([FromRoute] long id, [FromBody] KDV_TemDTO input)
        {
            if (ModelState.IsValid)
            {
                var entry = _db.KDV_Tems.FirstOrDefault(p => p.id == id);
                if (entry != null)
                {
                    _mapper.Map(input, entry);
                    await _db.SaveChangesAsync();
                    var result = _mapper.Map<KDV_TemDTO>(entry);
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
            var entry = _db.KDV_Tems.FirstOrDefault(p => p.id == id);
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
        public async Task<KDV_TemDTO> GetDetail([FromRoute] long id)
        {
            var entry = _db.KDV_Tems
                .FirstOrDefault(p => p.id == id);
            if (entry != null)
            {

                return _mapper.Map<KDV_TemDTO>(entry);

            }
            throw new Exception("not found");
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<KDV_TemDTO>> GetAll()
        {
            return await _mapper.ProjectTo<KDV_TemDTO>(_db.KDV_Tems).ToListAsync();
        }
    }
}
