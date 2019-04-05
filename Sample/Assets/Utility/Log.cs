using System;

namespace Utility
{
    public class Log
    {
        public static void Debug(string message)
        {
            UnityEngine.Debug.Log($"{DateTime.Now.ToString("HH:m:s fff")} {message}");
                
        }
        
    }
}
