

using HealthChecks.UI.Client;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddDbContext<CatalogContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CatalogConStr"));
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddHealthChecks().AddSqlServer(builder.Configuration.GetConnectionString("CatalogConStr"));

var app = builder.Build();


app.UseHttpsRedirection();

app.MapCarter();

app.UseExceptionHandler(option => { });

app.UseHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();


