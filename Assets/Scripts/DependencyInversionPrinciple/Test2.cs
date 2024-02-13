using LiskovsSubstitutionPrinciple;
using UnityEngine.Assertions;

namespace DependencyInversionPrinciple
{
    public class Test2
    {
        public void SlimeAttackTest()
        {
            // Arrange
            var stabHpBar = new StabHPBar();
            var hero = new Hero1(new StabHPBar(), 100);
            var slime = new Slime(10);
            var beforeHp = hero.Hp;
            
            // Act
            slime.Attack(hero);
            var afterHp = hero.Hp;
            
            // Assert
            Assert.AreEqual(beforeHp- 10, afterHp); 
        }
        class StabHPBar : IUpdateHp
        {
            public void UpdateHp(int hp)
            {
                // 処理なし
            }
        }
    }
    


    public class Slime
    {
        readonly int _atk;

        public Slime(int atk)
        {
            _atk = atk;
        }
        public void Attack(Hero1 hero)
        {
            hero.SetDamage(_atk);
        }
    }
}