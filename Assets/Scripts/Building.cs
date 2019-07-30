using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField]
    private int pts;
    [SerializeField]
    private PlayerSize minSizeToEat;

    public int GetPts()
    {
        return pts;
    }
    public bool CanBeEatenBy(Player player)
    {
        return (int)minSizeToEat <= (int)player.GetSize();
    }

    public Player Owner { get; set; }
}
