using UnityEngine;

public class PuscWindowsButton : MonoBehaviour
{
    public GameObject windowsMenu;

    public void ChangeActive()
    {
        windowsMenu.SetActive(!windowsMenu.activeSelf);
    }
}