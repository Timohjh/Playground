using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> items = new List<GameObject>();

    [SerializeField]
    GameObject trigger;

    string _shape;
    int _color;

    void SetList()
    {
        var linqQuery = Resources.FindObjectsOfTypeAll<GameObject>()
            .Where(obj => obj.name == _shape && obj.activeInHierarchy == true && _color == obj.GetComponent<ObjectScript>().objSpawn);
        items = linqQuery.ToList();
        //Debug.Log(items.Count + " " + _color + " " + _shape);
    }
    public void DeleteItems()
    {
        SetList();
        foreach (var item in items)
        {
            item.SetActive(false);
        }
    }

    public void DropdownShape(int i)
    {
        switch (i)
        {
            case 2:
                _shape = "Cylinder(Clone)";
                break;
            case 1:
                _shape = "Cube(Clone)";
                break;
            case 0:
                _shape = "Sphere(Clone)";
                break;
            default:
                _shape = "Sphere(Clone)";
                break;
        }
        SetList();
    }
    public void DropdownColor(int c)
    {
        switch (c)
        {
            
            case 2:
                _color = 2;
                break;
            case 1:
                _color = 1;
                break;
            case 0:
                _color = 0;
                break;
            default:
                _color = 0;
                break;
        }
        SetList();
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
