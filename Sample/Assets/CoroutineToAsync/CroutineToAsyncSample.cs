using System.Collections;
using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;
using Utility;
using Debug = UnityEngine.Debug;

public class CroutineToAsyncSample : MonoBehaviour
{
    void Start()
    {
//        StartCoroutine(SomeMethodCroutine());
        SomeMethodAsync();
    }

    IEnumerator SomeMethodCroutine()
    {
        yield return new WaitForSeconds(1.0f);
    }

    async Task SomeMethodAsync()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        await Task.Delay(1000);
        
        Debug.Log("watch : " + stopwatch.ElapsedMilliseconds);
    }
}