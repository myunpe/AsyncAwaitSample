using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Utility;

public class CroutineToAsyncSample : MonoBehaviour
{
    
//    14:25:58 269 Sample1 Start
//    14:25:58 286 Sample1Async Start
//    14:26:1 320 Sample1Async End
//    14:26:1 815 Sample1 End
   
    void Start()
    {
        Log.Debug("start start");
        StartCoroutine(Sample1());

        var t = Sample1Async();
        Log.Debug("start end");
    }

    IEnumerator Sample1()
    {
        Log.Debug("Sample1 Start");
        yield return new WaitForSeconds(3);
        Log.Debug("Sample1 End");
    }

    async Task Sample1Async()
    {
        Log.Debug("Sample1Async Start" + Thread.CurrentThread.Name);
        await Task.Delay(3000);
        Log.Debug("Sample1Async End" + Thread.CurrentThread.Name);
    }
}
