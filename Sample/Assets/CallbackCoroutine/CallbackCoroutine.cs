using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AwaiterExtensions;
using UnityEngine;

public class CallbackCoroutine : MonoBehaviour
{
    async void Start()
    {
        StartCoroutine(LoadCoroutine("cube", o => Instantiate(o)));
        
        var cube = await LoadAsync("cube");
        Instantiate(cube);
    }

    IEnumerator LoadCoroutine(string path, Action<GameObject> callback)
    {
        var operation = Resources.LoadAsync<GameObject>(path);
        while (!operation.isDone)
        {
            yield return null;
        }

        var cube = operation.asset as GameObject;
        callback.Invoke(cube);
    }

    async Task<GameObject> LoadAsync(string path)
    {
        return await Resources.LoadAsync(path) as GameObject;
    }
}