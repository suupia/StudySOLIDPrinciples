using Scripts.DecoratorPattern;

namespace Scripts.PredicateDecorators
{
    public class PredicatedDecoratorExampleBad
    {
        readonly IComponent _component;
        public PredicatedDecoratorExampleBad(IComponent component)
        {
            _component = component;
        }

        // 部分的な解決策に過ぎない
        // Runメソッドにパラメーターを渡すことを要求すると、クライアントのパブリックインターフェイスが破壊され、そのクライアントがDateTesterクラスの実装を提供する必要が出てくる
        // Decoratorパターンを利用すれば、クライアントのインターフェイスを同じに保ったまま、条件付きで実行する機能を維持できます。
        public void Run(DateTester dateTester)
        {
            if (dateTester.TodayIsAnEvenDayOfTheMonth)
            {
                _component.Something();
                
            }
        }
    }
}