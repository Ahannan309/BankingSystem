namespace BankingSystem.Helper
{
    public class ResultMessage<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public T? entity { get; set; }

    }
}
