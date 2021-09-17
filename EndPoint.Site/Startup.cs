using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Shop_Store.Persistence.Contexts;
using Shop_Store.Application.Interfaces.Contexts;
using Shop_Store.Application.Services.Users.Queries.GetUsers;
using Shop_Store.Application.Services.Users.Queries.GetRoles;
using Shop_Store.Application.Services.Users.Commands.RgegisterUser;
using Shop_Store.Application.Services.Users.Commands.RemoveUser;
using Shop_Store.Application.Services.Users.Commands.UserLogin;
using Shop_Store.Application.Services.Users.Commands.UserSatusChange;
using Shop_Store.Application.Services.Users.Commands.EditUser;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Shop_Store.Application.Interfaces.FacadPatterns;
using Shop_Store.Application.Services.Products.FacadPattern;
using Shop_Store.Application.Services.Common.Queries.GetMenuItem;
using Shop_Store.Application.Services.Common.Queries.GetCategory;
using Shop_Store.Application.Services.HomePages.AddNewSlider;
using Microsoft.Extensions.Hosting.Internal;
using Shop_Store.Application.Services.Common.Queries.GetSlider;
using Shop_Store.Application.Services.HomePages.AddHomePageImages;
using Shop_Store.Application.Services.Common.Queries.GetHomePageImages;
using Shop_Store.Application.Services.Carts;
using Shop_Store.Application.Services.Fainances.Commands.AddRequestPay;
using Shop_Store.Common.Roles;
using Shop_Store.Application.Services.Fainances.Queries.GetRequestPayService;
using Shop_Store.Application.Services.Orders.Commands.AddNewOrder;
using Shop_Store.Application.Services.Orders.Queries.GetUserOrders;
using Shop_Store.Application.Services.Orders.Queries.GetOrdersForAdmin;
using Shop_Store.Application.Services.Fainances.Queries.GetRequestPayForAdmin;

namespace EndPoint.Site
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAuthorization(options =>
            {
                options.AddPolicy(UserRoles.Admin, policy => policy.RequireRole(UserRoles.Admin));
                options.AddPolicy(UserRoles.Customer, policy => policy.RequireRole(UserRoles.Customer));
                options.AddPolicy(UserRoles.Operator, policy => policy.RequireRole(UserRoles.Operator));
            });

            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = new PathString("/Authentication/Signin");
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
                options.AccessDeniedPath = new PathString("/Authentication/Signin");
            });


            services.AddScoped<IDataBaseContext, DataBaseContext>();
            services.AddScoped<IGetUsersService,  GetUsersService>();
            services.AddScoped<IGetRolesService,  GetRolesService>();
            services.AddScoped<IRegisterUserService,  RegisterUserService>();
            services.AddScoped<IRemoveUserService,  RemoveUserService>();
            services.AddScoped<IUserLoginService, UserLoginService>();
            services.AddScoped<IUserSatusChangeService,  UserSatusChangeService>();
            services.AddScoped<IEditUserService,  EditUserService>();

            //FacadeInject
            services.AddScoped<IProductFacad, ProductFacad>();


            //------------------
            services.AddScoped<IGetMenuItemService, GetMenuItemService>();
            services.AddScoped<IGetCategoryService, GetCategoryService>();
            services.AddScoped<IAddNewSliderService,  AddNewSliderService>();
            services.AddScoped<IGetSliderService, GetSliderService>();
            services.AddScoped<IAddHomePageImagesService,  AddHomePageImagesService>();
            services.AddScoped<IGetHomePageImagesService, GetHomePageImagesService>();

            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IAddRequestPayService, AddRequestPayService>();
            services.AddScoped<IGetRequestPayService,  GetRequestPayService>();
            services.AddScoped<IAddNewOrderService,  AddNewOrderService>();
            services.AddScoped<IGetUserOrdersService,  GetUserOrdersService>();
            services.AddScoped<IGetOrdersForAdminService,  GetOrdersForAdminService>();
            services.AddScoped<IGetRequestPayForAdminService,  GetRequestPayForAdminService>();
       



            string contectionString = @"Data Source=DESKTOP-62N3GQT\MSSQLSERVER2019; Initial Catalog=Bugeto_StoreDb; Integrated Security=True;";
            services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(option => option.UseSqlServer(contectionString));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                   name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
