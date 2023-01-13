using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Tetris
{
    public class Countdown : MonoBehaviour
    {
        public GameObject[] countdownData;
        public TMP_Text countdownText;
        public GameObject blackout;
        public Board board;

        private void Start()
        {
            StartCoroutine(StartCountdown());
        }

        private IEnumerator StartCountdown()
        {
            foreach (var data in countdownData)
            {
                data.SetActive(true);
                yield return new WaitForSeconds(1f);
                data.SetActive(false);
            }
            yield return new WaitForSeconds(0.3f);
            blackout.SetActive(false);
            countdownText.gameObject.SetActive(false);
            board.SpawnPiece();
        }
    }
}