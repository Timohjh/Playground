using System;
using System.Threading.Tasks;
using UnityEngine;

public class ObjGrowState : BaseState
{
    GameObject _head;
    Vector3 _headSize = new Vector3(0.5f, 0.5f, 0.5f);
    Vector3 _sizeIncrease = new Vector3(0.1f, 0.1f, 0.1f);
    public event Action<ObjDropState> OnRed;

    float pulseFrequency = 1f;
    float pulseMagnitudeMax = 1.5f;
    float pulseMagnitudeMin = 1f;
    float pulseProgress = 0f;

    public override void EnterState(StateMachine obj, GameObject head, ParticleSystem particles)
    {
        _head = head;
    }

    public override void UpdateState(StateMachine obj)
    {
        // Pulsing effect on the object and lerp the color to match it
        pulseProgress = Mathf.PingPong(Time.time, 1f / pulseFrequency) * pulseFrequency;
        _head.GetComponent<Renderer>().material.color = new Color32((byte) Mathf.Lerp(155, 255, pulseProgress), 0, 0, 255);
        _head.transform.localScale = _headSize * Mathf.Lerp(pulseMagnitudeMin, pulseMagnitudeMax, pulseProgress);
        //IsRed();
    }

    //Invoke event 
    public override void DropHead(StateMachine obj)
    {
        OnRed?.Invoke(obj.DropState);
        //DoDrop(obj);

    }

    /*bool IsRed()
    {
        if (pulseProgress > 0.9f)
        {
            return true;
        }
        else
            return false;
    }

    public void DoDrop(StateMachine obj)
    {
        //IsReady(obj).GetAwaiter().GetResult();
        //OnRed?.Invoke(obj.DropState);
    }
    
    async Task<bool> IsReady(StateMachine obj)
    {
        while (IsRed())
        {
            await Task.Yield();
            return true;
        }return false;
    }*/
}
