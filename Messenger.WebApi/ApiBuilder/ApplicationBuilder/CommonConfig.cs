using MessengerX.Domain.Shared.Constants.Common;
using MessengerX.WebApi.Middlewares;

namespace MessengerX.WebApi.ApiBuilder.ApplicationBuilder;

public static partial class ApplicationBuilderExtension
{
    public static void CommonConfiguration(this WebApplication webApplication)
    {
        webApplication.UseMiddleware<TimingMiddleware>();
        webApplication.UseCors(CorsPolicyName.Default);
        webApplication.UseHttpsRedirection();
        webApplication.UseRouting();
        webApplication.UseAuthentication();
        webApplication.UseAuthorization();
        webApplication.MapControllers();
    }
}
