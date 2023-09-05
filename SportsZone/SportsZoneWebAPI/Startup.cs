using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SportsZoneWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using SportsZoneWebAPI.Repositories;
using AutoMapper;
using SportsZoneWebAPI.Mappings;
using SportsZoneWebAPI.DTOs;

namespace SportsZoneWebAPI
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
            //adding connection globally
            services.AddDbContext<SportsZoneDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("SportsZoneDB"));
                options.EnableSensitiveDataLogging();
            });
            //configuring the dependency injection
            //services.AddTransient<IUserRepository, UserRepository>();//map the interface to their implementation
            services.AddScoped<SportsZoneDbContext>();
            services.AddTransient<CustomerRepository>();
            services.AddTransient<SecurityRepository>();
            services.AddTransient<CategoryRepository>();
            services.AddTransient<ProductRepository>();
            services.AddTransient<CartRepository>();
            services.AddTransient<CartItemRepository>();
            services.AddTransient<ShippingRepository>();
            services.AddTransient<PaymentRepository>();
            services.AddTransient<OrderRepository>();
            services.AddTransient<OrderItemRepository>();
            //services.AddTransient<IUserService, UserService>();
            //automapper configuration
            services.AddAutoMapper(typeof(SecurityMapping));
            var mappingConfig = new MapperConfiguration(
               mc =>  mc.AddProfile(new SecurityMapping()));
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SportsZoneWebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SportsZoneWebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
