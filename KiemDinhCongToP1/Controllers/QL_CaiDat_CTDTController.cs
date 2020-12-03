using AutoMapper;
using constraint;
using Constraint;
using EntityFramework;
using EntityFramework.Tem_Chi;
using Mapping.model_TemChi.QL_CaiDat_CTDienTU;
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
    public class QL_CaiDat_CTDTController : ControllerBase
    {
        DBconnect _db;
        IMapper _mapper;
        public QL_CaiDat_CTDTController(DBconnect db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<PagingQueryResult<QL_CaiDat_CTDienTuDTO>> GetList([FromQuery] int skipCount, [FromQuery] int maxCount,
     [FromQuery] string sortBy, [FromQuery] bool? ascSorting, [FromQuery] string thenSortBy,
     [FromQuery] string keyWord)
        {
            IQueryable<QL_CaiDat_CTDienTu> qL_CaiDats = _db.QL_CaiDat_CTDienTus;
            if (!string.IsNullOrEmpty(keyWord))
            {
                //kDV_Chis = kDV_Chis.Where(p => p.KDV_ID.Contains(keyWord) || p.Serial.Contains(keyWord));
            }
            var result = new PagingQueryResult<QL_CaiDat_CTDienTuDTO>();
            result.Total = qL_CaiDats.Count();
            IOrderedQueryable<QL_CaiDat_CTDienTu> qL_CaiDats1;
            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = "Name";
            }
            if (maxCount <= 0)
            {
                maxCount = 50;
            }
            Expression<Func<QL_CaiDat_CTDienTu, object>> property_exp = ExpressionHelper.GetProperty<QL_CaiDat_CTDienTu>(sortBy);
            if (property_exp != null)
            {
                if (ascSorting ?? true)
                {
                    qL_CaiDats1 = qL_CaiDats.OrderBy(property_exp);
                }
                else
                {
                    qL_CaiDats1 = qL_CaiDats.OrderByDescending(property_exp);
                }

                if (!string.IsNullOrEmpty(thenSortBy))
                {
                    property_exp = ExpressionHelper.GetProperty<QL_CaiDat_CTDienTu>(thenSortBy);
                    if (property_exp != null)
                    {
                        qL_CaiDats1 = qL_CaiDats1.ThenBy(property_exp);
                    }
                }
                qL_CaiDats = qL_CaiDats1;
            }
            qL_CaiDats = qL_CaiDats.Skip(skipCount).Take(maxCount);

            result.Items = await _mapper.ProjectTo<QL_CaiDat_CTDienTuDTO>(qL_CaiDats).ToListAsync();
            return result;
        }

        [HttpPost("create")]
        public async Task<QL_CaiDat_CTDienTuDTO> Create([FromBody] CreateQL_CaiDat_CTDienTu input)
        {
            if (ModelState.IsValid)
            {
                var entry = _mapper.Map<QL_CaiDat_CTDienTu>(input);
                _db.QL_CaiDat_CTDienTus.Add(entry);
                await _db.SaveChangesAsync();
                var result = _mapper.Map<QL_CaiDat_CTDienTuDTO>(entry);
                return result;
            }
            throw new ArgumentException("1");

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<QL_CaiDat_CTDienTuDTO> Update([FromRoute] long id, [FromBody] QL_CaiDat_CTDienTuDTO input)
        {
            if (ModelState.IsValid)
            {
                var entry = _db.QL_CaiDat_CTDienTus.FirstOrDefault(p => p.id == id);
                if (entry != null)
                {
                    _mapper.Map(input, entry);
                    await _db.SaveChangesAsync();
                    var result = _mapper.Map<QL_CaiDat_CTDienTuDTO>(entry);
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
            var entry = _db.QL_CaiDat_CTDienTus.FirstOrDefault(p => p.id == id);
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
        public async Task<QL_CaiDat_CTDienTuDTO> GetDetail([FromRoute] long id)
        {
            var entry = _db.QL_CaiDat_CTDienTus
                .FirstOrDefault(p => p.id == id);
            if (entry != null)
            {

                return _mapper.Map<QL_CaiDat_CTDienTuDTO>(entry);

            }
            throw new Exception("1");
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<QL_CaiDat_CTDienTuDTO>> GetAll()
        {
            return await _mapper.ProjectTo<QL_CaiDat_CTDienTuDTO>(_db.QL_CaiDat_CTDienTus).ToListAsync();
        }
    }
}
