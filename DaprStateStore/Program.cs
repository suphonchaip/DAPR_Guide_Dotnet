using DaprStateStore.Infrastructures;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDaprClient(config =>
{
    var grpc_port = Environment.GetEnvironmentVariable("DAPR_GRPC_PORT") ?? "50000";

    config.UseGrpcEndpoint($"http://localhost:{grpc_port}");

    // serialize option
    var option = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
    config.UseJsonSerializationOptions(option);
});

builder.Services.AddStateStore();


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

app.Run();
