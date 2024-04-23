using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BridgeSample
{
    public class BridgeSample : MonoBehaviour
    {
        // The Abstraction defines the interface for the "control" part of the two class hierarchies.
        // It maintains a reference to an object of the Implementation hierarchy and delegates all of the real work to this object.
        abstract class Abstraction  // 抽象クラスに変更した
        {
            protected IImplementation _implementation;  // この集約がミソ
            protected Abstraction(IImplementation implementation)
            {
                _implementation = implementation;
            }

            public abstract string Operation();
        }
        
        class ConcreteAbstraction : Abstraction
        {
            public ConcreteAbstraction(IImplementation implementation) : base(implementation)
            {
                
            }

            public override string Operation()
            {
                return "ConcreateAbstraction: Extended operation with:\n" +
                       base._implementation.OperationImplementation();
            }
        }
        
        // You can extend the Abstraction without changing the Implementation classes.
        class ExtendedAbstraction : Abstraction
        {
            public ExtendedAbstraction(IImplementation implementation) : base(implementation)
            {
                
            }

            public override string Operation()
            {
                return "ExtendedAbstraction: Extended operation with:\n" +
                       base._implementation.OperationImplementation();
            }
        }
        
        // The Implementation defines the interface for all implementation classes.
        // It doesn't have to match the Abstraction's interface.
        // In fact, the two interfaces can be entirely different.
        // Typically the Implementation interface provides only primitive operations, 
        // while the Abstraction defines higher-level operations based on those primitives.
        public interface IImplementation
        {
            string OperationImplementation();
        }
        
        // Each Concrete Implementation corresponds to a specific platform and
        // implements the Implementation interface using that platform's API.
        class ConcreteImplementationA : IImplementation
        {
            public string OperationImplementation()
            {
                return "ConcreteImplementationA: The result in platform A.\n";
            }
        }

        class ConcreteImplementationB : IImplementation
        {
            public string OperationImplementation()
            {
                return "ConcreteImplementationB: The result in platform B.\n";
            }
        }
        
        class Client
        {
            // Except for the initialization phase, where an Abstraction object gets
            // linked with a specific Implementation object, the client code should
            // only depend on the Abstraction class. This way the client code can
            // support any abstraction-implementation combination.
            public void ClientCode(Abstraction abstraction)
            {
               Debug.Log(abstraction.Operation());
            }
            
            // クライアント（これはデザインパターンで出てくる単語）はAbstractionを通して、IImplementaionを使う
            // Abstractionのみに依存することに注意
        }
        
        void Start()
        {
            Client client = new Client();

            Abstraction abstraction;
            // The client code should be able to work with any pre-configured
            // abstraction-implementation combination.
            
            
            // クライアントコードでは、AbstractionとImplementationを紐づけを行う
            // ex) Abstraction:コントローラー、Implementation:テレビ
            abstraction = new ConcreteAbstraction(new ConcreteImplementationA());
            client.ClientCode(abstraction);
            
            abstraction = new ExtendedAbstraction(new ConcreteImplementationB());
            client.ClientCode(abstraction);
        }
        
    }

}
