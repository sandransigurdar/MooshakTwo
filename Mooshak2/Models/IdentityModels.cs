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


    // Hér fyrir neðan er interface og Fake data-stöööff

    public interface IMyDataContext
    {
        IDbSet<Assignment> Assignments { get; set; }
        IDbSet<Course> Courses { get; set; }
        IDbSet<Student> Students { get; set; }
        IDbSet<Teacher> Teachers { get; set; }
        IDbSet<Admin> Admins { get; set; }
        IDbSet<AssignmentStudent> AssignmentStudents { get; set; }
        IDbSet<CourseStudent> CourseStudents { get; set; }

        int SaveChanges();
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IMyDataContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(null);
        }


            public IDbSet<Assignment>        Assignments    { get; set; }
            public IDbSet<Course>            Courses           { get; set; }
            public IDbSet<Student>           Students         { get; set; }
            public IDbSet<Teacher>           Teachers      { get; set; }
            public IDbSet<Admin>             Admins        { get; set; }
            public IDbSet<AssignmentStudent> AssignmentStudents { get; set; }
            public IDbSet<CourseStudent>     CourseStudents { get; set; }
        // <summary>

        // Hér fyrir ofan er tenging við database fyrir entity klasa samkvæmt fyrirlestri hjá Dabs...


        // </summary>


        // ^^ endirinn á DataContext stöffinu

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}