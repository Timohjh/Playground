using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Checking if player is inside stand's proximity and if player is looking at the stand
public class LookingAndProximity : MonoBehaviour
{
    public GameObject player;
    Vector3 _standPos;
    Vector3 _playerPos;

    [Header("Proximity measure")]
    [Range(1f,10f)]
    public float proximity = 5f;
    public TMPro.TextMeshProUGUI proximityTxt;

    [Header("Looking thing")]
    [Range(0f, 1f)]
    public float lookTreshold = 0.9f;
    public TMPro.TextMeshProUGUI lookingTxt;

    void Start()
    {
        _standPos = transform.position;
    }

    void Update()
    {
        _playerPos = player.transform.position;
        
        //proximity
        //getting vector from stand to player
        Vector3 relativePos = _playerPos - _standPos;
        float dist = Mathf.Sqrt(relativePos.x * relativePos.x + relativePos.y * relativePos.y + relativePos.z * relativePos.z);
        // or
        // float dist = (relativePos).magnitude;

        if (dist < proximity)
        {
            Debug.Log("In proximity of the stand");
            proximityTxt.text = "In proximity";
        }
        else
            proximityTxt.text = "Outside the proximity";

        //looking
        //normalize vector from player to stand
        Vector3 playerToStand = (_standPos - _playerPos).normalized;
        //normalized looking direction
        Vector3 lookDir = player.transform.forward;
        float dot = Vector3.Dot(lookDir, playerToStand);

        if (dot > lookTreshold)
        {
            lookingTxt.text = "Looking";
        }else
            lookingTxt.text = "Not looking";

    }
    /*void OnDrawGizmos()
    {
        Gizmos.DrawLine(player.transform.position, standPos);
    }*/


}
