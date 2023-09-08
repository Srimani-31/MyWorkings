using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SportsZoneWebAPI.Data.Interfaces;
using SportsZoneWebAPI.Mappings.MappingProfiles;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.Repositories;
using SportsZoneWebAPI.Repositories.Interfaces;
using SportsZoneWebAPI.Services;
using SportsZoneWebAPI.Services.Interfaces;

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
            services.AddDbContext<SportsZoneDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SportsZoneDB"));
                options.EnableSensitiveDataLogging();
            });

            //configuring the dependency injection
            services.AddScoped<ISportsZoneDbContext, SportsZoneDbContext>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRespository, CustomerRepository>();
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<ISecurityRepository, SecurityRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRespository, CategoryRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartItemService, CartItemService>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<IShippingService, ShippingService>();
            services.AddScoped<IShippingRepository, ShippingRepository>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IUtil, Util>();

            //automapper configuration
            services.AddAutoMapper(typeof(SecurityMapping));
            var mappingConfig = new MapperConfiguration(
               mc =>
               {
                   mc.AddProfile(new SecurityMapping());
                   mc.AddProfile(new CustomerMapping());
                   mc.AddProfile(new CategoryMapping());
                   mc.AddProfile(new ProductMapping());
                   mc.AddProfile(new CartMapping());
                   mc.AddProfile(new CartItemMapping());
                   mc.AddProfile(new ShippingMapping());
                   mc.AddProfile(new PaymentMapping());
                   mc.AddProfile(new OrderMapping());
                   mc.AddProfile(new OrderItemMapping());
               });
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
