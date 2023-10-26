using MessengerX.WebApi.Middlewares;

namespace MessengerX.WebApi.Configurations.WebApp;

public static partial class WebApplicationExtension
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
