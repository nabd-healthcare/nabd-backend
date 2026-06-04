using Nabd.API.Extensions;
using Nabd.API.Hubs;
using Nabd.Application.AI.Diagnosis;
using Nabd.Shared.Extensions;
using SwaggerThemes;

var builder = WebApplication.CreateBuilder(args);

// ── Configuration Sources (ordered: base → env-specific → env vars → local override) ──
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .AddJsonFile("appsettings.Development.Local.json", optional: true, reloadOnChange: true);

// ── Startup Diagnostics ──
var connStr = builder.Configuration.GetConnectionString("DefaultConnection") ?? "(not set)";
var connPreview = connStr.Length > 40 ? connStr[..40] + "..." : connStr;
Console.WriteLine($"🌍 Environment : {builder.Environment.EnvironmentName}");
Console.WriteLine($"🗄️  Connection  : {connPreview}");

#region Infrastructure Configuration 
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddCorsConfiguration(builder.Configuration);
#endregion

#region Identity & Authentication 
builder.Services.AddIdentityConfiguration();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddAuthorizationPolicies();
#endregion

#region Application Configuration
builder.Services.AddApplicationSettings(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddUnitOfWork();
builder.Services.AddApplicationServices();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapperProfiles();
builder.Services.AddValidation();
#endregion

#region API Configuration
builder.Services.AddControllers();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddSignalR();
#endregion


var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
	app.UseSwagger();
    app.UseSwaggerUI(Theme.UniversalDark);

    // Seeding database with test users (password: Test@123)
    await app.SeedDatabaseAsync();

    // Warm up AI Model in background
    _ = app.Services.GetRequiredService<MainDiagnosisLocalModel>();
//}

app.UseHttpsRedirection();
app.UseCors("NabdCorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();

app.MapControllers();
app.MapHub<NotificationHub>("/hubs/notifications");

app.Run();
