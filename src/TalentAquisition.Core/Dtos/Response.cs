namespace TalentAquisition.Core.Dtos
{
    public class Response<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; }
        public Exception? Exception { get; set; }

        public static Response<T> SuccessResult(T data, string message = "")
            => new() { Data = data, Success = true, Message = message };

        public static Response<T> FailureResult(string message, Exception? ex = null)
            => new() { Success = false, Message = message, Exception = ex };
    }
}