var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
      .AddJsonOptions(options =>
      {
          options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
      });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseInMemoryDatabase(nameof(ApplicationDbContext))
    );

//cmd on project folder => dotnet add package Microsoft.EntityFrameworkCore.Proxies
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//        options.UseInMemoryDatabase(nameof(ApplicationDbContext))
//    )
//    .UseLazyLoadingProxies()); // Lazy loading proxy kullanımı


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
