using GWVACB_HFT_2023241.Logic;
using GWVACB_HFT_2023241.Models;
using GWVACB_HFT_2023241.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GWVACB_HFT_2023241.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<QuoteDbContext>();

            services.AddTransient<IRepository<Author>, AuthorRepository>();
            services.AddTransient<IauthorLogic, AuthorLogic>();

            services.AddTransient<IRepository<Comment>, CommentRepository>();
            services.AddTransient<ICommentLogic, CommentLogic>();

            services.AddTransient<IRepository<Quote>, QuoteRepository>();
            services.AddTransient<IQuoteLogic, QuoteLogic>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "QuoteDBApp.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieDbApp.Endpoint v1"));
            }
            app.UseCors(builder => builder
                           .AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .WithOrigins("http://localhost:4830"));

            app.UseRouting();

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { Msg = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}