#nullable enable
namespace Scripts.DecoratorPattern
{
    public class DecoratorComponent : IComponent
    {
        readonly IComponent _decoratedComponent;
        
        public DecoratorComponent(IComponent decoratedComponent)
        {
            _decoratedComponent = decoratedComponent;
        }

        public void Something()
        {
            SomethingElse();
            _decoratedComponent.Something();
        }
        
        void SomethingElse()
        {
            // なんかしらの処理
        }
    }
}