
using Coral.Application;
using Coral.Infrastructure;
using Coral.Service;

var builder = WebApplication.CreateBuilder(args);

#region CORAL LAYER
    builder.Services.AddCoralPresentation();
    builder.Services.AddCoralApplication();
    builder.Services.AddCoralInfrastructure(builder.Configuration);
#endregion


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
