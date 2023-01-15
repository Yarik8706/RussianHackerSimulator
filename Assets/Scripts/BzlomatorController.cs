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
    public TMP_InputField saitInput;
    public Board tetrisBoard;
    public GameManager pacmanManager;
    public MailProfile[] mailProfiles;
    public AudioSource musicForWait;
    public AudioSource backgroundMusic;
    public GameObject mainGame;
    public GameObject notBigComputer;
    public GameObject endFrame;
    public string hackSaitUrl;
    public GameObject hackSaitWinAlert;
    public GameObject hackSaitLetter;

    private MailProfile _activeHackMail;

    public static int MoneyCount;
    public static BzlomatorController Instance;
    public static bool IsBigComputer;

    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartHackOnMail()
    {
        StartCoroutine(StartHackOnMailCoroutine());
    }

    public void TryHackPentogon()
    {
        if(IsBigComputer)
        {
            StartCoroutine(HackPentogonCoroutine());
            return;
        };
        notBigComputer.SetActive(true);
    }

    public IEnumerator HackPentogonCoroutine()
    {
        ProgressBar.Instance.progressSlider.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 98; i++)
        {
            ProgressBar.Instance.progressSlider.value = i;
            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds(2.5f);
        ProgressBar.Instance.progressSlider.value = 100;
        yield return new WaitForSeconds(0.5f);
        endFrame.SetActive(true);
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(0);
    }

    public IEnumerator StartHackOnMailCoroutine()
    {
        foreach (var mailProfile in mailProfiles)
        {
            if (mailProfile.email == mailInput.text)
            {
                SceneManager.LoadScene(
                         "Tetris", 
                         LoadSceneMode.Additive);
                backgroundMusic.Stop();
                yield return null;
                mainGame.SetActive(false);
                tetrisBoard.victim = mailProfile.name;
                tetrisBoard.SetScoreCountText(mailProfile.needScoreCount);
                _activeHackMail = mailProfile;
            }
        }
    }

    public void StartHackSait()
    {
        StartCoroutine(StartHackSaitCoroutine());
    }

    [ContextMenu("add money")]
    public void AddMoney()
    {
        MoneyCount += 1000;
    }

    public IEnumerator StartHackSaitCoroutine()
    {
        if (HackSaitController.bugsCount == 0) yield break;
        if(saitInput.text != hackSaitUrl) yield break;
        SceneManager.LoadScene(
            "Pacman", 
            LoadSceneMode.Additive);
        backgroundMusic.Stop();
        yield return null;
        mainGame.SetActive(false);
    }

    public void EndHackSait()
    {
        StartCoroutine(EndHackSaitCoroutine());
    }
    
    public IEnumerator EndHackSaitCoroutine()
    {
        backgroundMusic.Play();
        mainGame.SetActive(true);
        Destroy(pacmanManager.game);
        MoneyCount += 500;
        yield return new WaitForSeconds(0.8f);
        hackSaitWinAlert.SetActive(true);
        hackSaitLetter.SetActive(true);
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
        backgroundMusic.Play();
    }

    public IEnumerator CloseProfileCourotine()
    {
        yield return new WaitForSeconds(0.8f);
        MoneyCount += _activeHackMail.missionMoney;
        _activeHackMail.endMissionWindow.SetActive(true);
        _activeHackMail.endLetter.SetActive(true);
    }
}