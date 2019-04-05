using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UniRx.Async;
using UnityEngine;
using Utility;

public class CroutineToAsyncSample : MonoBehaviour
{
    
//    14:25:58 269 Sample1 Start
//    14:25:58 286 Sample1Async Start
//    14:26:1 320 Sample1Async End
//    14:26:1 815 Sample1 End

    private void Start()
    {
        Log.Debug("start start");
        StartCoroutine(Sample1());

        var t = Sample1Async();
        Log.Debug("start end");
    }

    private IEnumerator Sample1()
    {
        Log.Debug("Sample1 Start");
        yield return new WaitForSeconds(3);
        Log.Debug("Sample1 End");
    }

    private async Task Sample1Async()
    {
        Log.Debug("Sample1Async Start" + Thread.CurrentThread.Name);
        await Task.Delay(3000);
        Log.Debug("Sample1Async End" + Thread.CurrentThread.Name);
    }

    private async void Sample1UniAsync()
    {
        await UniTask.Delay(3000);
    }


    private async Lib.TaskLike<int> LikeAsync()
    {
        await Task.Delay(3000);
        return 100;
    }
}
