using System;
using UnityEngine;

public class ApplicationConnectionController : MonoBehaviour
{
    public GameObject notConnectionWindow;
    public GameObject connectionWindow;
    
    private void OnEnable()
    {
        if(!SystemConnectionSetting.InternetConnectionState) return;
        notConnectionWindow.SetActive(false);
        connectionWindow.SetActive(true);
    }
}