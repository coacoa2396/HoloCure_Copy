using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSlot : MonoBehaviour 
{
    public enum State { Empty, Full }

    State state;

    private void Awake()
    {
        SetCurState(State.Empty);        
    }

    public void SetCurState(State state)
    {
        this.state = state;
    }

    public State GetCurState()
    {
        return state;
    }
}
