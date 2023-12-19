using Scripts.DecoratorPattern;
using IComponent = Scripts.CompositePattern.IComponent;

namespace Scripts.PredicateDecorators
{
    public class PredicatedComponent : IComponent
    {
        readonly IComponent _decoratedComponent;
        readonly DateTester _dateTester;
        
        public PredicatedComponent(IComponent decoratedComponent, DateTester dateTester)
        {
            _decoratedComponent = decoratedComponent;
            _dateTester = dateTester;
        }
        
        public void Something()
        {
            if (_dateTester.TodayIsAnEvenDayOfTheMonth)
            {
                _decoratedComponent.Something();
            }
        }
    }
    
    // さらに踏み込んで、DataTesterに対して、IPredeicateインターフェイスを作成してもよい
    
}