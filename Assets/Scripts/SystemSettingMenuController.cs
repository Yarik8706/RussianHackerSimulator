using UnityEngine;

public class SystemSettingMenuController : MonoBehaviour
{
    public GameObject activeContainer;

    public void SetActiveContainer(GameObject container)
    {
        activeContainer.SetActive(false);
        container.SetActive(true);
        activeContainer = container;
    }
}