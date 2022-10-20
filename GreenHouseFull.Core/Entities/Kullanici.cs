using GreenHouseFull.Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace GreenHouseFull.Core.Context
{
    public class Kullanici : MyEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string KullaniciAdi { get; set; }
        [Required, StringLength(100)]
        public string Sifre { get; set; }
        [Required, StringLength(100)]
        public string Email { get; set; }
        public Nullable<int> RolId { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        

        public Rol Rol { get; set; }
        public Kullanici Kullanici_CB { get; set; }
        public Kullanici Kullanici_MB { get; set; }


        public ICollection<Kullanici> Kullanici_CBs { get; set; }
        public ICollection<Kullanici> Kullanici_MBs { get; set; }
        public ICollection<Aktivite> Aktivite_CBs { get; set; }
        public ICollection<Aktivite> Aktivite_MBs { get; set; }
        public ICollection<KullaniciAktivite> KullaniciAktivite_CBs { get; set; }
        public ICollection<KullaniciAktivite> KullaniciAktivite_MBs { get; set; }
        public ICollection<Rol> Rol_CBs { get; set; }
        public ICollection<Rol> Rol_MBs { get; set; }
        public ICollection<Yetki> Yetki_CBs { get; set; }
        public ICollection<Yetki> Yetki_MBs { get; set; }
        public ICollection<RolYetki> RolYetki_CBs { get; set; }
        public ICollection<RolYetki> RolYetki_MBs { get; set; }
        public ICollection<Kategori> Kategori_CBs { get; set; }
        public ICollection<Kategori> Kategori_MBs { get; set; }
        public ICollection<Uretici> Uretici_CBs { get; set; }
        public ICollection<Uretici> Uretici_MBs { get; set; }
        public ICollection<OnayDurum> UrunDurum_CBs { get; set; }
        public ICollection<OnayDurum> UrunDurum_MBs { get; set; }
        public ICollection<Urun> Urun_CBs { get; set; }
        public ICollection<Urun> Urun_MBs { get; set; }
        public ICollection<UrunOnayDurum> UrunUrunDurum_CBs { get; set; }
        public ICollection<UrunOnayDurum> UrunUrunDurum_MBs { get; set; }
        public ICollection<UrunDuzeltmeTalep> UrunDuzeltmeTalep_CBs { get; set; }
        public ICollection<UrunDuzeltmeTalep> UrunDuzeltmeTalep_MBs { get; set; }
        public ICollection<RiskSeviye> RiskSeviye_CBs { get; set; }
        public ICollection<RiskSeviye> RiskSeviye_MBs { get; set; }
        public ICollection<UrunIcerik> UrunIcerik_CBs { get; set; }
        public ICollection<UrunIcerik> UrunIcerik_MBs { get; set; }
        public ICollection<UrunUrunIcerik> UrunUrunIcerik_CBs { get; set; }
        public ICollection<UrunUrunIcerik> UrunUrunIcerik_MBs { get; set; }
        public ICollection<KullaniciUrunIcerikKaraListe> KullaniciUrunIcerikKaraListe_CBs { get; set; }
        public ICollection<KullaniciUrunIcerikKaraListe> KullaniciUrunIcerikKaraListe_MBs { get; set; }
        public ICollection<KullaniciFavoriListe> KullaniciFavoriListe_CBs { get; set; }
        public ICollection<KullaniciFavoriListe> KullaniciFavoriListe_MBs { get; set; }
        public ICollection<KullaniciUrunFavoriListe> KullaniciUrunFavoriListe_CBs { get; set; }
        public ICollection<KullaniciUrunFavoriListe> KullaniciUrunFavoriListe_MBs { get; set; }
        public ICollection<KullaniciGecmisArama> KullaniciGecmisArama_CBs { get; set; }
        public ICollection<KullaniciGecmisArama> KullaniciGecmisArama_MBs { get; set; }
    }
}