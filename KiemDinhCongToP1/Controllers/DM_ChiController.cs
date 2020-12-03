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
using Mapping.model_TemChi.DM_Chi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KiemDinhCongTo_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DM_ChiController : ControllerBase
    {
        DBconnect _db;
        IMapper _mapper;
        public DM_ChiController(DBconnect db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<PagingQueryResult<DM_ChiDTO>> GetList([FromQuery] int skipCount, [FromQuery] int maxCount,
                  [FromQuery] string sortBy, [FromQuery] bool? ascSorting, [FromQuery] string thenSortBy,
                  [FromQuery] string keyWord)
        {
            IQueryable<DM_Chi> dM_Chis = _db.DM_Chis;
            if (!string.IsNullOrEmpty(keyWord))
            {
                dM_Chis = dM_Chis.Where(p => p.Loai_Chi.Contains(keyWord));
            }
            var result = new PagingQueryResult<DM_ChiDTO>();
            result.Total = dM_Chis.Count();
            IOrderedQueryable<DM_Chi> dM_Chis1;
            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = "Loai_Chi";
            }
            if (maxCount <= 0)
            {
                maxCount = 50;
            }
            Expression<Func<DM_Chi, object>> property_exp = ExpressionHelper.GetProperty<DM_Chi>(sortBy);
            if (property_exp != null)
            {
                if (ascSorting ?? true)
                {
                    dM_Chis1 = dM_Chis.OrderBy(property_exp);

                }
                else
                {
                    dM_Chis1 = dM_Chis.OrderByDescending(property_exp);
                }

                if (!string.IsNullOrEmpty(thenSortBy))
                {
                    property_exp = ExpressionHelper.GetProperty<DM_Chi>(thenSortBy);
                    if (property_exp != null)
                    {
                        dM_Chis1 = dM_Chis1.ThenBy(property_exp);
                    }
                }
                dM_Chis = dM_Chis1;
            }
            dM_Chis = dM_Chis.Skip(skipCount).Take(maxCount);

            result.Items = await _mapper.ProjectTo<DM_ChiDTO>(dM_Chis).ToListAsync();
            return result;
        }

        [HttpPost]
        public async Task<DM_ChiDTO> Create([FromBody] CreateDM_Chi input)
        {
            if (ModelState.IsValid)
            {
                var entry = _mapper.Map<DM_Chi>(input);
                _db.DM_Chis.Add(entry);
                await _db.SaveChangesAsync();
                var result = _mapper.Map<DM_ChiDTO>(entry);
                return result;
            }
            throw new ArgumentException("Du lieu ko hop le");

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<DM_ChiDTO> Update([FromRoute] long id, [FromBody] DM_ChiDTO input)
        {
            if (ModelState.IsValid)
            {
                var entry = _db.DM_Chis.FirstOrDefault(p => p.id == id);
                if (entry != null)
                {
                    _mapper.Map(input, entry);
                    await _db.SaveChangesAsync();
                    var result = _mapper.Map<DM_ChiDTO>(entry);
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
            var entry = _db.DM_Chis.FirstOrDefault(p => p.id == id);
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
        public async Task<DM_ChiDTO> GetDetail([FromRoute] long id)
        {
            var entry = _db.DM_Chis
                .FirstOrDefault(p => p.id == id);
            if (entry != null)
            {

                return _mapper.Map<DM_ChiDTO>(entry);

            }
            throw new Exception("not found");
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<DM_ChiDTO>> GetAll()
        {
            return await _mapper.ProjectTo<DM_ChiDTO>(_db.DM_Chis).ToListAsync();
        }


    }
}
