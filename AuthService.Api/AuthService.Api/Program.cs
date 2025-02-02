using AuthService.Infraestructure.ioc;
using AuthService.Infraestructure.utils;
using AuthService.Infraestructure.extension;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("cors", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfractructure(builder.Configuration);

builder.Services.AddHttpClient();

var app = builder.Build();

GenerateToken.Initialize(builder.Configuration);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.ConfigureExceptionHandler();

app.MapControllers();


app.Run();

