using AW.Functions.Worker.Helpers.Enums;
using AW.Functions.Worker.Helpers.Interfaces;
using Microsoft.Azure.Functions.Worker.Http;

namespace AW.Functions.Worker.Helpers.Responses
{
  public class UnAuthorizedResponse : IResponseReason<ApiResponseReason>
  {
    public async Task<HttpResponseData> Create(ApiResponseReason response, HttpRequestData req, string notes = "")
    {
      if (response != ApiResponseReason.UnAuthorized) throw new ArgumentException();

      var resp = req.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
      await resp.WriteStringAsync($"Unauthorized access detected. {notes}");
      return resp;
    }
  }
}
