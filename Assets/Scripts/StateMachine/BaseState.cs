using System.Threading.Tasks;
using UnityEngine;

public abstract class BaseState
{
    // when the state is first loaded
    public abstract void EnterState(StateMachine obj, GameObject head, ParticleSystem particles);

    // Update method for the states
    public abstract void UpdateState(StateMachine obj);

    public virtual void PlayParticles(ParticleSystem particles) { }
    public virtual void DropHead(StateMachine obj) { }
}
