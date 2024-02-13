namespace InterfaceSegregationPrinciple
{
    interface ICrud
    {
        void Create();
        void Read();
        void Update();
        void Delete();
    }
    public class Crud: ICrud
    {
        public void Create()
        {
            // Create
        }
        public void Read()
        {
            // Read
        }
        public void Update()
        {
            // Update
        }
        public void Delete()
        {
            // Delete
        }
    }
    
    interface IRead
    {
        void Read();
    }

    interface IUpdate
    {
        void Update();
    }
   
    
    class CrudWithLogUpdate: ICrud
    {
        ICrud _crud;
        public CrudWithLogUpdate(ICrud crud)
        {
            _crud = crud;
        }
        public void Create()
        {
            // Create
            _crud.Create();
        }
        public void Read()
        {
            // Read
            _crud.Read();
        }
        public void Update()
        {
            // Update
            Log();
            _crud.Update();

            void Log()
            {
                // Log出す
            }
        }
        public void Delete()
        {
            // Delete
            _crud.Delete();
        }
    }
}