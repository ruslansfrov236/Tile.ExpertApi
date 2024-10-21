
using test.data.ServiceRegistration;
using test.business.ServiceRegistration;
using Microsoft.Extensions.Options;
using test.data.Filter;
public class Program
{
    public static void Main(string[] args)
    {
       
        var builder = WebApplication.CreateBuilder(args);


        // Add services to the container.

        builder.Services.AddControllers(options =>
        {
            options.Filters.Add<ValidationFilter>();
         
        });
        builder.Services.AddDataPersistionRegistration();
        builder.Services.AddBussinessPersistionRegistration();
       
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("corsPolicy", policy =>
            {
                policy.WithOrigins("http://localhost:4200")
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials();
            });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors("corsPolicy");
       

        app.UseAuthorization();
        app.UseAuthentication();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        app.MapControllers();

        app.Run();
    }
}