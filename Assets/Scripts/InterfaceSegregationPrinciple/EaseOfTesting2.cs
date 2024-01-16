#nullable enable
using UnityEngine.Assertions;

namespace InterfaceSegregationPrinciple
{
    namespace EaseOfTesting1
    {
        class BeforeBankAccount
        {
            public double WithdrawMoney(double amount)
            {
                // お金を引き出す処理
                // このクラスで行うと実際に引き出されることに注意
                double actualAmount = amount;  // 残額が足りなければ、actualAmountは引き出したい金額より少なくなる
                return actualAmount;
            }
        }
        class BeforeRealMoneyAttack
        {
            readonly double _atk = 100;
            readonly BeforeBankAccount _beforeBankAccount;
            public BeforeRealMoneyAttack(BeforeBankAccount beforeBankAccount)
            {
                _beforeBankAccount = beforeBankAccount;
            }

            public void Attack(Target target)
            {
                var damageAmount = _beforeBankAccount.WithdrawMoney(_atk);
                target.SetDamage(damageAmount);
            }
            
        }

        class Target
        {
            public double Hp { get; private set; }
            public Target(double maxHp)
            {
                Hp = maxHp;
            }
            public void SetDamage(double damage)
            {
                // ダメージを受ける処理
            }
        }
        
        class ExpensiveTest
        {
            public void TestMethod()
            {
                var bankAccount = new BeforeBankAccount();
                var realMoneyAttack = new BeforeRealMoneyAttack(bankAccount);
                var target = new Target(1000);
                realMoneyAttack.Attack(target);
                Assert.AreEqual(target.Hp, 900);
                // 一回のテストで100円かかる
            }
        }
        
        /////////////////////////////////////////////
        //  テストのたびに100円かかるのは高い
        //  BankAccountクラスをスタブで差し替えられるようにする
        
        interface IBankAccount
        {
            double WithdrawMoney(double amount);
        }

        class InfiniteBankAccount : IBankAccount
        {
            public virtual double WithdrawMoney(double amount)
            {
                // 常にamount引き出せる
                return amount;
            }
        }

        class AfterBankAccount : IBankAccount  // インターフェイスを実装しておくことで差し替えができるようになる
        {
            public double WithdrawMoney(double amount)
            {
                // お金を引き出す処理
                // このクラスで行うと実際に引き出されることに注意
                double actualAmount = amount;  // 残額が足りなければ、actualAmountは引き出したい金額より少なくなる
                return actualAmount;
            }
        }
        
        class AfterRealMoneyAttack
        {
            readonly double _atk = 100;
            readonly IBankAccount _bankAccount;
            public AfterRealMoneyAttack(IBankAccount bankAccount)
            {
                _bankAccount = bankAccount;
            }

            public void Attack(Target target)
            {
                var damageAmount = _bankAccount.WithdrawMoney(_atk);
                target.SetDamage(damageAmount);
            }
            
        }
        
               
        class CostFreeTest
        {
            public void TestMethod()
            {
                var bankAccount = new InfiniteBankAccount();
                var realMoneyAttack = new AfterRealMoneyAttack(bankAccount);
                var target = new Target(1000);
                realMoneyAttack.Attack(target);
                Assert.AreEqual(target.Hp, 900);
                // 一回のテストでお金がかからない
            }
        }
    


    }
}