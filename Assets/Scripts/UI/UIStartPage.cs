using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIStartPage : MonoBehaviour
{
    [SerializeField]
    UIBlackHoleItem blackHolePrefab;
    [SerializeField]
    Image scrollerBgImage;
    [SerializeField]
    ScrollRect scroller;


    Color selectedColor;
    RectTransform selected;

    private void Start()
    {
        var colors = GameManager.Instance.AvailableColors;
        int i = 0;
        foreach (var c in colors)
        {
            var inst = Instantiate(blackHolePrefab, scroller.content);
            inst.Setup(c);
            inst.RegisterCallback(() => ItemCallback(c, inst.GetComponent<RectTransform>()));

            if (selected == null)
                selected = inst.GetComponent<RectTransform>();
        }
        Destroy(blackHolePrefab.gameObject);

        ItemCallback(colors[0], selected);
        scroller.horizontalNormalizedPosition = 0f;
    }

    void ItemCallback(Color c, RectTransform me)
    {
        if (selected != null)
            selected.GetChild(0).localScale = Vector3.one * 0.4f;

        this.selectedColor = c;

        var _c = c;
        _c.a = 0.35f;
        scrollerBgImage.color = _c;

        selected = me;
        selected.GetChild(0).localScale = Vector3.one * 0.6f;
    }

    public Color GetSelectedColor()
    {
        return selectedColor;
    }
}
