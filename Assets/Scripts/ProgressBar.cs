using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public static ProgressBar Instance;

    public Slider progressSlider;
    public TMP_Text progressText;

    private void Awake()
    {
        progressSlider.onValueChanged.AddListener(_ =>
        {
            progressText.text = progressSlider.value + "%";
        });
        Instance = this;
    }
}