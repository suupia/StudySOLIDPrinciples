using System;

namespace DependencyInversionPrinciple
{
    // ドメイン
    public class Hero0
    {
        int _hp;
        public int Hp
        {
            get => _hp;
            set
            {
                _hp = value;
                _updateHp?.Invoke(_hp);
            }
        }
        Action<int> _updateHp;
        
        public void Subscribe(Action<int> updateHp)
        {
            _updateHp = updateHp;
        }
        
        HPBar0 _bar0;
        
        public Hero0(HPBar0 bar, int maxHp)
        {
            _bar0 = bar;
            Hp = maxHp;
        }
        
        public void SetDamage(double damage)
        {
            Hp -= (int)damage;
        }
    }

    public class Client
    {
        public void Main()
        {
            var bar = new HPBar0();
            var hero = new Hero0(bar, 100);
            hero.Subscribe(bar.UpdateHp);
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