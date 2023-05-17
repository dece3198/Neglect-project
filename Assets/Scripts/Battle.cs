using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState<T>
{
    public abstract void Enter(T Turn);
    public abstract void Update(T Turn);
    public abstract void Exit(T Turn);
}

public class PlayerTurn : BaseState<Battle>
{
    public override void Enter(Battle Turn)
    {
    }
    public override void Update(Battle Turn)
    {
    }
    public override void Exit(Battle Turn)
    {
    }

}

public class Battle : Singleton<Battle>
{
    public enum BattleState
    {
        PlayerTurn, EnemyTurn, Win, Lose
    }

    public BattleState state;
    public StateMachine<BattleState, Battle> stateMachine;
    [SerializeField] private List<Slot> slots = new List<Slot>();
    [SerializeField] private GameObject monsterparent;

    public void ChangeState(BattleState nextState)
    {
        state = nextState;
        stateMachine.ChangeState(nextState);
    }
}
