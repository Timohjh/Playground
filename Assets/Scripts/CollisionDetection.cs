using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public StateMachine state;
    
    void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Floor"))
        {
            Debug.Log("yo");
            state.SwitchState(state.ExplodeState);
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
