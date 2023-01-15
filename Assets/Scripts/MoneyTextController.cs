using System;
using TMPro;
using UnityEngine;

public class MoneyTextController : MonoBehaviour
{
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _text.text = "Денег на счету: " + BzlomatorController.MoneyCount + "$";
    }
}