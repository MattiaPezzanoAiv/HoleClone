using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class ColorTable
{
    [System.Serializable]
    class ColorTableInternal
    {
        public Color color;
        public string name;

    }

    [SerializeField]
    ColorTableInternal[] colors;

    private Dictionary<string, Color> colorMap;

    public Color this[string k]
    {
        get
        {
            if(colorMap != null)
            {
                foreach (var c in colors)
                {
                    colorMap.Add(c.name, c.color);
                }
            }
            return colorMap[k];
        }
    }

    /// <summary>
    /// Returns how many colors are selectable
    /// </summary>
    public int Length
    {
        get
        {
            return colors.Length;
        }
    }

    /// <summary>
    /// Generate a new list every time
    /// </summary>
    /// <returns></returns>
    public List<string> GetNames()
    {
        return (from c in colors select c.name).ToList();
    }
}
