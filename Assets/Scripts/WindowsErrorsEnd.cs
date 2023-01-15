using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowsErrorsEnd: MonoBehaviour
{
    public GameObject[] errorAlerts;
    public GameObject bugWindows;
    public AudioSource audioSource;

    public void StartErrors()
    {
        StartCoroutine(ErrorsCoroutine());
    }

    public IEnumerator ErrorsCoroutine()
    {
        yield return new WaitForSeconds(0.8f);
        foreach (var alert in errorAlerts)
        {
            alert.SetActive(true); 
            yield return new WaitForSeconds(0.3f);
        }
        bugWindows.SetActive(true);
        audioSource.Play();
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(0);
    }
}