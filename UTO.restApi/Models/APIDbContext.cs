using Microsoft.EntityFrameworkCore;
using System;

namespace UTO.restApi.Models
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {
            try
            { Database.EnsureCreated(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        public virtual DbSet<Content> Content { get; set; }
        public virtual DbSet<ContentClassification> ContentClassification { get; set; }
        public virtual DbSet<ContentGenre> ContentGenre { get; set; }
        public virtual DbSet<ContentType> ContentType { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<MemberType> MemberType { get; set; }
        public virtual DbSet<MemberTypeContent> MemberTypeContent { get; set; }
        public virtual DbSet<User> User { get; set; }

    }
}
