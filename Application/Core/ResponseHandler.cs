using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Core
{
  public class ResponseHandler<T>
  {
    public bool Success { get; set; }
    public string ErrorMessage { get; set; }
    public T Value { get; set; }

    public static ResponseHandler<T> SuccessResponse(T value) => new ResponseHandler<T> { Success = true, Value = value };

    public static ResponseHandler<T> FailResponse(string errorMessage) => new ResponseHandler<T> { Success = false, ErrorMessage = errorMessage };
  }
}