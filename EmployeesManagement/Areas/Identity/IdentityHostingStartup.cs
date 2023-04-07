//using System;
//using EmployeesManagement.Areas.Identity.Data;
//using EmployeesManagement.Data;
//using EmployeesManagement.Models;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.UI;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;

//[assembly: HostingStartup(typeof(EmployeesManagement.Areas.Identity.IdentityHostingStartup))]
//namespace EmployeesManagement.Areas.Identity
//{
//    public class IdentityHostingStartup : IHostingStartup
//    {
//        public void Configure(IWebHostBuilder builder)
//        {
//            builder.ConfigureServices((context, services) => {
//                services.AddDbContext<EmployeeDbContext>(options =>
//                    options.UseSqlServer(
//                        context.Configuration.GetConnectionString("DefaultConnection")));

//                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
//                    .AddEntityFrameworkStores<EmployeeDbContext>();
//            });

//        }
//    }
//}