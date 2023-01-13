using UnityEngine;
using UnityEngine.EventSystems;

public class ApplicationIcon : MonoBehaviour, IPointerClickHandler
{
    public GameObject applicationWindow;
    public float clickDelay = 0.5f;
    private float _lastClickTime;

    public void OpenApplication()
    {
        applicationWindow.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Time.time - _lastClickTime <= clickDelay)
        {
            OpenApplication();
        }

        _lastClickTime = Time.time;
    }
}
