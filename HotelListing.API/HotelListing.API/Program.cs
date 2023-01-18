using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    // Configure CORS
    options.AddPolicy("AllowAll",
        b => b.AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod()
    );
});

builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));
// ctx => Builder context i.e. representation of builder (We can do all th things using ctx which can be done by using builder)
// lc => Logger Configuration.


var app = builder.Build();

// Configure the HTTP request pipeline. / Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseCors("AllowAll"); // Using the CORS which we are configured above.

app.UseAuthorization();

app.MapControllers();

app.Run();

f