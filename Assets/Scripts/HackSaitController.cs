using TMPro;
using UnityEngine;

public class HackSaitController : MonoBehaviour
{
    public BugOnSaitController[] bugs;
    public TMP_Text bugsCountText;
    public TMP_Text successText;
    public static int bugsCount;
    public int allBugsCount = 3;
    public bool isStart;

    private void Update()
    {
        if(!isStart) return;
        if(successText.gameObject.activeSelf) return;
        if (bugsCount == allBugsCount)
        {
            successText.gameObject.SetActive(true);
            bugsCountText.gameObject.SetActive(false);
        }

        bugsCountText.text = "Количество багов собрано: " + bugsCount;
    }

    public void StartGame()
    {
        isStart = true;
        bugsCountText.gameObject.SetActive(true);
        foreach (var bug in bugs)
        {
            bug.gameObject.SetActive(true);
            bug.StartGame();
        }
    }
}