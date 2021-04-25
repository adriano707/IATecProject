using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Schedule.Data
{
   public static class DataStartup
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<ScheduleContext>(opt => opt.UseSqlServer("server=localhost;user id=sa;password=21080621;database=db_iatec"));

            services.AddScoped<ScheduleContext>();
        }
    }
}
