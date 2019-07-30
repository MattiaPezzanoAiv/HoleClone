using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Game Event")]
public class GameEvent : ScriptableObject {
    [SerializeField]
    private List<GameEventListener> listeners = new List<GameEventListener>();

    public void Invoke()
    {
        for (int i = listeners.Count -1; i >= 0; i--)
        {
            listeners[i].Raise();
        }
    }

    public void Register(GameEventListener listener)
    {
        if (!listeners.Contains(listener)) listeners.Add(listener);
    }
    public void UnRegister(GameEventListener listener)
    {
        if (listeners.Contains(listener)) listeners.Remove(listener);
    }

}
