using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MailObject : MonoBehaviour, IPointerClickHandler
{
    public GameObject fullMailWindow;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        MailApp.Instance.OpenFullMailWindow(fullMailWindow);
    }
}