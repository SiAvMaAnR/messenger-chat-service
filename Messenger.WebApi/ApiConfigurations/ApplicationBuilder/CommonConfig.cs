using MessengerX.WebApi.Middlewares;

namespace MessengerX.WebApi.ApiConfigurations.ApplicationBuilder;

public static partial class ApplicationBuilderExtension
{
    public static void CommonConfiguration(this WebApplication webApplication)
    {
        webApplication.UseMiddleware<TimingMiddleware>();
        webApplication.UseCors("CorsPolicy");
        webApplication.UseHttpsRedirection();
        webApplication.UseRouting();
        webApplication.UseAuthentication();
        webApplication.UseAuthorization();
        webApplication.MapControllers();
    }
}
