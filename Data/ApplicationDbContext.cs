using HMSERM.Model;
using Microsoft.EntityFrameworkCore;


namespace HMSERM.Data
{
     public class ApplicationDbContext : DbContext
     {

            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
            }
        public DbSet<User> Users { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<ClinicAdmin> ClinicAdmins { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Practitioner> Practitioners { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<GlobalTypeCategory> GlobalTypeCategories { get; set; }

        public DbSet<GlobalType> GlobalTypes { get; set; }

        public DbSet<Token> Tokens { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken =default)
        {

            foreach (var entry in ChangeTracker.Entries<Base>())
            {

                if (entry.State == EntityState.Added)

                {

                    entry.Entity.CreatedDate = DateTime.Now;

                    entry.Entity.CreatedBy = "system";
                 
                }

                else if (entry.State == EntityState.Modified)

                {

                    entry.Entity.ModifiedDate = DateTime.Now;

                    entry.Entity.ModifiedBy = "system";

                }

            }

            return base.SaveChangesAsync(cancellationToken);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }

    }

}
