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
using Mapping.model_TemChi.DM_DayChi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KiemDinhCongTo_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DM_DayChiController : ControllerBase
    {
        DBconnect _db;
        IMapper _mapper;
        public DM_DayChiController(DBconnect db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<PagingQueryResult<DM_DayChiDTO>> GetList([FromQuery] int skipCount, [FromQuery] int maxCount,
                [FromQuery] string sortBy, [FromQuery] bool? ascSorting, [FromQuery] string thenSortBy,
                [FromQuery] string keyWord)
        {
            IQueryable<DM_DayChi> dM_DayChis = _db.DM_DayChis;
            if (!string.IsNullOrEmpty(keyWord))
            {
                dM_DayChis = dM_DayChis.Where(p => p.Loai_DayChi.Contains(keyWord));
            }
            var result = new PagingQueryResult<DM_DayChiDTO>();
            result.Total = dM_DayChis.Count();
            IOrderedQueryable<DM_DayChi> dM_DayChis1;
            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = "Loai_Chi";
            }
            if (maxCount <= 0)
            {
                maxCount = 50;
            }
            Expression<Func<DM_DayChi, object>> property_exp = ExpressionHelper.GetProperty<DM_DayChi>(sortBy);
            if (property_exp != null)
            {
                if (ascSorting ?? true)
                {
                    dM_DayChis1 = dM_DayChis.OrderBy(property_exp);

                }
                else
                {
                    dM_DayChis1 = dM_DayChis.OrderByDescending(property_exp);
                }

                if (!string.IsNullOrEmpty(thenSortBy))
                {
                    property_exp = ExpressionHelper.GetProperty<DM_DayChi>(thenSortBy);
                    if (property_exp != null)
                    {
                        dM_DayChis1 = dM_DayChis1.ThenBy(property_exp);
                    }
                }
                dM_DayChis = dM_DayChis1;
            }
            dM_DayChis = dM_DayChis.Skip(skipCount).Take(maxCount);

            result.Items = await _mapper.ProjectTo<DM_DayChiDTO>(dM_DayChis).ToListAsync();
            return result;
        }

        [HttpPost]
        public async Task<DM_DayChiDTO> Create([FromBody] CreateDM_DayChi input)
        {
            if (ModelState.IsValid)
            {
                var entry = _mapper.Map<DM_DayChi>(input);
                _db.DM_DayChis.Add(entry);
                await _db.SaveChangesAsync();
                var result = _mapper.Map<DM_DayChiDTO>(entry);
                return result;
            }
            throw new ArgumentException("Du lieu ko hop le");

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<DM_DayChiDTO> Update([FromRoute] long id, [FromBody] DM_DayChiDTO input)
        {
            if (ModelState.IsValid)
            {
                var entry = _db.DM_DayChis.FirstOrDefault(p => p.id == id);
                if (entry != null)
                {
                    _mapper.Map(input, entry);
                    await _db.SaveChangesAsync();
                    var result = _mapper.Map<DM_DayChiDTO>(entry);
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
            var entry = _db.DM_DayChis.FirstOrDefault(p => p.id == id);
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
        public async Task<DM_DayChiDTO> GetDetail([FromRoute] long id)
        {
            var entry = _db.DM_DayChis
                .FirstOrDefault(p => p.id == id);
            if (entry != null)
            {

                return _mapper.Map<DM_DayChiDTO>(entry);

            }
            throw new Exception("not found");
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<DM_DayChiDTO>> GetAll()
        {
            return await _mapper.ProjectTo<DM_DayChiDTO>(_db.DM_DayChis).ToListAsync();
        }
    }
}
