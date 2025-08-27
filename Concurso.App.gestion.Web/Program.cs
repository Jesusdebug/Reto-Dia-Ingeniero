
using Concurso.App.gestion.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Cadena de conexión SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=(localdb)\\MSSQLLocalDB;Database=GestionaAppDbV2;Trusted_Connection=True;TrustServerCertificate=True";

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAppServices(connectionString);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Seed de datos
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<Concurso.App.gestion.Infrastructure.AppDbContext>();
    Concurso.App.gestion.Infrastructure.SeedData.Initialize(db);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
