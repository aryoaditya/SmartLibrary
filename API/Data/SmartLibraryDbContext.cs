using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class SmartLibraryDbContext : DbContext
    {
        public SmartLibraryDbContext(DbContextOptions<SmartLibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookBorrower> BookBorrowers { get; set; }
        public DbSet<BookReturn> BookReturns { get; set; }
        public DbSet<BorrowerRecord> BorrowerRecords { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<ReturnRecord> ReturnRecords { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Constraints for Staff Model
            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasIndex(s => s.Id).IsUnique(); // Menambahkan constraint UNIQUE untuk NIK
                entity.HasIndex(s => s.Email).IsUnique(); // Menambahkan constraint UNIQUE untuk Email
                entity.HasIndex(s => s.PhoneNumber).IsUnique(); // Menambahkan constraint UNIQUE untuk PhoneNumber
            });

            // Constraints for Member Model
            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasIndex(m => m.Id).IsUnique(); // Menambahkan constraint UNIQUE untuk NIK
                entity.HasIndex(m => m.Email).IsUnique(); // Menambahkan constraint UNIQUE untuk Email
                entity.HasIndex(m => m.PhoneNumber).IsUnique(); // Menambahkan constraint UNIQUE untuk PhoneNumber
            });

            // One Role has many Account Roles
            modelBuilder.Entity<Role>()
                .HasMany(r => r.AccountRoles)
                .WithOne(ar => ar.Role)
                .HasForeignKey(ar => ar.RoleGuid);

            // One Account has many Account Roles
            modelBuilder.Entity<Account>()
                .HasMany(a => a.AccountRoles)
                .WithOne(ar => ar.Account)
                .HasForeignKey(ar => ar.AccountGuid);

            // One Book has many BookBorrowers
            modelBuilder.Entity<Book>()
                .HasMany(b => b.BookBorrowers)
                .WithOne(bb => bb.Book)
                .HasForeignKey(bb => bb.BookGuid);

            // One Staff has one Account
            modelBuilder.Entity<Staff>()
                .HasOne(s => s.Account)
                .WithOne(a => a.Staff)
                .HasForeignKey<Account>(a => a.Guid);

            // One Member has one Account
            modelBuilder.Entity<Member>()
                .HasOne(m => m.Account)
                .WithOne(a => a.Member)
                .HasForeignKey<Account>(a => a.Guid);

            // One Staff has many BorrowerRecords
            modelBuilder.Entity<Staff>()
                .HasMany(s => s.BorrowerRecords)
                .WithOne(br => br.Staff)
                .HasForeignKey(br => br.StaffGuid);

            // One Member has many BorrowerRecords
            modelBuilder.Entity<Member>()
                .HasMany(m => m.BorrowerRecords)
                .WithOne(br => br.Member)
                .HasForeignKey(br => br.MemberGuid);

            // One Staff has many ReturnRecords
            modelBuilder.Entity<Staff>()
                .HasMany(s => s.ReturnRecords)
                .WithOne(rr => rr.Staff)
                .HasForeignKey(rr => rr.StaffGuid);

            // One member has many ReturnRecords
            modelBuilder.Entity<Member>()
                .HasMany(m => m.ReturnRecords)
                .WithOne(rr => rr.Member)
                .HasForeignKey(rr => rr.MemberGuid);

            // One ReturnRecord has many BookReturns
            modelBuilder.Entity<ReturnRecord>()
                .HasMany(rr => rr.BookReturns)
                .WithOne(br => br.ReturnRecord)
                .HasForeignKey(br => br.ReturnRecordGuid);

            // One Book has many BookReturns
            modelBuilder.Entity<Book>()
                .HasMany(b => b.BookReturns)
                .WithOne(br => br.Book)
                .HasForeignKey(br => br.BookGuid);

            // One BorrowerRecord has many BookBorrower
            modelBuilder.Entity<BorrowerRecord>()
                .HasMany(br => br.BookBorrowers)
                .WithOne(bb => bb.BorrowerRecord)
                .HasForeignKey(bb => bb.BorrowerRecordGuid);

            // One BorrowerRecord has one ReturnRecord
            modelBuilder.Entity<BorrowerRecord>()
                .HasOne(br => br.ReturnRecord)
                .WithOne(rr => rr.BorrowerRecord)
                .HasForeignKey<BorrowerRecord>(br => br.Guid)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
