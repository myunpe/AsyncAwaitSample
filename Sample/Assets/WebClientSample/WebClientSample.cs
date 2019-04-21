using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class WebClientSample : MonoBehaviour
{
    public Text textView; 
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }
    
    
    public void OnClickButton()
    {
        WebClient wc = new WebClient();
        var html = wc.DownloadString("http://www.google.co.jp/");
        textView.text = html;
    }
    
    public async void OnClickButtonAsync()
    {
        WebClient wc = new WebClient();
        var html = await wc.DownloadStringTaskAsync("http://www.google.co.jp/");
        textView.text = html;
    }
    
}
