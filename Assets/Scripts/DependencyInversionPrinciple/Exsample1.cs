namespace DependencyInversionPrinciple
{
    // ドメイン
    public class Hero0
    {
        public int Hp { get; set; }
        HPBar0 _bar0;
        
        public Hero0(HPBar0 bar, int maxHp)
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
    public class HPBar0
    {
        public int Hp { get; set; }
        public void UpdateHp(int hp)
        {
            // HPバーを更新する処理
        }
    }
    
    // Hero0はHPBar0に依存している
}