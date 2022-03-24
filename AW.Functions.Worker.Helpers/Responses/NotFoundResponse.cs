using AW.Functions.Worker.Helpers.Enums;
using Microsoft.Azure.Functions.Worker.Http;

namespace AW.Functions.Worker.Helpers.Responses
{
  public class NotFoundResponse : Interfaces.IResponseReason<ApiResponseReason>
  {
    public async Task<HttpResponseData> Create(ApiResponseReason response, HttpRequestData req, string notes = "")
    {
      if (response != ApiResponseReason.NotFound) throw new ArgumentException($"Invalid response! {response.ToString()}");

      var resp = req.CreateResponse(System.Net.HttpStatusCode.NotFound);
      await resp.WriteStringAsync($"Not Found. {notes}");
      return resp;
    }
  }
}
