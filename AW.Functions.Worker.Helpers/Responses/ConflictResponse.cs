using AW.Functions.Worker.Helpers.Enums;
using Microsoft.Azure.Functions.Worker.Http;

namespace AW.Functions.Worker.Helpers.Responses
{
  public class ConflictResponse : Interfaces.IResponseReason<ApiResponseReason>
  {
    public async Task<HttpResponseData> Create(ApiResponseReason response, HttpRequestData req, string notes = "")
    {
      if (response != ApiResponseReason.Conflict) throw new ArgumentException($"Invalid response! {response.ToString()}");

      var resp = req.CreateResponse(System.Net.HttpStatusCode.Conflict);
      await resp.WriteStringAsync($"Item already exists. {notes}");
      return resp;
    }
  }
}
