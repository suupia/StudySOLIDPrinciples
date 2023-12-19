using Scripts.DecoratorPattern;

namespace Scripts.PredicateDecorators
{
    public class PredicatedDecoratorExampleOrigin
    {
        readonly IComponent _component;
        public PredicatedDecoratorExampleOrigin(IComponent component)
        {
            _component = component;
        }

        public void Run()
        {
            DateTester dateTester = new DateTester();
            if (dateTester.TodayIsAnEvenDayOfTheMonth)
            {
                _component.Something();
                
            }
        }
    }
}