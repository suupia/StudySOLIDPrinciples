using Scripts.DecoratorPattern;

namespace Scripts.PredicateDecorators
{
    public class PredicatedDecoratorExampleGood
    {
        readonly IComponent _component;
        public PredicatedDecoratorExampleGood(IComponent component)
        {
            _component = component;
        }


        public void Run()
        {
            _component.Something();
        }
    }
}