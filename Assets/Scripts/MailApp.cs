using System;
using UnityEngine;

public class MailApp : MonoBehaviour
{
    public GameObject activeMailWindow;
    public GameObject allMailWindow;
    public GameObject fullMainsContainer;

    public static MailApp Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ReturnToAllMailWindow()
    {
        activeMailWindow.SetActive(false);
        allMailWindow.SetActive(true);
        fullMainsContainer.SetActive(false);
    }
    
    public void OpenFullMailWindow(GameObject mail)
    {
        fullMainsContainer.SetActive(true);
        mail.SetActive(true);
        allMailWindow.SetActive(false);
        activeMailWindow = mail;
    }
}