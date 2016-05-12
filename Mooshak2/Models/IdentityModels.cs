using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Mooshak2.Models.Entity;

namespace Mooshak2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(null);
        }

            public DbSet<Assignment>        Assignments       { get; set; }
            public DbSet<Course>            Courses           { get; set; }
            public DbSet<Student>           Students          { get; set; }
            public DbSet<Teacher>           Teachers          { get; set; }
            public DbSet<Admin>             Admins            { get; set; }
            public DbSet<AssignmentStudent> AssignmentStudents { get; set; }
            public DbSet<CourseStudent>     CourseStudents { get; set; } 
        /// <summary>

        /// Hér fyrir ofan er tenging við database fyrir entity klasa samkvæmt fyrirlestri hjá Dabs...

        /// </summary>


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}