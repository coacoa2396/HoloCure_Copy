using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public enum State { Idle, Jump, Move }

    int hp;
    public int Hp { get { return hp; } set { hp = value; } }

    public PlayerInput playerInput;

    StateMachine<State> stateMachine = new StateMachine<State>();

    private void Start()
    {
        stateMachine.AddState(State.Idle, new IdleState());
        stateMachine.AddState(State.Jump, new JumpState());
        stateMachine.AddState(State.Move, new MoveState());

        stateMachine.Start(State.Idle);
    }

    private void Update()
    {
        stateMachine.Update();
    }

    private void LateUpdate()
    {
        stateMachine.LateUpdate();
    }

    private void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }

    class PlayerState : BaseState<State>
    {
        protected PlayerController controller;
        protected PlayerInput input => controller.playerInput;
    }

    class IdleState : PlayerState
    {
        public override void Enter()
        {
            int value = controller.hp;
        }
    }

    class JumpState : PlayerState
    {
        
    }

    class MoveState : PlayerState
    {

    }
}
