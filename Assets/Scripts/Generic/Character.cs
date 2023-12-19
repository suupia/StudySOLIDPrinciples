#nullable enable
namespace Generic
{
    public class Character
    {
        public string Name { get; }
        public int Hp { get; }
        public int Atk { get; }
        public Character(string name, int hp, int atk)
        {
            Name = name;
            Hp = hp;
            Atk = atk;
        }
    }
    
    public class Warrior : Character
    {
        public Warrior(string name, int hp, int atk) : base(name, hp, atk)
        {
        }
    }
    
    public class Wizard : Character
    {
        public Wizard(string name, int hp, int atk) : base(name, hp, atk)
        {
        }
    }


}