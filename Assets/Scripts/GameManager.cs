using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GameManager : MonoBehaviour
{
    public bool poolEnabled;
    ObjectPool<ObjectScript> _pool;
    [SerializeField]
    GameObject[] _spawns;
    [SerializeField]
    int _inactiveCount;
    [SerializeField]
    int _activeCount;
    Transform _spawnpoint;
    public ObjectScript[] prefabObjects;
    [HideInInspector]
    public int randomSpawn;
    int _randomObject;
    
    void Awake()
    {
        _pool = new ObjectPool<ObjectScript>(CreateObject, OnTakeObject, OnReturnObject);
    }

    void LateUpdate()
    {
        if (poolEnabled)
        {
            GetRandomInt();

            //choose a random spawnpoint
            var item = _pool.Get();
            _spawnpoint = _spawns[randomSpawn].transform;
            item.transform.position = _spawnpoint.position;

            //For debugging
            _inactiveCount = _pool.CountInactive;
            _activeCount = _pool.CountActive;
        }
    }
    void GetRandomInt()
    {
        _randomObject = Random.Range(0, 3);
        randomSpawn = Random.Range(0, 3);
    }
    //Called when object is drawn from the pool
    void OnTakeObject(ObjectScript obj)
    {
        obj.gameObject.SetActive(true);
        obj.ChangeColor(randomSpawn);
    }

    //Called when there is not enough objects in the pool
    ObjectScript CreateObject()
    {
        var obj = Instantiate(prefabObjects[_randomObject]);
        obj.SetPool(_pool);
        return obj;
    }

    //Called when object is returned to the pool
    void OnReturnObject(ObjectScript obj)
    {
        obj.gameObject.SetActive(false);
        obj.ResetObject();
    }

    //Toggle spawning
    public void StartPool() => poolEnabled = !poolEnabled;

}
