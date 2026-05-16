var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/ OpenAPI at https://aka.ms/aspnetcore/swashbucle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";

app.Urls.Add($"https://+:{port}");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwagerUI();
}

//app.UseHttpsRedirection();

app.MapControllers();

app.Run();
