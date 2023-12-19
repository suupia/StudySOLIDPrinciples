#nullable enable
using UnityEngine;
namespace Generic
{
    public class GenericSampleTestMono : MonoBehaviour
    {
        void Start()
        {
            // GenericClassTest();
            
            // GenericClassNeoTest();
            
            GenericMethodTest();
        }


        void GenericClassTest()
        {
            var genericClass = new GenericClass<int>(100);
            Debug.Log(genericClass.Value);
            
            var genericClass1 = new GenericClass<string>("Hello");
            Debug.Log(genericClass1.Value);

        }
        
        void GenericClassNeoTest()
        {
            var genericClass = new GenericClassNeo<int>(100);
            Debug.Log(genericClass.Value);
            
            var genericClass1 = new GenericClassNeo<string>("Hello");
            Debug.Log(genericClass1.Value);

        }

        void GenericMethodTest()
        {
            var genericMethod = new GenericMethod();
            Debug.Log(genericMethod.Identity<int>(100));
            Debug.Log(genericMethod.Identity<string>("Hello"));
            
            // 推論させて使うこともできる
            Debug.Log(genericMethod.Identity(100));
            Debug.Log(genericMethod.Identity("Hello"));
            
        }
    }
}