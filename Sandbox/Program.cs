using System;

namespace Sandbox
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var service = new Service();

            var date = DateTime.Now.AddMinutes(10);
            var results = TryUpdate();  
            
            service.DoSomething(results, date);
        }

        private static Results TryUpdate()
        {
            // bool isSuccess = true;
            // var docs = GetGocs()
            // bool hasDocs = docs.IsAny()
            // foreach( doc in docs )
            // {
            //     do something
            //     if error isSuccesss = false  
            // }
            
            return new Results
            {
                IsSuccess = true,
                HasNoDocuments = true,
            };
        }
    }

    public class Results
    {
        public bool IsSuccess { get; set; }
        public bool HasNoDocuments { get; set; }
    }
    
    public class Service
    {
        public void DoSomething(Results results, DateTime date)
        {
            if (results.IsSuccess && results.HasNoDocuments && IsRetryable(date))
            {
                Console.WriteLine("Do some action");
            }
        }

        private bool IsRetryable(DateTime date)
        {
            return date > DateTime.Now;
        }
    }

    public interface IRetry
    {
        void Execute();
    }

    public class RetryState
    {
        public void Retry()
        {
            // Retry
        }
    }

    public class DontRetryState
    {
        public void Retry() {}
    }
}