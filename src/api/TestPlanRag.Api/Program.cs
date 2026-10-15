var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHealthChecks();
builder.Services.AddOpenApi();
// builder.Services.AddHealthChecks()
//         .AddNpgSql(connectionString, name: "postgres", tags: ["readyz"]);
// builder.Services.AddOpenApi();

var app = builder.Build();
app.MapHealthChecks("/healthz");
app.MapHealthChecks("/readyz");
// app.MapHealthChecks("/healthz", new HealthCheckOptions{
//     Predicate = check => !check.Tags.Contains("readyz")
// });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();  
}

app.UseHttpsRedirection();

app.Run();
