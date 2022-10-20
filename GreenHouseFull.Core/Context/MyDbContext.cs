using GreenHouseFull.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.Core.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=GreenHouseCS")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //fluent api  constraintler 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Foreign Keys
            modelBuilder.Entity<Kullanici>().HasOptional(s => s.Rol).WithMany(d => d.Kullanicis).HasForeignKey(s => s.RolId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Kullanici>().HasOptional(s => s.Kullanici_CB).WithMany(d => d.Kullanici_CBs).HasForeignKey(s => s.CreatedBy).WillCascadeOnDelete(false);
            modelBuilder.Entity<Kullanici>().HasOptional(s => s.Kullanici_MB).WithMany(d => d.Kullanici_MBs).HasForeignKey(s => s.ModifiedBy).WillCascadeOnDelete(false);

            modelBuilder.Entity<Aktivite>().HasRequired(s => s.Kullanici_CB).WithMany(d => d.Aktivite_CBs).HasForeignKey(s => s.CreatedBy).WillCascadeOnDelete(false);
            modelBuilder.Entity<Aktivite>().HasRequired(s => s.Kullanici_MB).WithMany(d => d.Aktivite_MBs).HasForeignKey(s => s.ModifiedBy).WillCascadeOnDelete(false);

            modelBuilder.Entity<KullaniciAktivite>().HasRequired(s => s.Aktivite).WithMany(d => d.KullaniciAktivites).HasForeignKey(s => s.AktiviteId).WillCascadeOnDelete(false);
            modelBuilder.Entity<KullaniciAktivite>().HasRequired(s => s.Kullanici_CB).WithMany(d => d.KullaniciAktivite_CBs).HasForeignKey(s => s.CreatedBy).WillCascadeOnDelete(false);
            modelBuilder.Entity<KullaniciAktivite>().HasRequired(s => s.Kullanici_MB).WithMany(d => d.KullaniciAktivite_MBs).HasForeignKey(s => s.ModifiedBy).WillCascadeOnDelete(false);

            modelBuilder.Entity<Rol>().HasRequired(s => s.Kullanici_CB).WithMany(d => d.Rol_CBs).HasForeignKey(s => s.CreatedBy).WillCascadeOnDelete(false);
            modelBuilder.Entity<Rol>().HasRequired(s => s.Kullanici_MB).WithMany(d => d.Rol_MBs).HasForeignKey(s => s.ModifiedBy).WillCascadeOnDelete(false);

            modelBuilder.Entity<Yetki>().HasRequired(s => s.Kullanici_CB).WithMany(d => d.Yetki_CBs).HasForeignKey(s => s.CreatedBy).WillCascadeOnDelete(false);
            modelBuilder.Entity<Yetki>().HasRequired(s => s.Kullanici_MB).WithMany(d => d.Yetki_MBs).HasForeignKey(s => s.ModifiedBy).WillCascadeOnDelete(false);

            modelBuilder.Entity<RolYetki>().HasRequired(s => s.Rol).WithMany(d => d.RolYetkis).HasForeignKey(s => s.RolId).WillCascadeOnDelete(false);
            modelBuilder.Entity<RolYetki>().HasRequired(s => s.Yetki).WithMany(d => d.RolYetkis).HasForeignKey(s => s.YetkiId).WillCascadeOnDelete(false);
            modelBuilder.Entity<RolYetki>().HasRequired(s => s.Kullanici_CB).WithMany(d => d.RolYetki_CBs).HasForeignKey(s => s.CreatedBy).WillCascadeOnDelete(false);
            modelBuilder.Entity<RolYetki>().HasRequired(s => s.Kullanici_MB).WithMany(d => d.RolYetki_MBs).HasForeignKey(s => s.ModifiedBy).WillCascadeOnDelete(false);

            modelBuilder.Entity<Kategori>().HasOptional(s => s.Kategori_Ust).WithMany(d => d.Kategori_Usts).HasForeignKey(s => s.UstKategoriId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Kategori>().HasRequired(s => s.Kullanici_CB).WithMany(d => d.Kategori_CBs).HasForeignKey(s => s.CreatedBy).WillCascadeOnDelete(false);
            modelBuilder.Entity<Kategori>().HasRequired(s => s.Kullanici_MB).WithMany(d => d.Kategori_MBs).HasForeignKey(s => s.ModifiedBy).WillCascadeOnDelete(false);
            
            modelBuilder.Entity<Uretici>().HasRequired(s => s.Kullanici_CB).WithMany(d => d.Uretici_CBs).HasForeignKey(s => s.CreatedBy).WillCascadeOnDelete(false);
            modelBuilder.Entity<Uretici>().HasRequired(s => s.Kullanici_MB).WithMany(d => d.Uretici_MBs).HasForeignKey(s => s.ModifiedBy).WillCascadeOnDelete(false);
            
            modelBuilder.Entity<OnayDurum>().HasRequired(s => s.Kullanici_CB).WithMany(d => d.UrunDurum_CBs).HasForeignKey(s => s.CreatedBy).WillCascadeOnDelete(false);
            modelBuilder.Entity<OnayDurum>().HasRequired(s => s.Kullanici_MB).WithMany(d => d.UrunDurum_MBs).HasForeignKey(s => s.ModifiedBy).WillCascadeOnDelete(false);

            modelBuilder.Entity<Urun>().HasRequired(s => s.Kategori).WithMany(d => d.Uruns).HasForeignKey(s => s.KategoriId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Urun>().HasRequired(s => s.Uretici).WithMany(d => d.Uruns).HasForeignKey(s => s.UreticiId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Urun>().HasRequired(s => s.Kullanici_CB).WithMany(d => d.Urun_CBs).HasForeignKey(s => s.CreatedBy).WillCascadeOnDelete(false);
            modelBuilder.Entity<Urun>().HasRequired(s => s.Kullanici_MB).WithMany(d => d.Urun_MBs).HasForeignKey(s => s.ModifiedBy).WillCascadeOnDelete(false);

            modelBuilder.Entity<UrunOnayDurum>().HasRequired(s => s.Urun).WithMany(d => d.UrunUrunDurums).HasForeignKey(s => s.UrunId).WillCascadeOnDelete(false);
            modelBuilder.Entity<UrunOnayDurum>().HasRequired(s => s.OnayDurum).WithMany(d => d.UrunUrunOnayDurums).HasForeignKey(s => s.OnayDurumId).WillCascadeOnDelete(false);
            modelBuilder.Entity<UrunOnayDurum>().HasRequired(s => s.Kullanici_CB).WithMany(d => d.UrunUrunDurum_CBs).HasForeignKey(s => s.CreatedBy).WillCascadeOnDelete(false);
            modelBuilder.Entity<UrunOnayDurum>().HasRequired(s => s.Kullanici_MB).WithMany(d => d.UrunUrunDurum_MBs).HasForeignKey(s => s.ModifiedBy).WillCascadeOnDelete(false);

            modelBuilder.Entity<UrunDuzeltmeTalep>().HasRequired(s => s.OnayDurum).WithMany(d => d.UrunDuzeltmeTaleps).HasForeignKey(s => s.OnayDurumId).WillCascadeOnDelete(false);
            modelBuilder.Entity<UrunDuzeltmeTalep>().HasRequired(s => s.Urun).WithMany(d => d.UrunDuzeltmeTaleps).HasForeignKey(s => s.UrunId).WillCascadeOnDelete(false);
            modelBuilder.Entity<UrunDuzeltmeTalep>().HasRequired(s => s.Kullanici_CB).WithMany(d => d.UrunDuzeltmeTalep_CBs).HasForeignKey(s => s.CreatedBy).WillCascadeOnDelete(false);
            modelBuilder.Entity<UrunDuzeltmeTalep>().HasRequired(s => s.Kullanici_MB).WithMany(d => d.UrunDuzeltmeTalep_MBs).HasForeignKey(s => s.ModifiedBy).WillCascadeOnDelete(false);

            modelBuilder.Entity<RiskSeviye>().HasRequired(s => s.Kullanici_CB).WithMany(d => d.RiskSeviye_CBs).HasForeignKey(s => s.CreatedBy).WillCascadeOnDelete(false);
            modelBuilder.Entity<RiskSeviye>().HasRequired(s => s.Kullanici_MB).WithMany(d => d.RiskSeviye_MBs).HasForeignKey(s => s.ModifiedBy).WillCascadeOnDelete(false);

            modelBuilder.Entity<UrunIcerik>().HasRequired(s => s.Kullanici_CB).WithMany(d => d.UrunIcerik_CBs).HasForeignKey(s => s.CreatedBy).WillCascadeOnDelete(false);
            modelBuilder.Entity<UrunIcerik>().HasRequired(s => s.Kullanici_MB).WithMany(d => d.UrunIcerik_MBs).HasForeignKey(s => s.ModifiedBy).WillCascadeOnDelete(false);

            modelBuilder.Entity<UrunUrunIcerik>().HasRequired(s => s.Urun).WithMany(d => d.UrunUrunIceriks).HasForeignKey(s => s.UrunId).WillCascadeOnDelete(false);
            modelBuilder.Entity<UrunUrunIcerik>().HasRequired(s => s.UrunIcerik).WithMany(d => d.UrunUrunIceriks).HasForeignKey(s => s.UrunIcerikId).WillCascadeOnDelete(false);
            modelBuilder.Entity<UrunUrunIcerik>().HasRequired(s => s.Kullanici_CB).WithMany(d => d.UrunUrunIcerik_CBs).HasForeignKey(s => s.CreatedBy).WillCascadeOnDelete(false);
            modelBuilder.Entity<UrunUrunIcerik>().HasRequired(s => s.Kullanici_MB).WithMany(d => d.UrunUrunIcerik_MBs).HasForeignKey(s => s.ModifiedBy).WillCascadeOnDelete(false);

            modelBuilder.Entity<KullaniciUrunIcerikKaraListe>().HasRequired(s => s.UrunIcerik).WithMany(d => d.KullaniciUrunIcerikKaraListes).HasForeignKey(s => s.CreatedBy).WillCascadeOnDelete(false);
            modelBuilder.Entity<KullaniciUrunIcerikKaraListe>().HasRequired(s => s.Kullanici_CB).WithMany(d => d.KullaniciUrunIcerikKaraListe_CBs).HasForeignKey(s => s.CreatedBy).WillCascadeOnDelete(false);
            modelBuilder.Entity<KullaniciUrunIcerikKaraListe>().HasRequired(s => s.Kullanici_MB).WithMany(d => d.KullaniciUrunIcerikKaraListe_MBs).HasForeignKey(s => s.ModifiedBy).WillCascadeOnDelete(false);

            modelBuilder.Entity<KullaniciFavoriListe>().HasRequired(s => s.Kullanici_CB).WithMany(d => d.KullaniciFavoriListe_CBs).HasForeignKey(s => s.CreatedBy).WillCascadeOnDelete(false);
            modelBuilder.Entity<KullaniciFavoriListe>().HasRequired(s => s.Kullanici_MB).WithMany(d => d.KullaniciFavoriListe_MBs).HasForeignKey(s => s.ModifiedBy).WillCascadeOnDelete(false);

            modelBuilder.Entity<KullaniciUrunFavoriListe>().HasRequired(s => s.KullaniciFavoriListe).WithMany(d => d.KullaniciUrunFavoriListes).HasForeignKey(s => s.ListeId).WillCascadeOnDelete(false);
            modelBuilder.Entity<KullaniciUrunFavoriListe>().HasRequired(s => s.Urun).WithMany(d => d.KullaniciUrunFavoriListes).HasForeignKey(s => s.UrunId).WillCascadeOnDelete(false);
            modelBuilder.Entity<KullaniciUrunFavoriListe>().HasRequired(s => s.Kullanici_CB).WithMany(d => d.KullaniciUrunFavoriListe_CBs).HasForeignKey(s => s.CreatedBy).WillCascadeOnDelete(false);
            modelBuilder.Entity<KullaniciUrunFavoriListe>().HasRequired(s => s.Kullanici_MB).WithMany(d => d.KullaniciUrunFavoriListe_MBs).HasForeignKey(s => s.ModifiedBy).WillCascadeOnDelete(false);

            modelBuilder.Entity<KullaniciGecmisArama>().HasRequired(s => s.Urun).WithMany(d => d.KullaniciGecmisAramas).HasForeignKey(s => s.UrunId).WillCascadeOnDelete(false);
            modelBuilder.Entity<KullaniciGecmisArama>().HasRequired(s => s.Kullanici_CB).WithMany(d => d.KullaniciGecmisArama_CBs).HasForeignKey(s => s.CreatedBy).WillCascadeOnDelete(false);
            modelBuilder.Entity<KullaniciGecmisArama>().HasRequired(s => s.Kullanici_MB).WithMany(d => d.KullaniciGecmisArama_MBs).HasForeignKey(s => s.ModifiedBy).WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Aktivite> Aktivite { get; set; }
        public DbSet<KullaniciAktivite> KullaniciAktivite { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Yetki> Yetki { get; set; }
        public DbSet<RolYetki> RolYetki { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Uretici> Uretici { get; set; }
        public DbSet<OnayDurum> UrunDurum { get; set; }
        public DbSet<Urun> Urun { get; set; }
        public DbSet<UrunOnayDurum> UrunOnayDurum { get; set; }
        public DbSet<UrunDuzeltmeTalep> UrunDuzeltmeTalep { get; set; }
        public DbSet<RiskSeviye> RiskSeviye { get; set; }
        public DbSet<UrunIcerik> UrunIcerik { get; set; }
        public DbSet<UrunUrunIcerik> UrunUrunIcerik { get; set; }
        public DbSet<KullaniciUrunIcerikKaraListe> KullaniciUrunIcerikKaraListe { get; set; }
        public DbSet<KullaniciFavoriListe> KullaniciFavoriListe { get; set; }
        public DbSet<KullaniciUrunFavoriListe> KullaniciUrunFavoriListe { get; set; }
        public DbSet<KullaniciGecmisArama> KullaniciGecmisArama { get; set; }
    }
}
