#nullable enable
namespace GoF
{
    public abstract class MapSite
    {
        public abstract void Enter();
    }

    public enum Direction
    {
        North,
        South,
        East,
        West
    }

    class Room : MapSite
    {
        public int RoomNumber { get; set; }
        public MapSite[] GetSides { get; set; }
        readonly MapSite[] _sides = new MapSite[4];
        int _roomNumber;

        public Room(int roomNumber)
        {
            RoomNumber = roomNumber;
            GetSides = _sides;
        }

        public override void Enter()
        {
            // Enter
        }

        public void SetSide(Direction direction, MapSite mapSite)
        {
            _sides[(int)direction] = mapSite;
        }
    }

    class Wall : MapSite
    {
        public override void Enter()
        {
            // Enter
        }
    }

    class Door : MapSite
    {
        bool _isOpen;
        readonly Room _room1;
        readonly Room _room2;
        
        public Door(Room room1, Room room2)
        {
            _room1 = room1;
            _room2 = room2;
        }

        public override void Enter()
        {
            // Enter
        }

        public Room OtherSideFrom(Room room)
        {
            return _room1 == room ? _room2 : _room1;
        }
    }

    class Maze
    {
        public void AddRoom(Room room)
        {
            // AddRoom
        }

        public Room RoomNo(int roomNo)
        {
            return new Room(roomNo);
        }

        // ...
    }

    class MazeGame
    {
        public Maze CreateMaze()
        {
            var aMaze = new Maze();
            var r1 = new Room(1);
            var r2 = new Room(2);
            var theDoor = new Door(r1, r2);

            aMaze.AddRoom(r1);
            aMaze.AddRoom(r2);

            r1.SetSide(Direction.North, new Wall());
            r1.SetSide(Direction.East, theDoor);
            r1.SetSide(Direction.South, new Wall());
            r1.SetSide(Direction.West, new Wall());

            r2.SetSide(Direction.North, new Wall());
            r2.SetSide(Direction.East, new Wall());
            r2.SetSide(Direction.South, new Wall());
            r2.SetSide(Direction.West, theDoor);
            
            return aMaze;
        }
    }
    
    // CreateMaze()の問題点はその処理が多いことではなく、柔軟さに欠けていること
    // 例えば、
    // ・DoorNeedingSpellという魔法を使うことでしか開閉できないドアを追加したい
    // ・EnchantedRoomという一風変わったアイテムが存在する部屋を追加したい
    // といった要望に対応できない。
    
    // 今回の場合は、CreateMaze()内にクラスを直接インスタンス化する処理が書かれていることが問題である。
    // Creational Patternsは具象クラスへの明示的な依存関係を削除する方法を提供する。
    // 以下にCreational Patternsの一例を示す。
    
    // ・Factory Method
    // CreateMaze()内で具象クラスのコンストラクタ
    // サブクラスがどの具象クラスをインスタンス化するかを決定するためのメソッドを提供する。
    // If CreateMaze calls virtual functions instead of constructor calls to create the rooms, walls, and doors it requires, then you can change the classes that get instantiated by making a subclass of MazeGame and redefining those virtual functions. 
    // ↑MazeGameのサブクラス作っても意味ないのでは？どゆこと？
    
    // ・Abstract Factory
    // CreateMaze()がパラメータとして、どの具象クラスをインスタンス化するかを決定するためのオブジェクトを受け取るようにすると
    // パラメータを変えることで、CreateMaze()が生成するオブジェクトの種類を変えることができる。
    
    // ・Builder
    
}