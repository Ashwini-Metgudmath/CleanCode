using System.Collections.Generic;
using CleanCode.Comments;

namespace CleanCode.OutputParameters
{
    public class GetCustomerResult
    {
        public int TotalCount { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        
    }
}