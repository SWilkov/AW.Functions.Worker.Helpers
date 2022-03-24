using AW.Functions.Worker.Helpers.Enums;
using AW.Functions.Worker.Helpers.Interfaces;
using AW.Functions.Worker.Helpers.Responses;
using Microsoft.Extensions.DependencyInjection;

namespace AW.Functions.Worker.Helpers.Extensions
{
  public static class ServiceCollectionExtensions
  {
    public static void AddFunctionsWorkerHelpers(this IServiceCollection services)
    {
      services.AddSingleton<IResponseReason<ApiResponseReason>>(sp =>
      {
        var reasons = new Dictionary<ApiResponseReason, IResponseReason<ApiResponseReason>>
        {
          {
            ApiResponseReason.UserIncorrectClaims,
            new UserIncorrectClaimsResponse()
          },
          {
            ApiResponseReason.PermissionsNotFoundInSettings,
            new PermissionsNotFoundInSettingsResponse()
          },
          {
            ApiResponseReason.UnAuthorized,
            new UnAuthorizedResponse()
          },
          {
            ApiResponseReason.NotFound,
            new NotFoundResponse()
          },
          {
            ApiResponseReason.BadRequest,
            new BadRequestResponse()
          },
          {
            ApiResponseReason.Conflict,
            new ConflictResponse()
          }
        };

        return new ApiResponseReasonComposite(reasons);
      });
    }
  }
}
