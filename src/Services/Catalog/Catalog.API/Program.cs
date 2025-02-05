var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddDbContext<CatalogContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CatalogConStr"));
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapCarter();
app.Run();


