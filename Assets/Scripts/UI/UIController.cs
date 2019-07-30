using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }

    [SerializeField]
    UIStartPage startPage;
    [SerializeField]
    UIFinalScorePage finalScorePage;
    [SerializeField]
    UIInGamePage inGamePage;

    private void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        startPage.gameObject.SetActive(false);
        inGamePage.gameObject.SetActive(true);
    }

    public void EndGame()
    {
        inGamePage.gameObject.SetActive(false);
        finalScorePage.gameObject.SetActive(true);
    }

    public Color GetUISelectedPlayerColor()
    {
        return this.startPage.GetSelectedColor();
    }
}
