using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class DeviceContext : DbContext
    {
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }

        public DeviceContext() { }

        public DeviceContext(DbContextOptions<DeviceContext> options) : base(options) { }


    }
}
