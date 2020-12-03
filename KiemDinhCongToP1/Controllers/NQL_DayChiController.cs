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
using Mapping.model_TemChi.NQL_DayChi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KiemDinhCongTo_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NQL_DayChiController : ControllerBase
    {
        DBconnect _db;
        IMapper _mapper;
        public NQL_DayChiController(DBconnect db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<PagingQueryResult<NQL_DayChiDTO>> GetList([FromQuery] int skipCount, [FromQuery] int maxCount,
[FromQuery] string sortBy, [FromQuery] bool? ascSorting, [FromQuery] string thenSortBy,
[FromQuery] string keyWord)
        {
            IQueryable<NQL_DayChi> nQL_DayChis = _db.NQL_DayChis;
            if (!string.IsNullOrEmpty(keyWord))
            {
                //kDV_Chis = kDV_Chis.Where(p => p.KDV_ID.Contains(keyWord) || p.Serial.Contains(keyWord));
            }
            var result = new PagingQueryResult<NQL_DayChiDTO>();
            result.Total = nQL_DayChis.Count();
            IOrderedQueryable<NQL_DayChi> nQL_DayChis1;
            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = "Name";
            }
            if (maxCount <= 0)
            {
                maxCount = 50;
            }
            Expression<Func<NQL_DayChi, object>> property_exp = ExpressionHelper.GetProperty<NQL_DayChi>(sortBy);
            if (property_exp != null)
            {
                if (ascSorting ?? true)
                {
                    nQL_DayChis1 = nQL_DayChis.OrderBy(property_exp);
                }
                else
                {
                    nQL_DayChis1 = nQL_DayChis.OrderByDescending(property_exp);
                }

                if (!string.IsNullOrEmpty(thenSortBy))
                {
                    property_exp = ExpressionHelper.GetProperty<NQL_DayChi>(thenSortBy);
                    if (property_exp != null)
                    {
                        nQL_DayChis1 = nQL_DayChis1.ThenBy(property_exp);
                    }
                }
                nQL_DayChis = nQL_DayChis1;
            }
            nQL_DayChis = nQL_DayChis.Skip(skipCount).Take(maxCount);

            result.Items = await _mapper.ProjectTo<NQL_DayChiDTO>(nQL_DayChis).ToListAsync();
            return result;
        }

        [HttpPost("create")]
        public async Task<NQL_DayChiDTO> Create([FromBody] CreateNQL_DayChiDTO input)
        {
            if (ModelState.IsValid)
            {
                var entry = _mapper.Map<NQL_DayChi>(input);
                _db.NQL_DayChis.Add(entry);
                await _db.SaveChangesAsync();
                var result = _mapper.Map<NQL_DayChiDTO>(entry);
                return result;
            }
            throw new ArgumentException("1");

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<NQL_DayChiDTO> Update([FromRoute] long id, [FromBody] NQL_DayChiDTO input)
        {
            if (ModelState.IsValid)
            {
                var entry = _db.NQL_DayChis.FirstOrDefault(p => p.id == id);
                if (entry != null)
                {
                    _mapper.Map(input, entry);
                    await _db.SaveChangesAsync();
                    var result = _mapper.Map<NQL_DayChiDTO>(entry);
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
            var entry = _db.NQL_DayChis.FirstOrDefault(p => p.id == id);
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
        public async Task<NQL_DayChiDTO> GetDetail([FromRoute] long id)
        {
            var entry = _db.NQL_DayChis
                .FirstOrDefault(p => p.id == id);
            if (entry != null)
            {

                return _mapper.Map<NQL_DayChiDTO>(entry);

            }
            throw new Exception("1");
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<NQL_DayChiDTO>> GetAll()
        {
            return await _mapper.ProjectTo<NQL_DayChiDTO>(_db.NQL_DayChis).ToListAsync();
        }
    }
}
    

