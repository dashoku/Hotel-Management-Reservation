using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppCourse;

namespace WpfApp16
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
        }
        public DbSet<ClassClients> Client { get; set; }
        public DbSet<ClassRooms> Room { get; set; }
        public DbSet<ClassReceptions> Reception { get; set; }
        public DbSet<ClassLogin> Login { get; set; }
        public DbSet<ClassReservations> Reservation { get; set; }
    }
}
