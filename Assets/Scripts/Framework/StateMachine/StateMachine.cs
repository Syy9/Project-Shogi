﻿using System;
using System.Collections.Generic;

namespace StateMachine
{
    public abstract class StateOwner
    {
        Dictionary<Type, State> _states = new Dictionary<Type, State>();
        State _current;

        public StateOwner()
        {
            SetupState();
        }

        protected abstract void SetupState();
        public abstract void Start();
        protected void Register<T>() where T : State , new()
        {
            var state = new T();
            state.SetOwner(this);
            _states.Add(state.GetType(), state);
        }
        public void ChangeState(Type stateType)
        {
            if(_current != null)
            {
                _current.Exit();
            }

            _current = _states[stateType];
            _current.Enter();
        }
    }

    public abstract class State
    {
        protected StateOwner _owner { get; private set; }
        public void SetOwner(StateOwner owner)
        {
            _owner = owner;
        }
        public void Enter()
        {
            OnEnter();
        }

        public void Exit()
        {
            OnExit();
        }
        protected virtual void OnEnter() { }
        protected virtual void OnExit() { }
    }

    public abstract class State<TOwner> : State where TOwner : StateOwner
    {
        protected TOwner Owner { get { return (TOwner) _owner; } }
    }
}