using UnityEngine;
using System.Linq;

public class ClosestCylinder : MonoBehaviour
{
    [SerializeField]
    GameObject[] cylinders;
    Transform closest;
    Transform previousClosest;
    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        //find closest cylinder to player with Linq
        closest = cylinders.OrderBy(
            go => (player.position - go.transform.position).sqrMagnitude)
            .First().transform;
        CheckPrevious();
    }

    // making sure there isn't a redundant color change every frame
    void CheckPrevious()
    {
        if (previousClosest != closest)
        {
            ChangeColor();
            previousClosest = closest;
        }
    }

    void ChangeColor()
    {
        foreach (var cylinder in cylinders)
        {
            cylinder.GetComponent<Renderer>().material.color = Color.black;
        }
        closest.GetComponent<Renderer>().material.color = Color.green;
    }

}
