namespace BankingSystem.Helper
{
    public class ResultMessage<T>
    {
        public bool Status { get; set; }

        public string Details { get; set; }
        public T Content { get; set; }

    }
}
