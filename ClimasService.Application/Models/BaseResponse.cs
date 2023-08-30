using System.Net;

namespace ClimasService.Application.Models
{
    public class BaseResponse<T>
    {
        public bool Success { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }
        public T? Data { get; private set; }

        public List<T> Errors { get; private set; }

        public BaseResponse()
        {
        }
        public BaseResponse(T data)
        {
            AddData(data);
        }
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
        public void AddError(T error)
        {
            if (Errors == null) Errors = new List<T>();

            Success = false;
            Errors.Add(error);
            StatusCode = HttpStatusCode.BadRequest;
        }

        public void AddError(T error, HttpStatusCode statusCode)
        {
            AddError(error);
            SetStatusCode(statusCode);
        }

        public void SetStatusCode(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
    public class BaseResponse : BaseResponse<object>
    {
        public BaseResponse()
        {

        }
    }
}
