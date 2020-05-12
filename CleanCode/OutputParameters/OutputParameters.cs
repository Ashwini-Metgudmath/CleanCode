﻿using CleanCode.Comments;
using System;
using System.Collections.Generic;

namespace CleanCode.OutputParameters
{
    public class GetCustomerResult
    {
        public int TotalCount { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        
    }

    public class OutputParameters
    {
        public void DisplayCustomers()
        {
            const int pageIndex = 1;
            var result = GetCustomers(pageIndex);

            Console.WriteLine("Total customers: " + result.TotalCount);
            foreach (var c in result.Customers)
                Console.WriteLine(c);
        }

        public GetCustomerResult GetCustomers(int pageIndex)
        {
            var totalCount = 100;
            return new GetCustomerResult() {TotalCount = totalCount, Customers = new List<Customer>()};
        }
    }
}
