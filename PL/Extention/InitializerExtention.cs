using DAL.Contracts;

namespace PL.Extention
{
    public static class InitializerExtention
    {
        public static void InitializeDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var dbInitializer = services.GetRequiredService<IDbInitializer>();
            dbInitializer.Initialize();
            dbInitializer.Seed();
        }
    }
}
