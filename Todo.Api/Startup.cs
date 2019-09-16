using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Todo.Data.Interfaces;
using Todo.Data.Repositories;
using Todo.Services;
using Todo.Services.Interfaces;

namespace Todo.Api
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
            services.Configure<Todo.Data.Common.MongoDatabaseSettings>(Configuration.GetSection(nameof(Todo.Data.Common.MongoDatabaseSettings)));

            services.AddSingleton<Todo.Data.Interfaces.IMongoDatabaseSettings>(sp => sp.GetRequiredService<IOptions<Todo.Data.Common.MongoDatabaseSettings>>().Value);
            
            // Services
            services.AddScoped<ITodoService, TodoService>();

            // Repositories
            services.AddScoped<ITodoRepository, TodoRepository>();
            
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(builder =>
                builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
            );
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
