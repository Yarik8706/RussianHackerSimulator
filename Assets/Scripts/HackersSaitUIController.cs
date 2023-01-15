using System;
using UnityEngine;
using UnityEngine.Rendering;

public class HackersSaitUIController : MonoBehaviour
{
    public GameObject tasks;
    public GameObject things;
    public GameObject moneyProblemWindows;
    public GameObject thisSait;
    public VolumeProfile newVolumeProfile;
    public Volume lightVolume;
    public LoadingScreen loadingScreen;
    public GameObject windowsUpdateAlert;
    
    public void OpenTasks()
    {
        tasks.SetActive(true);
        things.SetActive(false);
    }
    
    public void OpenThings()
    {
        tasks.SetActive(false);
        things.SetActive(true);
    }

    public void TryBuyComputer()
    {
        if (BzlomatorController.MoneyCount < 600)
        {
            moneyProblemWindows.SetActive(true);
            return;
        }
        windowsUpdateAlert.SetActive(true);
    }

    public void UpdateComputer()
    {
        BzlomatorController.IsBigComputer = true;
        BzlomatorController.MoneyCount = 0;
        lightVolume.profile = newVolumeProfile;
        StartCoroutine(loadingScreen.LoadingCourotine());
        thisSait.SetActive(false);
    }
}