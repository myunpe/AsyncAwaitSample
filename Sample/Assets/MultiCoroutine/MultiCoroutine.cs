using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AwaiterExtensions;
using UnityEngine;

public class MultiCoroutine : MonoBehaviour
{

    async void Start()
    {
        StartCoroutine(LoadCoroutine("cube", o => Instantiate(o)));
        StartCoroutine(LoadCoroutine("cube", o => Instantiate(o)));

        var cubes = await Task.WhenAll(LoadAsync("cube"), LoadAsync("cube"));
        Instantiate(cubes[0]);
        Instantiate(cubes[1]);
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
        return await Resources.LoadAsync<GameObject>(path) as GameObject;
    }
}
