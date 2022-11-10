using CommonLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<EmployeeDetail> EmployeeDetail { get; set; }
        public DbSet<UserDetail> UserDetail { get; set; }
        public DbSet<TimeDetail> TimeDetail { get; set; }
        public DbSet<DesignationDetail> DesignationDetail { get; set; }
        //public DbSet<PaymentDetail> PaymentDetail { get; set; }
        public DbSet<LeaveDetail> LeaveDetail { get; set; }
    }
}
