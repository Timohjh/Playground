using UnityEngine;

public class ObjExplodeState : BaseState
{
    public override void EnterState(StateMachine obj, GameObject head, ParticleSystem particles)
    {
        PlayParticles(particles);
    }

    public override void UpdateState(StateMachine obj)
    {

    }

    public override void PlayParticles(ParticleSystem particles)
    {
        particles.Play();
    }
}
