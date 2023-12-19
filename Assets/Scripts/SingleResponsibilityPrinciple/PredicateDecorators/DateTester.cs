using System.Data;

namespace Scripts.PredicateDecorators
{
    public class DateTester
    {
        public bool TodayIsAnEvenDayOfTheMonth
        {
            get
            {
                return System.DateTime.Now.Day % 2 == 0;
            }
        }
    }
}