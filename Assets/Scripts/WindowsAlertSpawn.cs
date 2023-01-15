using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class WindowsAlertSpawn : MonoBehaviour
{
    public GameObject alert;
    public float waitTime;

    public void InvokeTriggers()
    {
        StartCoroutine(InvokeTriggersCoroutine());
    }

    public IEnumerator InvokeTriggersCoroutine()
    {
        yield return new WaitForSeconds(waitTime);
        alert.SetActive(true);
    }
}