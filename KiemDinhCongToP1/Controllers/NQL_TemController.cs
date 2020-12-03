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
using Mapping.model_TemChi.NQL_Tem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KiemDinhCongTo_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NQL_TemController : ControllerBase
    {
        DBconnect _db;
        IMapper _mapper;
        public NQL_TemController(DBconnect db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<PagingQueryResult<NQL_TemDTO>> GetList([FromQuery] int skipCount, [FromQuery] int maxCount,
[FromQuery] string sortBy, [FromQuery] bool? ascSorting, [FromQuery] string thenSortBy,
[FromQuery] string keyWord)
        {
            IQueryable<NQL_Tem> nQL_Tems = _db.NQL_Tems;
            if (!string.IsNullOrEmpty(keyWord))
            {
                //kDV_Chis = kDV_Chis.Where(p => p.KDV_ID.Contains(keyWord) || p.Serial.Contains(keyWord));
            }
            var result = new PagingQueryResult<NQL_TemDTO>();
            result.Total = nQL_Tems.Count();
            IOrderedQueryable<NQL_Tem> nQL_Tems1;
            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = "Name";
            }
            if (maxCount <= 0)
            {
                maxCount = 50;
            }
            Expression<Func<NQL_Tem, object>> property_exp = ExpressionHelper.GetProperty<NQL_Tem>(sortBy);
            if (property_exp != null)
            {
                if (ascSorting ?? true)
                {
                    nQL_Tems1 = nQL_Tems.OrderBy(property_exp);
                }
                else
                {
                    nQL_Tems1 = nQL_Tems.OrderByDescending(property_exp);
                }

                if (!string.IsNullOrEmpty(thenSortBy))
                {
                    property_exp = ExpressionHelper.GetProperty<NQL_Tem>(thenSortBy);
                    if (property_exp != null)
                    {
                        nQL_Tems1 = nQL_Tems1.ThenBy(property_exp);
                    }
                }
                nQL_Tems = nQL_Tems1;
            }
            nQL_Tems = nQL_Tems.Skip(skipCount).Take(maxCount);

            result.Items = await _mapper.ProjectTo<NQL_TemDTO>(nQL_Tems).ToListAsync();
            return result;
        }

        [HttpPost("create")]
        public async Task<NQL_TemDTO> Create([FromBody] CreateNQL_TemDTO input)
        {
            if (ModelState.IsValid)
            {
                var entry = _mapper.Map<NQL_Tem>(input);
                _db.NQL_Tems.Add(entry);
                await _db.SaveChangesAsync();
                var result = _mapper.Map<NQL_TemDTO>(entry);
                return result;
            }
            throw new ArgumentException("1");

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<NQL_TemDTO> Update([FromRoute] long id, [FromBody] NQL_TemDTO input)
        {
            if (ModelState.IsValid)
            {
                var entry = _db.NQL_Tems.FirstOrDefault(p => p.id == id);
                if (entry != null)
                {
                    _mapper.Map(input, entry);
                    await _db.SaveChangesAsync();
                    var result = _mapper.Map<NQL_TemDTO>(entry);
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
            var entry = _db.NQL_Tems.FirstOrDefault(p => p.id == id);
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
        public async Task<NQL_TemDTO> GetDetail([FromRoute] long id)
        {
            var entry = _db.NQL_Tems
                .FirstOrDefault(p => p.id == id);
            if (entry != null)
            {

                return _mapper.Map<NQL_TemDTO>(entry);

            }
            throw new Exception("1");
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<NQL_TemDTO>> GetAll()
        {
            return await _mapper.ProjectTo<NQL_TemDTO>(_db.NQL_Tems).ToListAsync();
        }
    }
}
