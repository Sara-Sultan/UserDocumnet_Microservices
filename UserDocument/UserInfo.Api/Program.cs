using Document.Application.DI;
using Document.Application.Extension;
using Document.Application.Interfaces.Persistence;
using Document.Application.Messaging;
using Document.Persistence.DI;
using Document.Persistence.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region Add DI
builder.Services.AddPersistenceDI(builder.Configuration);
builder.Services.AddApplicationDI(builder.Configuration);

#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if(builder.Configuration.GetValue<bool>("RunAzureBus"))
    app.UseAzureServiceBusConsumer();

app.Run();
