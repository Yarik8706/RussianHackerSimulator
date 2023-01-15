using System.Collections;
using UnityEngine;

public class SystemConnectionSetting : MonoBehaviour
{
    public AudioSource connectionMusic;
    public ApplicationExit applicationExit;
    public GameObject newMessageWindow;
    public GameObject connectionReturnState;
    public GameObject notConnectionText;
    public GameObject hasConnectionText;

    public static bool InternetConnectionState;
    
    public void StartUpdateConnection()
    {
        if(InternetConnectionState) return;
        StartCoroutine(UpdateConnection());
    }

    private IEnumerator UpdateConnection()
    {
        connectionMusic.Play();
        ProgressBar.Instance.progressSlider.gameObject.SetActive(true);
        
        for (int i = 0; i < 98; i++)
        {
            ProgressBar.Instance.progressSlider.value = i;
            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds(connectionMusic.clip.length - connectionMusic.time);
        ProgressBar.Instance.progressSlider.gameObject.SetActive(false);
        connectionReturnState.SetActive(true);
        notConnectionText.SetActive(false);
        hasConnectionText.SetActive(true);
        InternetConnectionState = true;
        applicationExit.exitEvent = () =>
        {
            StartCoroutine(NewMessageCouroutine());
        };
    }

    public IEnumerator NewMessageCouroutine()
    {
        yield return new WaitForSeconds(0.9f);
        newMessageWindow.SetActive(true);
    }
}