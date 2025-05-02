using DAL.Contracts;

namespace PL.Extention
{
    public static class InitializerExtention
    {
        public static void InitializeDatabase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            var dbInitializer = services.GetRequiredService<IDbInitializer>();
            dbInitializer.Initialize();
            dbInitializer.Seed();
        }
    }
}
