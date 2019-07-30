using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIRankingElement : MonoBehaviour
{
    [SerializeField]
    private Image bg;
    [SerializeField]
    private TextMeshProUGUI text;

    public void Setup(Color bg, string name)
    {
        this.bg.color = bg;
        text.text = name;
    }
}
