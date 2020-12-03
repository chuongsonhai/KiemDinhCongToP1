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
using Mapping.model_TemChi.NQL_Chi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KiemDinhCongTo_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NQL_ChiController : ControllerBase
    {
        DBconnect _db;
        IMapper _mapper;
        public NQL_ChiController(DBconnect db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<PagingQueryResult<NQL_ChiDTO>> GetList([FromQuery] int skipCount, [FromQuery] int maxCount,
[FromQuery] string sortBy, [FromQuery] bool? ascSorting, [FromQuery] string thenSortBy,
[FromQuery] string keyWord)
        {
            IQueryable<NQL_Chi> nQL_Chis = _db.NQL_Chis;
            if (!string.IsNullOrEmpty(keyWord))
            {
                //kDV_Chis = kDV_Chis.Where(p => p.KDV_ID.Contains(keyWord) || p.Serial.Contains(keyWord));
            }
            var result = new PagingQueryResult<NQL_ChiDTO>();
            result.Total = nQL_Chis.Count();
            IOrderedQueryable<NQL_Chi> nQL_Chis1;
            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = "Name";
            }
            if (maxCount <= 0)
            {
                maxCount = 50;
            }
            Expression<Func<NQL_Chi, object>> property_exp = ExpressionHelper.GetProperty<NQL_Chi>(sortBy);
            if (property_exp != null)
            {
                if (ascSorting ?? true)
                {
                    nQL_Chis1 = nQL_Chis.OrderBy(property_exp);
                }
                else
                {
                    nQL_Chis1 = nQL_Chis.OrderByDescending(property_exp);
                }

                if (!string.IsNullOrEmpty(thenSortBy))
                {
                    property_exp = ExpressionHelper.GetProperty<NQL_Chi>(thenSortBy);
                    if (property_exp != null)
                    {
                        nQL_Chis1 = nQL_Chis1.ThenBy(property_exp);
                    }
                }
                nQL_Chis = nQL_Chis1;
            }
            nQL_Chis = nQL_Chis.Skip(skipCount).Take(maxCount);

            result.Items = await _mapper.ProjectTo<NQL_ChiDTO>(nQL_Chis).ToListAsync();
            return result;
        }

        [HttpPost("create")]
        public async Task<NQL_ChiDTO> Create([FromBody] CreateNQL_ChiDTO input)
        {
            if (ModelState.IsValid)
            {
                var entry = _mapper.Map<NQL_Chi>(input);
                _db.NQL_Chis.Add(entry);
                await _db.SaveChangesAsync();
                var result = _mapper.Map<NQL_ChiDTO>(entry);
                return result;
            }
            throw new ArgumentException("1");

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<NQL_ChiDTO> Update([FromRoute] long id, [FromBody] NQL_ChiDTO input)
        {
            if (ModelState.IsValid)
            {
                var entry = _db.NQL_Chis.FirstOrDefault(p => p.id == id);
                if (entry != null)
                {
                    _mapper.Map(input, entry);
                    await _db.SaveChangesAsync();
                    var result = _mapper.Map<NQL_ChiDTO>(entry);
                    return result;
                }
                throw new Exception("not found");
            }
            throw new ArgumentException("1");

        }
        [HttpDelete]
        [Route("{id}")]
        public async Task Delete([FromRoute] long id)
        {
            var entry = _db.NQL_Chis.FirstOrDefault(p => p.id == id);
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
        public async Task<NQL_ChiDTO> GetDetail([FromRoute] long id)
        {
            var entry = _db.NQL_Chis
                .FirstOrDefault(p => p.id == id);
            if (entry != null)
            {

                return _mapper.Map<NQL_ChiDTO>(entry);

            }
            throw new Exception("not found");
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<NQL_ChiDTO>> GetAll()
        {
            return await _mapper.ProjectTo<NQL_ChiDTO>(_db.NQL_Chis).ToListAsync();
        }
    }
}

   
