using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class UIInGamePage : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI timerText;
    [SerializeField]
    TextMeshProUGUI scoreText;

    private bool needStartTimeAnim = true;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.onScoreUpdate += (score) =>
        {
            scoreText.text = score.ToString();
            scoreText.rectTransform.DOPunchScale(Vector3.one * 0.2f, 0.1f);
        };
        GameManager.Instance.onTimerUpdate += (time) =>
        {
            timerText.text = time.ToString("0.0");

            if(time <= 10 && needStartTimeAnim)
            {
                needStartTimeAnim = false;
                timerText.color = Color.red;
                timerText.rectTransform.DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo);
            }
        };

        scoreText.text = "0";
        timerText.text = "0";
        gameObject.SetActive(false);
    }

}
