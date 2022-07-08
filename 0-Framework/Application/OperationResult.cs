namespace _0_Framework.Application
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Table { get; set; }
        public string Data { get; set; }
        public string Operation { get; set; }
        public DateTime OperationDate { get; set; }

        public OperationResult(string table)
        {
            Table = table;
            Success = false;
            OperationDate = DateTime.Now;

        }

        public OperationResult(string table, string operation)
        {
            Operation = operation;
            Table = table;
            Success = false;
            OperationDate = DateTime.Now;
        }

        public OperationResult But(string table)
        {
            return new OperationResult(table);
        }

        public OperationResult SetData(string data)
        {
            Data = data;
            return this;
        }

        public OperationResult Succeeded(string message)
        {
            Message = message;
            Success = true;
            return this;
        }

        public OperationResult Failed(string message)
        {
            Message = message;
            return this;
        }
    }
}
