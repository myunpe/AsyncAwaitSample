using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using AwaiterExtensions;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class AwaitSample : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        var stopWatch = Stopwatch.StartNew();
        Debug.Log($"time : {stopWatch.ElapsedMilliseconds}ms");
        var cube = await Resources.LoadAsync("Cube");
        Debug.Log($"time : {stopWatch.ElapsedMilliseconds}ms");
        Instantiate(cube);
        Debug.Log($"time : {stopWatch.ElapsedMilliseconds}ms");
        stopWatch.Stop();
    }


    
}