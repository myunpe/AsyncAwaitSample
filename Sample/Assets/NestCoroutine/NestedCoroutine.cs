using System;
using System.Collections;
using System.Collections.Generic;
using AwaiterExtensions;
using UnityEngine;
using UnityEngine.Networking;

public class NestedCoroutine : MonoBehaviour
{
    async void Start()
    {
        StartCoroutine(RequestCoroutine(() =>
        {
            StartCoroutine(LoadCoroutine("cube", (cube) =>
            {
                Instantiate(cube);
            }));
        }));

        var webRequest = await UnityWebRequest.Get("http://google.co.jp").SendWebRequest();
        Debug.Log($"downloadtext={webRequest.downloadHandler.text}"); 
        var cubeObject = await Resources.LoadAsync<GameObject>("cube");
        Instantiate(cubeObject);

    }


    IEnumerator RequestCoroutine(Action callback)
    {
        var request = UnityWebRequest.Get("http://google.co.jp").SendWebRequest();
        while (!request.isDone)
        {
            yield return null;
        }

        var text = request.webRequest.downloadHandler.text;
        Debug.Log($"text={text}");
        
        callback.Invoke();
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
}
