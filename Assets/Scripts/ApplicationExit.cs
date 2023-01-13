using System;
using UnityEngine;

public class ApplicationExit : MonoBehaviour
{
    public GameObject applicationWindow;
    public Action exitEvent;

    public void ExitFromApplication()
    {
        exitEvent?.Invoke();
        applicationWindow.SetActive(false);
    }
}