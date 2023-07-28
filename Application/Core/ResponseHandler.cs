namespace Application.Core
{
  public class ResponseHandler<T>
  {
    public bool Success { get; set; }
    public string ErrorMessage { get; set; }
    public bool NotFound { get; set; }
    public string Message { get; set; }
    public T Value { get; set; }

    public static ResponseHandler<T> SuccessResponse(T value) => new ResponseHandler<T> { Success = true, Value = value };

    public static ResponseHandler<T> FailResponse(string errorMessage) => new ResponseHandler<T> { Success = false, ErrorMessage = errorMessage };

    public static ResponseHandler<T> NotFoundResponse(string modelName) => new ResponseHandler<T> { NotFound = true, Message = modelName + " not found" };
  }
}