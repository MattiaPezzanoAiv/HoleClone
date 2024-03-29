﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour {

    public GameEvent gameEvent;
    public UnityEvent response;


    void OnEnable()
    {
        gameEvent.Register(this);
    }
    void OnDisable()
    {
        gameEvent.UnRegister(this);    
    }
    
    public void Raise()
    {
        response.Invoke();
    }
}
