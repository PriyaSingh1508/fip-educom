
using Azure.Storage.Blobs;
using Edu.BLL.Configuration;

using Edu.Security.Configuration;


using Microsoft.Extensions.Configuration;
using Edu.Services.Service;
using Edu.Shared.Interfaces.IServices;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader().AllowAnyMethod())
);
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connectionString != null)
{
    builder.Services.RegisterServices(connectionString);
}


builder.Services.AddScoped(_ => { return new BlobServiceClient(builder.Configuration.GetConnectionString("AzureBlobStorage")); }); 
builder.Services.AddScoped<IImageService,ImageService>();
builder.Services.AddScoped<IBlobService,BlobService>();


builder.Services.AddCustomAuthExtension();

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod())
);
builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(builder.Configuration["ConnectionStrings:AzureBlobStorage:blob"], preferMsi: true);
    clientBuilder.AddQueueServiceClient(builder.Configuration["ConnectionStrings:AzureBlobStorage:queue"], preferMsi: true);
});
var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
