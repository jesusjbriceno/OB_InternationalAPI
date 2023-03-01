var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// 1. LOCALIZATION
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// 2. SUPPORTED CULTURES
var suportedCutltures = new[] { "en-US", "es-ES", "fr-FR" }; // USA English, Spain spanish, Frnace french
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(suportedCutltures[0])        // English by default
    .AddSupportedCultures(suportedCutltures)        // Add all supported cultures
    .AddSupportedUICultures(suportedCutltures);     // Add supported cultures to UI


// 3. ADD LOCALIZATION TO APP
app.UseRequestLocalization(localizationOptions);


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
