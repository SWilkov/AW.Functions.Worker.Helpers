using AW.Functions.Worker.Helpers.Enums;
using AW.Functions.Worker.Helpers.Interfaces;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;

namespace AW.Functions.Worker.Helpers.Responses
{
  public class PermissionsNotFoundInSettingsResponse : IResponseReason<ApiResponseReason>
  {
    public async Task<HttpResponseData> Create(ApiResponseReason response, HttpRequestData req, string notes = "")
    {
      if (response != ApiResponseReason.PermissionsNotFoundInSettings) throw new ArgumentException();

      var notFound = req.CreateResponse(HttpStatusCode.NotFound);
      await notFound.WriteStringAsync("Could not find permissions for this api");
      return notFound;
    }
  }
}
