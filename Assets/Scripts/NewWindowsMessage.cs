using System;
using UnityEngine;

public class NewWindowsMessage : MonoBehaviour
{
    public AudioSource music;

    private void OnEnable()
    {
        music.Play();
    }
}