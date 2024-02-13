namespace DependencyInversionPrinciple
{
    // ドメイン
    public class Hero1
    {
        public int Hp { get; set; }
        IUpdateHp _bar0;
        
        public Hero1(IUpdateHp bar, int maxHp)
        {
            _bar0 = bar;
            Hp = maxHp;
            _bar0.UpdateHp(maxHp);
        }
        
        public void SetDamage(double damage)
        {
            Hp -= (int)damage;
            _bar0.UpdateHp(Hp);
        }
    }
    
    // UI
    public interface IUpdateHp
    {
        void UpdateHp(int hp);
    }
    public class HPBar1 : IUpdateHp
    {
        public int Hp { get; set; }
        public void UpdateHp(int hp)
        {
            // HPバーを更新する処理
        }
    }
    
    // 依存性の逆転を利用した。
}