using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BlackountController : MonoBehaviour
{
    public Image blackount;

    public void StartBlackout()
    {
        var startColor = blackount.color;
        blackount.gameObject.SetActive(true);
        blackount.DOFade(0, 1f).OnComplete(() =>
        {
            blackount.gameObject.SetActive(false);
        });
        blackount.color = startColor;
    }
}