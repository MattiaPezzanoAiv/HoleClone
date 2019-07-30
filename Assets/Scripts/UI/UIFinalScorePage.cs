using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIFinalScorePage : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        GameManager.Instance.onMatchEnded += SetScore;
        gameObject.SetActive(false);
    }

    void SetScore(int score)
    {
        scoreText.text = "Your final score is: " + score;
    }
}
