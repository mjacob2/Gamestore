using System.Text.Json.Serialization;
using Gamestore.API;
using Gamestore.API.Middleware;
using Gamestore.ApplicationServices;
using Gamestore.ApplicationServices.Mappings;
using Gamestore.ApplicationServices.Responses;
using Gamestore.ApplicationServices.Services.BankPaymentMethod;
using Gamestore.ApplicationServices.Services.GameAliasService;
using Gamestore.ApplicationServices.Services.GameHandlerService;
using Gamestore.ApplicationServices.Services.PayOrderService;
using Gamestore.ApplicationServices.Services.RDPaymentService;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Mongo;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder
                .WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .WithExposedHeaders("X-Games-Count")
                .AllowCredentials()
                .AllowAnyMethod();
        });
});

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

builder.Services.AddDbContext<GamestoreDbContext>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("GamestoreDbConnection")));
builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(ResponseBase<>)));
builder.Services.AddAutoMapper(typeof(GamesProfile).Assembly);
builder.Services.AddTransient<IGameAliasService, GameAliasService>();
builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();
builder.Services.AddTransient<IMongoQueryExecutor, MongoQueryExecutor>();
builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();
builder.Services.AddTransient<GamesCountMiddleware>();
builder.Services.AddTransient<IBankPaymentMethod>(_ => new BankPaymentMethod(builder.Configuration.GetValue<int>("DefaultInvoiceValidity")));
builder.Services.AddTransient<IRdPaymentApiConnector, RdPaymentApiConnector>();
builder.Services.AddScoped<IGameHandlerService, GameHandlerService>();
builder.Services.AddScoped<IPayOrderService, PayOrderService>();
builder.Logging.AddNLog();

var app = builder.Build();

// Seeding code
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<GamestoreDbContext>();
    await new Seed(context).Run();
}

// app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();

app.UseAuthorization();

app.UseMiddleware<RequestLoggingMiddleware>();

app.UseMiddleware<GamesCountMiddleware>();

app.MapControllers();

app.Run();
