using WCFServiceWebRole1.Models;
using System.Data.Entity;

namespace WCFServiceWebRole1
{

    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext6")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Bevaegelser> Bevaegelser { get; set; }
        public virtual DbSet<Brugere> Brugere { get; set; }
        public virtual DbSet<Tider> Tider { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bevaegelser>()
                .Property(e => e.Tidspunkt)
                .HasPrecision(0);

            modelBuilder.Entity<Bevaegelser>()
                .Property(e => e.Temperatur)
                .HasPrecision(4, 2);

            modelBuilder.Entity<Brugere>()
                .Property(e => e.Brugernavn)
                .IsUnicode(false);

            modelBuilder.Entity<Brugere>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Brugere>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Tider>()
                .Property(e => e.Fra)
                .HasPrecision(0);

            modelBuilder.Entity<Tider>()
                .Property(e => e.Til)
                .HasPrecision(0);
        }
    }
}
