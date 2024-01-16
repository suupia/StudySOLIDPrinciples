namespace LiskovsSubstitutionPrinciple
{
    public interface IHpSetter
    {
        int Hp { get; set; }
    }
    interface IOnAttack
    {
        void OnAttack(IHpSetter hpSetter, int damage);
    }

}