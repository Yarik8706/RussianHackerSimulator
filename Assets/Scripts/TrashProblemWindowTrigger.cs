using System;
using UnityEngine;

public class TrashProblemWindowTrigger : MonoBehaviour
{
    private void OnDisable()
    {
        StartCoroutine(SystemController.Instance.AfterHelloWindows());
    }
}