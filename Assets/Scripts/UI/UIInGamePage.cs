using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIInGamePage : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI timerText;
    [SerializeField]
    TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.onScoreUpdate += (score) => scoreText.text = score.ToString();
        GameManager.Instance.onTimerUpdate += (time) => timerText.text = time.ToString("0.0");

        scoreText.text = "0";
        timerText.text = "0";
        gameObject.SetActive(false);
    }

}
