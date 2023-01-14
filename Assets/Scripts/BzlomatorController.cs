using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class MailProfile
{
    public GameObject profile;
    public int needScoreCount;
    public int missionMoney;
    public string email;
    public string name;
    public GameObject endMissionWindow;
    public GameObject endLetter;
}

public class BzlomatorController : MonoBehaviour
{
    public TMP_InputField mailInput;
    public Board tetrisBoard;
    public MailProfile[] mailProfiles;
    public AudioSource musicForWait;
    public GameObject mainGame;

    private MailProfile _activeHackMail;

    public static int MoneyCount;
    public static BzlomatorController Instance;

    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartHackOnMail()
    {
        StartCoroutine(StartHackOnMailCoroutine());
    }

    public IEnumerator StartHackOnMailCoroutine()
    {
        foreach (var mailProfile in mailProfiles)
        {
            if (mailProfile.email == mailInput.text)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(
                         "Tetris", 
                         LoadSceneMode.Additive);
                yield return null;
                mainGame.SetActive(false);
                tetrisBoard.victim = mailProfile.name;
                tetrisBoard.SetScoreCountText(mailProfile.needScoreCount);
                _activeHackMail = mailProfile;
            }
        }
    }

    public void EndHackOnMail()
    {
        Destroy(tetrisBoard.tetrisGame);
        mainGame.SetActive(true);
        musicForWait.Play();
        _activeHackMail.profile.SetActive(true);
    }

    public void CloseProfile()
    {
        musicForWait.Stop();
        _activeHackMail.profile.SetActive(false);
        StartCoroutine(CloseProfileCourotine());
    }

    public IEnumerator CloseProfileCourotine()
    {
        yield return new WaitForSeconds(0.8f);
        MoneyCount += _activeHackMail.missionMoney;
        _activeHackMail.endMissionWindow.SetActive(true);
        _activeHackMail.endLetter.SetActive(true);
    }
}