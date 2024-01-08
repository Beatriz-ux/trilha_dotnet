namespace CleanArchitecture.WebAPI.Extensions
{
    public static class CorsPolicyExtensions
    {
        public static void ConfiguraCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
    }
}
