using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzeriaApp.Models
{
    public partial class s16728Context : DbContext
    {
        public s16728Context()
        {
        }

        public s16728Context(DbContextOptions<s16728Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<Ciasto> Ciasto { get; set; }
        public virtual DbSet<DaneWysylki> DaneWysylki { get; set; }
        public virtual DbSet<Emp> Emp { get; set; }
        public virtual DbSet<Napoj> Napoj { get; set; }
        public virtual DbSet<NapojZamowienie> NapojZamowienie { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaCiasto> PizzaCiasto { get; set; }
        public virtual DbSet<PizzaSkladnik> PizzaSkladnik { get; set; }
        public virtual DbSet<Pracownik> Pracownik { get; set; }
        public virtual DbSet<PracownikZamowienie> PracownikZamowienie { get; set; }
        public virtual DbSet<Promocja> Promocja { get; set; }
        public virtual DbSet<RodzajPlatnosci> RodzajPlatnosci { get; set; }
        public virtual DbSet<Skladnik> Skladnik { get; set; }
        public virtual DbSet<Sos> Sos { get; set; }
        public virtual DbSet<SosZamowienie> SosZamowienie { get; set; }
        public virtual DbSet<Stanowisko> Stanowisko { get; set; }
        public virtual DbSet<Uzytkownik> Uzytkownik { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }
        public virtual DbSet<ZamowieniePizza> ZamowieniePizza { get; set; }

        // Unable to generate entity type for table 'dbo.DEPT'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SALGRADE'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s16728;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.IdAdmin)
                    .HasName("Administrator_pk");

                entity.Property(e => e.IdAdmin)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Haslo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ciasto>(entity =>
            {
                entity.HasKey(e => e.IdCiasto)
                    .HasName("Ciasto_pk");

                entity.Property(e => e.IdCiasto).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DaneWysylki>(entity =>
            {
                entity.HasKey(e => e.IdDane)
                    .HasName("DaneWysylki_pk");

                entity.Property(e => e.IdDane).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Firma)
                    .HasColumnName("firma")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdUzytkownik)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NrTelefonu).HasColumnName("nr_telefonu");

                entity.Property(e => e.Ulica)
                    .IsRequired()
                    .HasColumnName("ulica")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUzytkownikNavigation)
                    .WithMany(p => p.DaneWysylki)
                    .HasForeignKey(d => d.IdUzytkownik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DaneWysylki_Uzytkownik");
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasKey(e => e.Empno)
                    .HasName("PK__EMP__14CCF2EE0EFE7B28");

                entity.ToTable("EMP");

                entity.Property(e => e.Empno)
                    .HasColumnName("EMPNO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comm).HasColumnName("COMM");

                entity.Property(e => e.Deptno).HasColumnName("DEPTNO");

                entity.Property(e => e.Ename)
                    .HasColumnName("ENAME")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hiredate)
                    .HasColumnName("HIREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Job)
                    .HasColumnName("JOB")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Mgr).HasColumnName("MGR");

                entity.Property(e => e.Sal).HasColumnName("SAL");
            });

            modelBuilder.Entity<Napoj>(entity =>
            {
                entity.HasKey(e => e.IdNapoj)
                    .HasName("Napoj_pk");

                entity.Property(e => e.IdNapoj).ValueGeneratedNever();

                entity.Property(e => e.IdNazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NapojZamowienie>(entity =>
            {
                entity.HasKey(e => new { e.IdZamowienie, e.IdNapoj })
                    .HasName("Napoj_zamowienie_pk");

                entity.ToTable("Napoj_zamowienie");

                entity.HasOne(d => d.IdNapojNavigation)
                    .WithMany(p => p.NapojZamowienie)
                    .HasForeignKey(d => d.IdNapoj)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Napoj_zamowienie_Napoj");

                entity.HasOne(d => d.IdZamowienieNavigation)
                    .WithMany(p => p.NapojZamowienie)
                    .HasForeignKey(d => d.IdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Napoj_zamowienie_Zamowienie");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza)
                    .HasName("Pizza_pk");

                entity.Property(e => e.IdPizza).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PizzaCiasto>(entity =>
            {
                entity.HasKey(e => new { e.IdPizza, e.IdCiasto })
                    .HasName("Pizza_Ciasto_pk");

                entity.ToTable("Pizza_Ciasto");

                entity.HasOne(d => d.IdCiastoNavigation)
                    .WithMany(p => p.PizzaCiasto)
                    .HasForeignKey(d => d.IdCiasto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Ciasto_Ciasto");

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.PizzaCiasto)
                    .HasForeignKey(d => d.IdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Ciasto_Pizza");
            });

            modelBuilder.Entity<PizzaSkladnik>(entity =>
            {
                entity.HasKey(e => new { e.IdPizza, e.IdSkladnik })
                    .HasName("Pizza_skladnik_pk");

                entity.ToTable("Pizza_skladnik");

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.PizzaSkladnik)
                    .HasForeignKey(d => d.IdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_skladnik_Pizza");

                entity.HasOne(d => d.IdSkladnikNavigation)
                    .WithMany(p => p.PizzaSkladnik)
                    .HasForeignKey(d => d.IdSkladnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_skladnik_Skladnik");
            });

            modelBuilder.Entity<Pracownik>(entity =>
            {
                entity.HasKey(e => e.IdPracownik)
                    .HasName("Pracownik_pk");

                entity.Property(e => e.IdPracownik).ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdStanowiskoNavigation)
                    .WithMany(p => p.Pracownik)
                    .HasForeignKey(d => d.IdStanowisko)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pracownik_Stanowisko");
            });

            modelBuilder.Entity<PracownikZamowienie>(entity =>
            {
                entity.HasKey(e => new { e.IdPracownik, e.IdZamowienie })
                    .HasName("Pracownik_Zamowienie_pk");

                entity.ToTable("Pracownik_Zamowienie");

                entity.HasOne(d => d.IdPracownikNavigation)
                    .WithMany(p => p.PracownikZamowienie)
                    .HasForeignKey(d => d.IdPracownik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pracownik_Zamowienie_Pracownik");

                entity.HasOne(d => d.IdZamowienieNavigation)
                    .WithMany(p => p.PracownikZamowienie)
                    .HasForeignKey(d => d.IdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pracownik_Zamowienie_Zamowienie");
            });

            modelBuilder.Entity<Promocja>(entity =>
            {
                entity.HasKey(e => e.IdPromocja)
                    .HasName("Promocja_pk");

                entity.Property(e => e.IdPromocja).ValueGeneratedNever();

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RodzajPlatnosci>(entity =>
            {
                entity.HasKey(e => e.IdRodzajPlatnosci)
                    .HasName("RodzajPlatnosci_pk");

                entity.Property(e => e.IdRodzajPlatnosci).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Skladnik>(entity =>
            {
                entity.HasKey(e => e.IdSkladnik)
                    .HasName("Skladnik_pk");

                entity.Property(e => e.IdSkladnik).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sos>(entity =>
            {
                entity.HasKey(e => e.IdSos)
                    .HasName("Sos_pk");

                entity.Property(e => e.IdSos).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SosZamowienie>(entity =>
            {
                entity.HasKey(e => new { e.IdZamowienie, e.IdSos })
                    .HasName("Sos_Zamowienie_pk");

                entity.ToTable("Sos_Zamowienie");

                entity.HasOne(d => d.IdSosNavigation)
                    .WithMany(p => p.SosZamowienie)
                    .HasForeignKey(d => d.IdSos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Sos_Zamowienie_Sos");

                entity.HasOne(d => d.IdZamowienieNavigation)
                    .WithMany(p => p.SosZamowienie)
                    .HasForeignKey(d => d.IdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Sos_Zamowienie_Zamowienie");
            });

            modelBuilder.Entity<Stanowisko>(entity =>
            {
                entity.HasKey(e => e.IdStanowisko)
                    .HasName("Stanowisko_pk");

                entity.Property(e => e.IdStanowisko).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Uzytkownik>(entity =>
            {
                entity.HasKey(e => e.IdUzytkownik)
                    .HasName("Uzytkownik_pk");

                entity.Property(e => e.IdUzytkownik)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Haslo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienie)
                    .HasName("Zamowienie_pk");

                entity.Property(e => e.IdZamowienie).ValueGeneratedNever();

                entity.Property(e => e.DaneWysylkiIdDane).HasColumnName("DaneWysylki_idDane");

                entity.Property(e => e.Data).HasColumnType("date");

                entity.HasOne(d => d.DaneWysylkiIdDaneNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.DaneWysylkiIdDane)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_DaneWysylki");

                entity.HasOne(d => d.IdPromocjaNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdPromocja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Promocja");

                entity.HasOne(d => d.RodzajPlatnosciNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.RodzajPlatnosci)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_RodzajPlatnosci");
            });

            modelBuilder.Entity<ZamowieniePizza>(entity =>
            {
                entity.HasKey(e => new { e.IdZamowienie, e.IdPizza })
                    .HasName("Zamowienie_Pizza_pk");

                entity.ToTable("Zamowienie_Pizza");

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.ZamowieniePizza)
                    .HasForeignKey(d => d.IdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Pizza_Pizza");

                entity.HasOne(d => d.IdZamowienieNavigation)
                    .WithMany(p => p.ZamowieniePizza)
                    .HasForeignKey(d => d.IdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Pizza_Zamowienie");
            });
        }
    }
}
