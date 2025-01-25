using System;

namespace GondorsLegacy.Services.External;

public class AdapterResponse<T>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }

    public AdapterResponse(bool isSuccess, string message, T data = default)
    {
        IsSuccess = isSuccess;
        Message = message;
        Data = data;
    }
}
