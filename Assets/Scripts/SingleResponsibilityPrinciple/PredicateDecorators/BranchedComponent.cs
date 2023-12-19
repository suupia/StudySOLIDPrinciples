using Scripts.DecoratorPattern;
using IComponent = Scripts.CompositePattern.IComponent;

namespace Scripts.PredicateDecorators
{
    public class BranchedComponent
    {
        readonly IComponent _trueComponent;
        readonly IComponent _falseComponent;
        readonly IPredicate _predicate;
        
        public BranchedComponent(IComponent trueComponent, IComponent falseComponent, IPredicate predicate)
        {
            _trueComponent = trueComponent;
            _falseComponent = falseComponent;
            _predicate = predicate;
        }
        
        public void Something()
        {
            if (_predicate.Test())
            {
                _trueComponent.Something();
            }
            else
            {
                _falseComponent.Something();
            }
        }
    }
}