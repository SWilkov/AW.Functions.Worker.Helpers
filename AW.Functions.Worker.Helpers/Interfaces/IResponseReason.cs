using Microsoft.Azure.Functions.Worker.Http;

namespace AW.Functions.Worker.Helpers.Interfaces
{
  public interface IResponseReason<T> where T: Enum
  {
    Task<HttpResponseData> Create(T response, HttpRequestData req, string notes = "");
  }
}
