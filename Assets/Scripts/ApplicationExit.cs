using UnityEngine;

namespace DefaultNamespace
{
    public class ApplicationExit : MonoBehaviour
    {
        public GameObject applicationWindow;

        public void ExitFromApplication()
        {
            applicationWindow.SetActive(false);
        }
    }
}