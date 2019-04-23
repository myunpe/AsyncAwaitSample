using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class CancelCoroutine : MonoBehaviour
{
//    void Start()
//    {
//        var task = TaskCoroutine();
//        StartCoroutine(EffectCoroutine());
//        StopCoroutine(task);
//    }
//
//    IEnumerator TaskCoroutine()
//    {
//        yield return new WaitForSeconds(1.0f);
//        //ストップされるとここにはこない
//    }

    void Start()
    {
        var cancellationTokenSource = new CancellationTokenSource();
        WaitAsync(cancellationTokenSource.Token);
        cancellationTokenSource.Cancel();
    }
    async Task WaitAsync(CancellationToken cancellationToken)
    {
        try
        {
            await Task.Delay(1000, cancellationToken);
        }
        catch (Exception ex)
        {
            //System.Threading.Tasks.TaskCanceledException: A task was canceled.
        }
        
        if (cancellationToken.IsCancellationRequested)
        {
            Debug.Log("cancelされました。");
        }
    }

    int effectIndex = 0;
    List<IEnumerator> effects = new List<IEnumerator>();

    public void OnClickTap()
    {
        if (effectIndex < (effects.Count - 1))
        {
            StopCoroutine(effects[0]);
        }
    }

    IEnumerator EffectCoroutine()
    {
        Stopwatch watch = Stopwatch.StartNew();
        effectIndex = 0;
        effects.Add(Effect1());
        effects.Add(Effect2());
        effects.Add(Effect3());
        yield return StartCoroutine(effects[0]);
        Debug.Log($"watch = {watch.ElapsedMilliseconds}");
        effectIndex++;
        yield return StartCoroutine(effects[1]);
        Debug.Log($"watch = {watch.ElapsedMilliseconds}");
        effectIndex++;
        yield return StartCoroutine(effects[2]);
        Debug.Log($"watch = {watch.ElapsedMilliseconds}");
        effectIndex++;
    }

    IEnumerator Effect1()
    {
        yield return new WaitForSeconds(1.0f);
    }

    IEnumerator Effect2()
    {
        yield return new WaitForSeconds(1.0f);
    }

    IEnumerator Effect3()
    {
        yield return new WaitForSeconds(1.0f);
    }

    
}