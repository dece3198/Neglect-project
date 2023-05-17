using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class StateMachine<T1, T2> where T2 : MonoBehaviour
{
    private T2 State;
    private BaseState<T2> curState;
    private Dictionary<T1, BaseState<T2>> states;

    public void Rest(T2 state)
    {
        this.State = state;
        curState = null;
        states = new Dictionary<T1, BaseState<T2>>();
    }

    public void Update()
    {
        curState.Update(State);
    }

    public void AddState(T1 state, BaseState<T2> baseState)
    {
        states.Add(state, baseState);
    }

    public void ChangeState(T1 state)
    {
        if(curState != null)
        {
            curState.Exit(State);
        }
        curState = states[state];
        curState.Enter(State);
    }

}
