using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AwaiterExtensions;
using UnityEngine;

public class TryCatchAsync : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Coroutine());

        Async();
    }

    IEnumerator Coroutine()
    {
        var operation = Resources.LoadAsync<GameObject>("");
        while (!operation.isDone)
        {
            yield return null;
        }

        var cube =  operation.asset as GameObject;
        Instantiate(cube);    //ArgumentExceptionが発生する。
    }
    
    async Task Async ()
    {
        try
        {
            var cube = await Resources.LoadAsync<GameObject>("") as GameObject;
            Instantiate(cube);
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.ToString());
            Debug.LogError("Async 読み込めませんでした。");
        }
    }
}
