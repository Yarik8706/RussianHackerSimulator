using System;
using UnityEngine;

public class ProfileOpen : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource backgroundMusic;
    public GameObject profile;
    public BlackountController blackountController;

    private bool _isOpen;

    private void OnEnable()
    {
        if(_isOpen) return;
        profile.SetActive(true);
        blackountController.StartBlackout();
        _isOpen = true;
        audioSource.Play();
        backgroundMusic.Stop();
    }

    public void Close()
    {
        profile.SetActive(true);
        audioSource.Stop();
        backgroundMusic.Play();
    }
}