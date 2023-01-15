using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public class SaitData
{
    public string url;
    public GameObject sait;
    public UnityEvent unityEvent;
}

public class BrowserController : MonoBehaviour
{
    public TMP_InputField inputField;
    public SaitData[] saitDatas;
    
    private SaitData _lastActiveSait;
    private SaitData _activeSait;

    public void StartSearchSait()
    {
        if(!SystemConnectionSetting.InternetConnectionState) return;
        foreach (var data in saitDatas)
        {
            if (data.url == inputField.text)
            {
                if (_activeSait != null)
                {
                    _lastActiveSait = _activeSait;
                    _activeSait.sait.SetActive(false);
                }
                _activeSait = data;
                data.sait.SetActive(true);
                data.unityEvent?.Invoke();
                break;
            }
        }
    }

    public void GoToLastSait()
    {
        if(_lastActiveSait == null) return;
        _activeSait.sait.SetActive(false);
        _lastActiveSait.sait.SetActive(true);
    }
}