using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SocialMediaAPI;
using SocialMediaAPI.Repository;
using System.Text.Json.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddDbContext<SocialMediaAPI.Data.DbInitializer>(options => options.UseInMemoryDatabase("Db"));
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        

        builder.Services.AddMvc().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        });
        builder.Services.AddScoped<IAccountRepository, AccountRepository>();
       // builder.Services.AddScoped<ICommentRepository, CommentRepository>();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        app.Run();
    }
}