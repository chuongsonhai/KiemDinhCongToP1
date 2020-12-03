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
using Mapping.model_TemChi.DM_Tem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KiemDinhCongTo_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DM_TemController : ControllerBase
    {
        DBconnect _db;
        IMapper _mapper;
        public DM_TemController(DBconnect db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper; ;
        }
        [HttpGet]
        public async Task<PagingQueryResult<DM_TemDTO>> GetList([FromQuery] int skipCount, [FromQuery] int maxCount,
                [FromQuery] string sortBy, [FromQuery] bool? ascSorting, [FromQuery] string thenSortBy,
                [FromQuery] string keyWord)
        {
            IQueryable<DM_Tem> dM_Tems = _db.DM_Tems;
            if (!string.IsNullOrEmpty(keyWord))
            {
                dM_Tems = dM_Tems.Where(p => p.Loai_Tem.Contains(keyWord));
            }
            var result = new PagingQueryResult<DM_TemDTO>();
            result.Total = dM_Tems.Count();
            IOrderedQueryable<DM_Tem> dM_Tems1;
            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = "Loai_Tem";
            }
            if (maxCount <= 0)
            {
                maxCount = 50;
            }
            Expression<Func<DM_Tem, object>> property_exp = ExpressionHelper.GetProperty<DM_Tem>(sortBy);
            if (property_exp != null)
            {
                if (ascSorting ?? true)
                {
                    dM_Tems1 = dM_Tems.OrderBy(property_exp);

                }
                else
                {
                    dM_Tems1 = dM_Tems.OrderByDescending(property_exp);
                }

                if (!string.IsNullOrEmpty(thenSortBy))
                {
                    property_exp = ExpressionHelper.GetProperty<DM_Tem>(thenSortBy);
                    if (property_exp != null)
                    {
                        dM_Tems1 = dM_Tems1.ThenBy(property_exp);
                    }
                }
                dM_Tems = dM_Tems1;
            }
            dM_Tems = dM_Tems.Skip(skipCount).Take(maxCount);

            result.Items = await _mapper.ProjectTo<DM_TemDTO>(dM_Tems).ToListAsync();
            return result;
        }

        [HttpPost]
        public async Task<DM_TemDTO> Create([FromBody] CreateDM_Tem input)
        {
            if (ModelState.IsValid)
            {
                var entry = _mapper.Map<DM_Tem>(input);
                _db.DM_Tems.Add(entry);
                await _db.SaveChangesAsync();
                var result = _mapper.Map<DM_TemDTO>(entry);
                return result;
            }
            throw new ArgumentException("Du lieu ko hop le");

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<DM_TemDTO> Update([FromRoute] long id, [FromBody] DM_TemDTO input)
        {
            if (ModelState.IsValid)
            {
                var entry = _db.DM_Tems.FirstOrDefault(p => p.id == id);
                if (entry != null)
                {
                    _mapper.Map(input, entry);
                    await _db.SaveChangesAsync();
                    var result = _mapper.Map<DM_TemDTO>(entry);
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
            var entry = _db.DM_Tems.FirstOrDefault(p => p.id == id);
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
        public async Task<DM_TemDTO> GetDetail([FromRoute] long id)
        {
            var entry = _db.DM_Tems
                .FirstOrDefault(p => p.id == id);
            if (entry != null)
            {

                return _mapper.Map<DM_TemDTO>(entry);

            }
            throw new Exception("not found");
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<DM_TemDTO>> GetAll()
        {
            return await _mapper.ProjectTo<DM_TemDTO>(_db.DM_Tems).ToListAsync();
        }
    }
}
