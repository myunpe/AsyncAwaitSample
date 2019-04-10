using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UniRx.Async;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
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
        StartCoroutine(SomeMethodCroutine());

        var t = SomeMethodAsync();
        Log.Debug("start end");

        Log.Debug("unitask async");
   }

    void SomeMethod()
    {
        
    }

    private IEnumerator SomeMethodCroutine()
    {
        yield return null;
    }

    private async Task SomeMethodAsync()
    {
        
    }
}
