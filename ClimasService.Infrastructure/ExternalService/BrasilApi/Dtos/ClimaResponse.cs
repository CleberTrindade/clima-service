using System.Net;
using System.Xml.Linq;

namespace ClimasService.Infrastructure.ExternalService.BrasilApi.Dtos
{
    public class ClimaResponse<T>
    {
        public bool Success { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }
        public T? Data { get; private set; }
        public List<object>? Errors = new List<object>();

        public void AddData(T data)
        {
            Success = true;
            Data = data;
            StatusCode = HttpStatusCode.OK;
        }

        public void AddData(T data, HttpStatusCode statusCode)
        {
            AddData(data);
            SetStatusCode(statusCode);
        }

        public void AddError(object error)
        {
            Success = false;
            Errors.Add(error);
            StatusCode = HttpStatusCode.BadGateway;
        }

        public void AddError(object error, HttpStatusCode statusCode)
        {
            Errors.Add(error);
            SetStatusCode(statusCode);
        }

        private void SetStatusCode(HttpStatusCode statusCode)
        {   
            StatusCode = statusCode;
        }
    }
    public class ClimaResponse : ClimaResponse<object>
    {
        public ClimaResponse(){ }
    }
}
