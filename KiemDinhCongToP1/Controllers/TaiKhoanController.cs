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
using Mapping.model_TemChi.DM_Ten_KDV;
using Mapping.model_TemChi.TaiKhoan;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KiemDinhCongTo_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        DBconnect _db;
        IMapper _mapper;
        public TaiKhoanController(DBconnect db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<PagingQueryResult<TaiKhoanDTO>> GetList([FromQuery] int skipCount, [FromQuery] int maxCount,
          [FromQuery] string sortBy, [FromQuery] bool? ascSorting, [FromQuery] string thenSortBy,
          [FromQuery] string keyWord)
        {
            IQueryable<TaiKhoan> dM_Ten_KDVs = _db.TaiKhoans;
            if (!string.IsNullOrEmpty(keyWord))
            {
              //  dM_Ten_KDVs = dM_Ten_KDVs.Where(p => p.Ten_KDV.Contains(keyWord));
            }
            var result = new PagingQueryResult<TaiKhoanDTO>();
            result.Total = dM_Ten_KDVs.Count();
            IOrderedQueryable<TaiKhoan> dM_Ten_KDVs1;
            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = "Ten_KDV";
            }
            if (maxCount <= 0)
            {
                maxCount = 50;
            }
            Expression<Func<TaiKhoan, object>> property_exp = ExpressionHelper.GetProperty<TaiKhoan>(sortBy);
            if (property_exp != null)
            {
                if (ascSorting ?? true)
                {
                    dM_Ten_KDVs1 = dM_Ten_KDVs.OrderBy(property_exp);

                }
                else
                {
                    dM_Ten_KDVs1 = dM_Ten_KDVs.OrderByDescending(property_exp);
                }

                if (!string.IsNullOrEmpty(thenSortBy))
                {
                    property_exp = ExpressionHelper.GetProperty<TaiKhoan>(thenSortBy);
                    if (property_exp != null)
                    {
                        dM_Ten_KDVs1 = dM_Ten_KDVs1.ThenBy(property_exp);
                    }
                }
                dM_Ten_KDVs = dM_Ten_KDVs1;
            }
            dM_Ten_KDVs = dM_Ten_KDVs.Skip(skipCount).Take(maxCount);

            result.Items = await _mapper.ProjectTo<TaiKhoanDTO>(dM_Ten_KDVs).ToListAsync();
            return result;
        }

        [HttpPost("create")]
        public async Task<TaiKhoanDTO> Create([FromBody] CreateTaiKhoanDTO input)
        {
            if (ModelState.IsValid)
            {
                var entry = _mapper.Map<TaiKhoan>(input);
                _db.TaiKhoans.Add(entry);
                await _db.SaveChangesAsync();
                var result = _mapper.Map<TaiKhoanDTO>(entry);
                return result;
            }
            throw new ArgumentException("Du lieu ko hop le");

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<TaiKhoanDTO> Update([FromRoute] long id, [FromBody] TaiKhoanDTO input)
        {
            if (ModelState.IsValid)
            {
                var entry = _db.TaiKhoans.FirstOrDefault(p => p.id == id);
                if (entry != null)
                {
                    _mapper.Map(input, entry);
                    await _db.SaveChangesAsync();
                    var result = _mapper.Map<TaiKhoanDTO>(entry);
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
            var entry = _db.TaiKhoans.FirstOrDefault(p => p.id == id);
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
        public async Task<TaiKhoanDTO> GetDetail([FromRoute] long id)
        {
            var entry = _db.TaiKhoans
                .FirstOrDefault(p => p.id == id);
            if (entry != null)
            {

                return _mapper.Map<TaiKhoanDTO>(entry);

            }
            throw new Exception("not found");
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<TaiKhoanDTO>> GetAll()
        {
            return await _mapper.ProjectTo<TaiKhoanDTO>(_db.TaiKhoans).ToListAsync();
        }

        [HttpPost("login")]
        public async Task<TaiKhoanDTO> Login([FromBody] LoginDTO input)
        {
            if (ModelState.IsValid)
            {
                var entry = (from taikhoan in _db.TaiKhoans
                             where taikhoan.TenDangNhap == input.TenDangNhap
                             && taikhoan.MatKhau == input.MatKhau
                             select taikhoan).FirstOrDefault();
                if (entry != null)
                {

                    return _mapper.Map<TaiKhoanDTO>(entry);
                }
                return new TaiKhoanDTO { };

            }
            throw new Exception("model not ready");

        }

    }
}
