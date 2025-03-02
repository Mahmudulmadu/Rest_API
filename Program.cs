using api.Controllers;
using api.Data;
using api.interfaces;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(Program)); //Auto Mapper

builder.Services.AddDbContext<AppDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();  //Add controllers
builder.Services.AddScoped<ICategoryService,CategoryService>(); //Dependency Injection by adding service

builder.Services.Configure<ApiBehaviorOptions>(options => {       // Api Error response
    options.InvalidModelStateResponseFactory = context => {
        var errors = context.ModelState
            .Where(e => e.Value?.Errors.Count > 0)
            .SelectMany(e => e.Value != null ? e.Value.Errors.Select(x => x.ErrorMessage): new List<string>()).ToList();

            return new BadRequestObjectResult(ApiResponse<object>.ErrorResponse(errors,400,"Validation failed"));
    };
});

builder.Services.AddEndpointsApiExplorer();


// Add services to the container.
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/openapi/v1.json", "Demo Api");
    });
}

app.UseHttpsRedirection();



app.MapControllers();
app.Run();
