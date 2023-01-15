using System;
using System.Collections;
using UnityEngine;

public class SystemController : MonoBehaviour
{
    public GameObject helloWindow;
    public GameObject trashProblemWindow;
    public AudioSource startWindowsMusic;

    public static SystemController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public IEnumerator OnSystemStart()
    {
        startWindowsMusic.Play();
        yield return new WaitForSeconds(1f);
        helloWindow.SetActive(true);
    }

    public void StartAfterHelloWindows()
    {
        StartCoroutine(AfterHelloWindows());
    }
    
    public IEnumerator AfterHelloWindows()
    {
        yield return new WaitForSeconds(0.7f);
        trashProblemWindow.SetActive(true);
    }
    
}