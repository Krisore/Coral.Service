
using Coral.Application;
using Coral.Infrastructure;
using Coral.Service;

var builder = WebApplication.CreateBuilder(args);

#region CORAL LAYER
    builder.Services.AddCoralPresentation();
    builder.Services.AddCoralApplication();
    builder.Services.AddCoralInfrastructure(builder.Configuration);
#endregion
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorApp",
        builder => builder
            .WithOrigins("https://localhost:7054") // Replace with the URL of your Blazor app
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.UseCors("AllowBlazorApp");
app.UseAuthorization();

app.MapControllers();

app.Run();
