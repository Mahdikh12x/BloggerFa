namespace _0_Framework.Application
{
    public class OperationResult
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public OperationResult()
        {
            IsSuccess = false;
        }
        public OperationResult Succeeded(string message = "The Operation Is Done SuccessFully")
        {
            IsSuccess = true;
            Message = message;
            return this;
        }
        public OperationResult Failed(string message)
        {
            IsSuccess = false;
            Message = message;
            return this;
        }
    }
}
