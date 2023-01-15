using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartComixScript : MonoBehaviour
{
    int currentPageId;
    public List<GameObject> pagesList = new List<GameObject>();
    public float btnWaitTime;
    public GameObject btn;
    void Start()
    {
        StartCoroutine(BtnWaiting());
    }

    public void NextPage()
    {
        currentPageId++;
        if (currentPageId < pagesList.Count)
        {
            pagesList[currentPageId].SetActive(true);
        }
        else 
        {
            gameObject.SetActive(false);
        }
    }
        private IEnumerator BtnWaiting()
    {
        yield return new WaitForSeconds(btnWaitTime);
        btn.SetActive(true);
    }
}
