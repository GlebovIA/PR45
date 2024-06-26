using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace PR45
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "����������� ��� ������������� ��������",
                    Description = "������ ����������� ��� ������������� �������� ����������� � �������"
                });
                c.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",
                    Title = "����������� ��� ������������� ��������",
                    Description = "������ ����������� ��� ������������� �������� ����������� � �������"
                });
                c.SwaggerDoc("v3", new OpenApiInfo
                {
                    Version = "v3",
                    Title = "����������� ��� ������������� ��������",
                    Description = "������ ����������� ��� ������������� �������� ����������� � �������"
                });
                c.SwaggerDoc("v4", new OpenApiInfo
                {
                    Version = "v4",
                    Title = "����������� ��� ������������� ��������",
                    Description = "������ ����������� ��� ������������� �������� ����������� � �������"
                });
                var filePath = Path.Combine(AppContext.BaseDirectory, "ASP_GET.xml");
                c.IncludeXmlComments(filePath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "������� GET");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "������� POST");
                c.SwaggerEndpoint("/swagger/v3/swagger.json", "������� PUT");
                c.SwaggerEndpoint("/swagger/v4/swagger.json", "������� DELETE");
            });
        }
    }
}
