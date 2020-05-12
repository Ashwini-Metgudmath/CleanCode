
using System;

namespace CleanCode.DuplicatedCode
{
    public class Time
    {
        public Time(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
            
        }

        public int Hours { get; private set; }
        public int Minutes { get; private set; }

        public static Time ParseTime(string stringTime)
        {
            int hours;
            int minutes;
            if (!String.IsNullOrWhiteSpace(stringTime))
            {
                if (Int32.TryParse(stringTime.Replace(":", ""), out var time))
                {
                    hours = time / 100;
                    minutes = time % 100;
                }
                else
                {
                    throw new ArgumentException("stringTime");
                }
            }
            else
                throw new ArgumentNullException("stringTime");

            return new Time(hours, minutes);
        }
    }

    class DuplicatedCode
    {
        public void AdmitGuest(string name, string admissionDateTime)
        {
            // Some logic 
            // ...
            var time = Time.ParseTime(admissionDateTime);


            // Some more logic 
            // ...
            if (time.Hours < 10)
            {

            }
        }

        public void UpdateAdmission(int admissionId, string name, string admissionDateTime)
        {
            // Some logic 
            // ...

            var time = Time.ParseTime(admissionDateTime);


            // Some more logic 
            // ...
            if (time.Hours < 10)
            {

            }
        }
    }
}
