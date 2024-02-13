using UnityEngine;
using UnityEngine.UIElements;

namespace DependencyInversionPrinciple
{
    public class Sample
    {
        
    }
    
    
    public class MyLog : IMyLog
    {
        public void Log()
        {
            // ログを出力する処理
            var debug = new ThirdPartyLibrary();
            debug.Debug();
        }
    }
    
    public interface IMyLog
    {
        void Log();
    }

    // ライブラリ1
    public interface IDebug
    {
        void Debug();
    }
    
    public class ThirdPartyLibrary : IDebug
    {
        public void Debug()
        {
            // デバッグを出力する処理
        }
    }
    
    // ライブラリ2
    public interface ILog
    {
        void Log();
    }
    
    public class ThirdPartyLibrary2 : ILog
    {
        public void Log()
        {
            // ログを出力する処理
        }
    }
}