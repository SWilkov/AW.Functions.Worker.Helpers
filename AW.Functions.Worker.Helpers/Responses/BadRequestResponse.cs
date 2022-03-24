using AW.Functions.Worker.Helpers.Enums;
using Microsoft.Azure.Functions.Worker.Http;

namespace AW.Functions.Worker.Helpers.Responses
{
  public class BadRequestResponse : Interfaces.IResponseReason<ApiResponseReason>
  {
    public async Task<HttpResponseData> Create(ApiResponseReason response, HttpRequestData req, string notes = "")
    {
      if (response != ApiResponseReason.BadRequest) throw new ArgumentException($"Invalid response! {response.ToString()}");

      var resp = req.CreateResponse(System.Net.HttpStatusCode.BadRequest);
      await resp.WriteStringAsync($"Bad Request. {notes}");
      return resp;
    }
  }
}
