using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class BigTreeEnd : MonoBehaviour
{
    public GameObject endPicture;
    public GameObject notBigComputerAlert;

    public void TryPlay()
    {
        if (!BzlomatorController.IsBigComputer)
        {
            notBigComputerAlert.SetActive(true);
            return;
        }
        endPicture.SetActive(true);
        StartCoroutine(TryPlayCoroutine());
    }

    public IEnumerator TryPlayCoroutine()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}