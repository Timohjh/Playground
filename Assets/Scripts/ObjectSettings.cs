using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ObjectSettings")]
public class ObjectSettings : ScriptableObject
{

    public bool hasTTL = false;
    public float timeToLive = 3.0f;

}
