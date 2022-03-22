using AW.Functions.Worker.Helpers.Enums;
using AW.Functions.Worker.Helpers.Interfaces;
using Microsoft.Azure.Functions.Worker.Http;

namespace AW.Functions.Worker.Helpers.Responses
{
  public class ApiResponseReasonComposite : IResponseReason<ApiResponseReason>
  {
    private readonly Dictionary<ApiResponseReason, IResponseReason<ApiResponseReason>> _services;
    public ApiResponseReasonComposite(Dictionary<ApiResponseReason, IResponseReason<ApiResponseReason>> services)
    {
      _services = services;
    }

    public async Task<HttpResponseData> Create(ApiResponseReason response, HttpRequestData req, string notes = "") =>
      await _services[response].Create(response, req, notes);
  }
}
