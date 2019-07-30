using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBlackHoleItem : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Image arrow, hole;
    [SerializeField]
    UnityEngine.UI.Button button;

    public void Setup(Color color)
    {
        arrow.color = color;
        hole.color = color;
    }
    public void RegisterCallback(UnityEngine.Events.UnityAction callBack)
    {
        button.onClick.AddListener(callBack);
    }
}
