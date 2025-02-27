using BuildingBlocks.Exceptions.Handler;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(assembly);
    configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
    configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddCarter();
builder.Services.AddMarten(op =>
{
    op.Connection(builder.Configuration.GetConnectionString("BasketConStr"));
    op.Schema.For<ShoppingCart>().Identity(x => x.UserName);

}).UseLightweightSessions();
// Add services to the container.

builder.Services.AddScoped<IBasketRepositoryService, BasketRepositoryService>();
builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapCarter();
app.UseExceptionHandler(options => { });

app.Run();


