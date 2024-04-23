using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdapterSample
{
    // The Target defines the domain-specific interface used by the client code.
    public interface ITarget
    {
        (int ,string) GetRequest();
    }
    
    // The Adaptee contains some useful behaviour, but its interface is incompatible with the existing client code.
    // The Adaptee needs some adaptation before the client code can use it.
    class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Specific request.";
        }
    }
    
    // The Adapter makes the Adaptee's interface compatible with the Target's interface.
    class Adapter : ITarget
    {
        readonly int _id;
        readonly Adaptee _adaptee;

        public Adapter(int id, Adaptee adaptee)
        {
            _id = id;
            _adaptee = adaptee;
        }

        public (int ,string) GetRequest()
        {
            return  (_id, $"This is '{_adaptee.GetSpecificRequest()}'");
        }
    }
    
    class AdapterSampleClient : MonoBehaviour
    {
        void Start()
        {
            Debug.Log("Client: I can work just fine with the Target objects:");
            ITarget target = new Adapter(1, new Adaptee());
            Debug.Log(target.GetRequest());
        }
    }

}

