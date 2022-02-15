using UnityEngine;

public class ObjDropState : BaseState
{
    GameObject _head;
    public override void EnterState(StateMachine obj, GameObject head, ParticleSystem particles)
    {
        _head = head;
        _head.GetComponent<Rigidbody>().useGravity = true;
    }

    public override void UpdateState(StateMachine obj)
    {

    }

}
