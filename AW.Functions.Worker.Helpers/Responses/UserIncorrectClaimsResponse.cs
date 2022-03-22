using AW.Functions.Worker.Helpers.Enums;
using AW.Functions.Worker.Helpers.Interfaces;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;

namespace AW.Functions.Worker.Helpers.Responses
{
  public class UserIncorrectClaimsResponse : IResponseReason<ApiResponseReason>
  {
    public async Task<HttpResponseData> Create(ApiResponseReason response, HttpRequestData req, string notes = "")
    {
      if (response != ApiResponseReason.UserIncorrectClaims) throw new ArgumentException();

      var noClaims = req.CreateResponse(HttpStatusCode.Unauthorized);
      await noClaims.WriteStringAsync($"User does not have permission to call this api. {notes}");
      return noClaims;
    }
  }

}
