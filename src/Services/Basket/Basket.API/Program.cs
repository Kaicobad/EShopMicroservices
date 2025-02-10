var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(assembly);
    configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
    configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddCarter();
// Add services to the container.
builder.Services.AddDbContext<BasketContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("BasketConStr"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapCarter();

app.Run();


