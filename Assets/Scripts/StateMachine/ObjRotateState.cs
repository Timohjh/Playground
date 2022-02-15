using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjRotateState : BaseState
{
    float _rotationSpeed = 10f;
    float _rotationAmount;
    GameObject _head;
    public override void EnterState(StateMachine obj, GameObject head, ParticleSystem particles)
    {
        _head = head;
        _head.SetActive(true);
    }

    public override void UpdateState(StateMachine obj)
    {
        _rotationAmount = Time.deltaTime * _rotationSpeed;
        obj.transform.Rotate(Vector3.up * _rotationAmount, Space.Self);
    }

    //10 sec timer before switching to next state
    public IEnumerator WaitSeconds(StateMachine obj)
    {
        yield return new WaitForSeconds(10f);
        obj.SwitchState(obj.GrowState);
    }

}
