using System;

namespace CleanCode.NestedConditionals
{
    public class Reservation
    {
        public Reservation(Customer customer, DateTime dateTime)
        {
            From = dateTime;
            Customer = customer;
        }

        public DateTime From { get; set; }
        public Customer Customer { get; set; }
        public bool IsCanceled { get; set; }

        public void Cancel()
        {
            if(IsReservationPeriodOver())
                throw new InvalidOperationException("It's too late to cancel.");

            IsCanceled = true;
        }

        private bool IsReservationPeriodOver()
        {
            return (Customer.IsGoldCustomer() && LessThan(24)) || 
                   !Customer.IsGoldCustomer() && LessThan(48);
        }

        private bool LessThan(int maxHours)
        {
            return (From - DateTime.Now).TotalHours < maxHours;
        }
    }
}