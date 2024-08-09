using Messenger.Domain.Shared.Constants.Common;
using Messenger.WebApi.Middlewares;

namespace Messenger.WebApi.ApiBuilder.ApplicationBuilder;

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
