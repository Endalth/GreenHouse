using AutoMapper;
using GreenHouseFull.Common;
using GreenHouseFull.Core.Context;
using GreenHouseFull.DTO;
using GreenHouseFull.UI;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.Mapping
{
    public class GreenHouseMapper
    {
        //IMapper mapper;
        public GreenHouseMapper()
        {
            //var mapConfig = new MapperConfiguration(cfg =>
            //{
            //    //cfg.CreateMap<source, destination>().ReverseMap();
            //    //cfg.CreateMap<source, destination>().ForMember(dest => dest.Field, opt => opt.MapFrom(src => src.Field));

            //    cfg.CreateMap<KullaniciKayitDTO, Kullanici>();
            //});

            //mapper = new Mapper(mapConfig);
        }

        //public TDestination Map(TSource source)
        //{
        //    return mapper.Map<TDestination>(source);
        //}

        public Kullanici MapKullaniciKayitDTOKullanici(KullaniciKayitDTO kullaniciKayit)
        {
            return new Kullanici()
            {
                KullaniciAdi = kullaniciKayit.KullaniciAdi,
                Sifre = kullaniciKayit.Sifre,
                Email = kullaniciKayit.Email,
                RolId = (int)kullaniciKayit.RolId,
                isActive = kullaniciKayit.isActive,
                CreatedDate = kullaniciKayit.CreatedDate,
                ModifiedDate = kullaniciKayit.ModifiedDate
            };
        }

        public KullaniciGirisSonucDTO MapKullaniciKullaniciGirisSonucDTO(Kullanici kullanici)
        {
            return new KullaniciGirisSonucDTO()
            {
                Id = kullanici.Id,
                RolId = (Commons.Rols)kullanici.RolId
            };
        }

        public UrunSimpleListDTO MapUrunUrunSimpleListDTO(Urun urun)
        {
            return new UrunSimpleListDTO
            {
                Id = urun.Id,
                Adi = urun.Adi
            };
        }

        public KategoriSimpleListDTO MapKategoriKategoriSimpleListDTO(Kategori kategori)
        {
            return new KategoriSimpleListDTO()
            {
                Id = kategori.Id,
                Adi = kategori.Adi
            };
        }

        public KategoriWithUstDTO MapKategoriKategoriWithUstsDTO(Kategori kategori)
        {
            return new KategoriWithUstDTO()
            {
                KategoriId = kategori.Id,
                Name = kategori.Adi,
                UstName = kategori.Kategori_Ust?.Adi
            };
        }

        public UreticiSimpleListDTO MapUreticiUreticiSimpleDTO(Uretici uretici)
        {
            return new UreticiSimpleListDTO()
            {
                Id = uretici.Id,
                Adi = uretici.Adi
            };
        }

        public UrunIcerikSimpleListDTO MapUrunIcerikUrunIcerikSimpleDTO(UrunIcerik urunIcerik)
        {
            return new UrunIcerikSimpleListDTO()
            {
                Id = urunIcerik.Id,
                Adi = urunIcerik.Adi
            };
        }

        public Urun MapUrunEkleDTOUrun(UrunEkleDTO urunEkleDTO)
        {
            return new Urun()
            {
                Adi = urunEkleDTO.Adi,
                ArkaYuz = urunEkleDTO.ArkaYuz,
                Barkod = urunEkleDTO.Barkod,
                CreatedBy = urunEkleDTO.CreatedBy,
                CreatedDate = urunEkleDTO.CreatedDate,
                Icerik = urunEkleDTO.Icerik,
                isActive = urunEkleDTO.isActive,
                KullaniciGoster = urunEkleDTO.KullaniciGoster,
                ModifiedBy = urunEkleDTO.ModifiedBy,
                ModifiedDate = urunEkleDTO.ModifiedDate,
                OnYuz = urunEkleDTO.OnYuz,
                KategoriId = urunEkleDTO.KategoriId,
                UreticiId = urunEkleDTO.UreticiId
            };
        }

        public UrunDuzeltmeTalep MapUrunDuzeltmeTalepEkleDTO(UrunDuzeltmeTalepEkleDTO talepEkleDTO)
        {
            return new UrunDuzeltmeTalep()
            {
                UrunId = talepEkleDTO.UrunId,
                Aciklama = talepEkleDTO.Aciklama,
                Resim = talepEkleDTO.Resim,
                OnayAciklama = talepEkleDTO.OnayAciklama,
                OnayDurumId = talepEkleDTO.OnayDurumId,
                CreatedBy = talepEkleDTO.CreatedBy,
                ModifiedBy = talepEkleDTO.ModifiedBy,
                isActive = talepEkleDTO.isActive,
                CreatedDate = talepEkleDTO.CreatedDate,
                ModifiedDate = talepEkleDTO.ModifiedDate
            };
        }

        public FavoriListeSimpleListDTO MapToFavoriSimpleListDTO(KullaniciFavoriListe favoriListe)
        {
            return new FavoriListeSimpleListDTO()
            {
                Id = favoriListe.Id,
                ListeAdi = favoriListe.Adi
            };
        }
        public KullaniciEmailRolDTO MapKullaniciKullaniciEmailRol(Kullanici kullanici)
        {
            return new KullaniciEmailRolDTO()
            {
                Id = kullanici.Id,
                KullaniciAdi = kullanici.KullaniciAdi,
                Email = kullanici.Email,
                RolId = (Commons.Rols)kullanici.RolId
            };
        }

        public UrunIcerikAdminDTO MapUrunIcerikUrunIcerikAdminDTO(UrunIcerik urunIcerik)
        {
            return new UrunIcerikAdminDTO()
            {
                Id = urunIcerik.Id,
                Adi = urunIcerik.Adi,
                Aciklama = urunIcerik.Aciklama,
                RiskSeviyeId = (Commons.RiskSeviye)urunIcerik.RiskSeviyeId
            };
        }
    }
}
