using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    BaseState currentState;
    public ObjRotateState RotationState = new ObjRotateState();
    public ObjGrowState GrowState = new ObjGrowState();
    public ObjDropState DropState = new ObjDropState();
    public ObjExplodeState ExplodeState = new ObjExplodeState();
    public GameObject head;
    public ParticleSystem particles;
    public TMPro.TextMeshProUGUI stateText;

    void Start()
    {
        currentState = RotationState;

        currentState.EnterState(this, head, particles);
        stateText.text = currentState.ToString();
        // Start the timer in ObjRotateState
        StartCoroutine(RotationState.WaitSeconds(this));
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    // subscribe to the event in ObjGrowState
    void OnEnable() => GrowState.OnRed += SwitchState;
    void OnDisable() => GrowState.OnRed += SwitchState;

    // Switch between states
    public void SwitchState(BaseState state)
    {
        currentState = state;
        state.EnterState(this, head, particles);
        stateText.text = currentState.ToString();
    }

    // Drop the head
    public void ThrowHead()
    {
        if (currentState == GrowState)
        {
            currentState.DropHead(this);
        }
    }

    public void PlayParticles()
    {
        currentState.PlayParticles(particles);
    }
}
