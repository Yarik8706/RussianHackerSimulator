using UnityEngine;

public class Application : MonoBehaviour
{
    public GameObject applicationWindow;

    public void OpenApplication()
    {
        applicationWindow.SetActive(true);
    }
}
