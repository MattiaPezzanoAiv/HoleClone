using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[System.Serializable]
    //class LevelScaleMap
    //{
    //    public PlayerSize size;
    //    public float scale;
    //}

    [SerializeField]
    private Transform scaleRoot;
    [SerializeField]
    private UnitMovement movement;
    [SerializeField]
    private Renderer[] renderers;

    //[SerializeField]
    //private List<LevelScaleMap> levelScaleMap;

    private PlayerSize mySize;
    //private Dictionary<PlayerSize, float> _levelScaleMap;

    //private void Awake()
    //{
    //    _levelScaleMap = new Dictionary<PlayerSize, float>();
    //    foreach (var i in levelScaleMap)
    //    {
    //        _levelScaleMap.Add(i.size, i.scale);
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        RefreshLevel(0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetMovementEnabled(bool active)
    {
        this.movement.enabled = active;
    }
    public void SetPlayerColor(Color c)
    {
        foreach (var r in renderers)
        {
            r.material.SetColor("_Color", c);
        }
    }
    public void RefreshLevel(int pts)
    {
        if (pts >= (int)PlayerSize.S8)
        {
            mySize = PlayerSize.S8;
            transform.localScale = Vector3.one * 4.1f;
        }
        else if (pts >= (int)PlayerSize.S7)
        {
            mySize = PlayerSize.S7;
            transform.localScale = Vector3.one * 3.3f;
        }
        else if (pts >= (int)PlayerSize.S6)
        {
            mySize = PlayerSize.S6;
            transform.localScale = Vector3.one * 2.8f;
        }
        else if (pts >= (int)PlayerSize.S5)
        {
            mySize = PlayerSize.S5;
            transform.localScale = Vector3.one * 2.3f;
        }
        else if (pts >= (int)PlayerSize.S4)
        {
            mySize = PlayerSize.S4;
            transform.localScale = Vector3.one * 1.7f;
        }
        else if (pts >= (int)PlayerSize.S3)
        {
            mySize = PlayerSize.S3;
            transform.localScale = Vector3.one * 1.4f;
        }
        else if (pts >= (int)PlayerSize.S2)
        {
            mySize = PlayerSize.S2;
            transform.localScale = Vector3.one * 1f;
        }
        else 
        {
            mySize = PlayerSize.S1;
            transform.localScale = Vector3.one * 0.7f;
        }

        Debug.Log("pts -> " + pts + "    size -> " + mySize);
    }
    public PlayerSize GetSize()
    {
        return mySize;
    }

    public void OnBuildingEaten(Building b)
    {
        //increase size
        //scaleRoot.localScale += Vector3.one * b.GetPts() * GameManager.SCALE_MULTIPLIER;
    }
}
