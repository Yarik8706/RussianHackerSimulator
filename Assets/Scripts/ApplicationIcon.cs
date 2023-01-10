using UnityEngine;
using UnityEngine.EventSystems;

public class ApplicationIcon : MonoBehaviour
{
    public GameObject applicationWindow;

    public void OpenApplication()
    {
        applicationWindow.SetActive(true);
    }
}
