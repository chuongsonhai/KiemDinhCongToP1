using AutoMapper;
using EntityFramework.Tem_Chi;
using Mapping.model_TemChi.DM_Chi;
using Mapping.model_TemChi.DM_DayChi;
using Mapping.model_TemChi.DM_Tem;
using Mapping.model_TemChi.DM_Ten_KDV;
using Mapping.model_TemChi.KDV_Chi;
using Mapping.model_TemChi.KDV_DayChi;
using Mapping.model_TemChi.KDV_Tem;
using Mapping.model_TemChi.NQL_Chi;
using Mapping.model_TemChi.NQL_DayChi;
using Mapping.model_TemChi.NQL_Tem;
using Mapping.model_TemChi.SLT_Tem;
using Mapping.model_TemChi.SLT_DayChi;
using Mapping.model_TemChi.SLT_Chi;
using Mapping.model_TemChi.QL_CaiDat_CTDienTU;
using Mapping.model_TemChi.Dangkytemchi;
using System;

namespace Mapping
{
    public class AutoMappingProfile:Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<CreateDM_Chi, DM_Chi>()
                .ForMember(p => p.id, m => m.Ignore())
                ;
            CreateMap<DM_ChiDTO, DM_Chi>()
                .ForMember(p => p.id, m => m.Ignore())
                ;
            CreateMap<DM_Chi, DM_ChiDTO>()
       
            ;



            CreateMap<CreateDM_DayChi, DM_DayChi>()
                  .ForMember(p => p.id, m => m.Ignore())
            ;
            CreateMap<DM_DayChiDTO, DM_DayChi>()
                  .ForMember(p => p.id, m => m.Ignore())
                ;
            CreateMap<DM_DayChi, DM_DayChiDTO>()
                ;



            CreateMap<CreateDM_Tem, DM_Tem>()
                  .ForMember(p => p.id, m => m.Ignore())
                ;
            CreateMap<DM_TemDTO, DM_Tem>()
                .ForMember(p => p.id, m => m.Ignore());
                ;
            CreateMap<DM_Tem, DM_TemDTO>()
  ;


            CreateMap<CreateTaiKhoanDTO, TaiKhoan>()
                 .ForMember(p => p.id, m => m.Ignore())
     
                    ;
            CreateMap<TaiKhoanDTO, TaiKhoan>()
                .ForMember(p => p.id, m => m.Ignore())
                   ;
            CreateMap<TaiKhoan, TaiKhoanDTO>()
                ;




            CreateMap<CreateKDV_Chi, KDV_Chi>()
                .ForMember(p => p.id, m => m.Ignore())
                .ForMember(p => p.DM_Chi, m => m.Ignore())
                .ForMember(p => p.TaiKhoan, m => m.Ignore())
                ;
            CreateMap<KDV_ChiDTO , KDV_Chi > ()
                .ForMember(p => p.id, m => m.Ignore())
                .ForMember(p => p.DM_Chi, m => m.Ignore())
                .ForMember(p => p.TaiKhoan, m => m.Ignore())
                ;
            CreateMap<KDV_Chi, KDV_ChiDTO>()
                 .ForMember(p => p.LoaiChi_name, m => m.MapFrom(p => p.DM_Chi.Loai_Chi))
                 .ForMember(p => p.TenKDV_name, m => m.MapFrom(p => p.TaiKhoan.TenDayDu))
                ;



            CreateMap<CreateKDV_DayChi, KDV_DayChi>()
                .ForMember(p => p.id, m => m.Ignore())
                .ForMember(p => p.DM_DayChi, m => m.Ignore())
                .ForMember(p => p.TaiKhoan, m => m.Ignore())
            ;
           
            CreateMap<KDV_DayChiDTO, KDV_DayChi>()
                .ForMember(p => p.id, m => m.Ignore())
                .ForMember(p => p.DM_DayChi, m => m.Ignore())
                .ForMember(p => p.TaiKhoan, m => m.Ignore())
                ;
            CreateMap<KDV_DayChi, KDV_DayChiDTO>()
                .ForMember(p => p.LoaiDayChi_name, m => m.MapFrom(p => p.DM_DayChi.Loai_DayChi))
                .ForMember(p => p.TenKDV_name, m => m.MapFrom(p => p.TaiKhoan.TenDayDu))

                ;



            CreateMap<CreateKDV_Tem, KDV_Tem>()
                .ForMember(p => p.id, m => m.Ignore())
                .ForMember(p => p.DM_Tem, m => m.Ignore())
                .ForMember(p => p.TaiKhoan, m => m.Ignore())
                ;
            CreateMap<KDV_TemDTO, KDV_Tem>()
                .ForMember(p => p.id, m => m.Ignore())
                .ForMember(p => p.DM_Tem, m => m.Ignore())
                .ForMember(p => p.TaiKhoan, m => m.Ignore())
                ;
            CreateMap<KDV_Tem, KDV_TemDTO>()
                .ForMember(p => p.LoaiTem_name, m => m.MapFrom(p => p.DM_Tem.Loai_Tem))
                
                .ForMember(p => p.TenKDV_name, m => m.MapFrom(p => p.TaiKhoan.TenDayDu))
                ;



            CreateMap<CreateNQL_TemDTO, NQL_Tem>()
                 .ForMember(p => p.id, m => m.Ignore())
                   .ForMember(p => p.DM_Tem, m => m.Ignore())
                   .ForMember(p => p.TaiKhoan, m => m.Ignore())
                  ;
            CreateMap<NQL_TemDTO, NQL_Tem>()
                .ForMember(p => p.id, m => m.Ignore())
                .ForMember(p => p.DM_Tem, m => m.Ignore())
                .ForMember(p => p.TaiKhoan, m => m.Ignore())
                ;
            CreateMap<NQL_Tem, NQL_TemDTO>()
                .ForMember(p => p.LoaiTem_name, m => m.MapFrom(p => p.DM_Tem.Loai_Tem))
                .ForMember(p => p.TenKDV_name, m => m.MapFrom(p => p.TaiKhoan.TenDayDu))
                ;




             CreateMap<CreateNQL_DayChiDTO, NQL_DayChi>()
                  .ForMember(p => p.id, m => m.Ignore())
                   .ForMember(p => p.DM_DayChi, m => m.Ignore())
                  .ForMember(p => p.TaiKhoan, m => m.Ignore())
;

            CreateMap<NQL_DayChiDTO, NQL_DayChi>()
                .ForMember(p => p.id, m => m.Ignore())
                .ForMember(p => p.DM_DayChi, m => m.Ignore())
                .ForMember(p => p.TaiKhoan, m => m.Ignore())
                ;
            CreateMap<NQL_DayChi, NQL_DayChiDTO>()
                .ForMember(p => p.LoaiDayChi_name, m => m.MapFrom(p => p.DM_DayChi.Loai_DayChi))
                .ForMember(p => p.TenKDV_name, m => m.MapFrom(p => p.TaiKhoan.TenDayDu))

                ;

            CreateMap<CreateNQL_ChiDTO, NQL_Chi>()
               .ForMember(p => p.id, m => m.Ignore())
              .ForMember(p => p.DM_Chi, m => m.Ignore())
               .ForMember(p => p.TaiKhoan, m => m.Ignore())
        ;
            CreateMap<NQL_ChiDTO, NQL_Chi>()
                .ForMember(p => p.id, m => m.Ignore())
                .ForMember(p => p.DM_Chi, m => m.Ignore())
                .ForMember(p => p.TaiKhoan, m => m.Ignore())
                ;
            CreateMap<NQL_Chi, NQL_ChiDTO>()
                 .ForMember(p => p.LoaiChi_name, m => m.MapFrom(p => p.DM_Chi.Loai_Chi))
                 .ForMember(p => p.TenKDV_name, m => m.MapFrom(p => p.TaiKhoan.TenDayDu))
                ;


    //        CreateMap<CreateSLT_ChiDTO, SLT_Chi>()
    //            .ForMember(p => p.id, m => m.Ignore())
    //            .ForMember(p => p.DM_Chi, m => m.Ignore())
    //            ;
    //        CreateMap<SLT_ChiDTO, SLT_Chi>()
    //            .ForMember(p => p.id, m => m.Ignore())
    //            .ForMember(p => p.DM_Chi, m => m.Ignore())
         
    //            ;
    //        CreateMap<SLT_Chi, SLT_ChiDTO>()
    //             .ForMember(p => p.LoaiChi_name, m => m.MapFrom(p => p.DM_Chi.Loai_Chi))
    //            ;



    //        CreateMap<CreateSLT_DayChiDTO, SLT_DayChi>()
    //           .ForMember(p => p.id, m => m.Ignore())
    //           .ForMember(p => p.DM_DayChi, m => m.Ignore())
    //;
    //        CreateMap<SLT_DayChiDTO, SLT_DayChi>()
    //            .ForMember(p => p.id, m => m.Ignore())
    //            .ForMember(p => p.DM_DayChi, m => m.Ignore())

    //            ;
    //        CreateMap<SLT_DayChi, SLT_DayChiDTO>()
    //             .ForMember(p => p.LoaiDayChi_name, m => m.MapFrom(p => p.DM_DayChi.Loai_DayChi))
    //            ;



    //        CreateMap<CreateSLT_TemDTO, SLT_Tem>()
    //             .ForMember(p => p.id, m => m.Ignore())
    //              .ForMember(p => p.DM_Tem, m => m.Ignore())
    //              ;
    //        CreateMap<SLT_TemDTO, SLT_Tem>()
    //            .ForMember(p => p.id, m => m.Ignore())
    //            .ForMember(p => p.DM_Tem, m => m.Ignore())

    //            ;
    //        CreateMap<SLT_Tem, SLT_TemDTO>()
    //             .ForMember(p => p.LoaiTem_name, m => m.MapFrom(p => p.DM_Tem.Loai_Tem))
    //            ;



            CreateMap<CreateQL_CaiDat_CTDienTu, QL_CaiDat_CTDienTu>()
                  .ForMember(p => p.id, m => m.Ignore())
                .ForMember(p => p.TaiKhoan, m => m.Ignore())
                  ;
            CreateMap<QL_CaiDat_CTDienTuDTO, QL_CaiDat_CTDienTu>()
                .ForMember(p => p.id, m => m.Ignore())
                .ForMember(p => p.TaiKhoan, m => m.Ignore())

                ;
            CreateMap<QL_CaiDat_CTDienTu, QL_CaiDat_CTDienTuDTO>()
                 .ForMember(p => p.NguoiCai_Name, m => m.MapFrom(p => p.TaiKhoan.TenDayDu))
                      .ForMember(p => p.MaKDV_Name, m => m.MapFrom(p => p.TaiKhoan.MaKDV))
                ;




            CreateMap<CreateDangKy_TemChiDTO, DangKy_TemChi>()
                    .ForMember(p => p.id, m => m.Ignore())
                  .ForMember(p => p.TaiKhoan, m => m.Ignore())
                       ;
            CreateMap<DangKy_TemChiDTO, DangKy_TemChi>()
                .ForMember(p => p.id, m => m.Ignore())
                .ForMember(p => p.TaiKhoan, m => m.Ignore())

                ;
            CreateMap<DangKy_TemChi, DangKy_TemChiDTO>()
                 .ForMember(p => p.NguoiDangKy_name, m => m.MapFrom(p => p.TaiKhoan.TenDayDu))
                 .ForMember(p => p.NguoiDuyet_name, m => m.MapFrom(p => p.TaiKhoan.TenDayDu))
                ;
        }
    }
}
