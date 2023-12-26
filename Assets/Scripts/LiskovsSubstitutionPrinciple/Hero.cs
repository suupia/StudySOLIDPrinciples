#nullable enable
namespace LiskovsSubstitutionPrinciple
{
    public class Hero
    {
        public int Hp { get; set; }
        public int Atk { get; set; }

        readonly BaseAttack _onAttack;
        
        public Hero(BaseAttack onAttack)
        {
            _onAttack = onAttack;
        }

        public void Attack(IHpSetter target)
        {
            _onAttack.OnAttack(target, Atk);
        }
    }
}