using UnityEngine;
using UnityEngine.Pool;

public class ObjectScript : MonoBehaviour
{
    public ObjectSettings objSettings;
    float _timeInTrigger;
    //Time-to-live
    bool _startTTL;
    Transform _transform;
    IObjectPool<ObjectScript> _pool;
    public int objSpawn;

    //Object material properties
    Renderer _renderer;
    Color32 _newColor;
    MaterialPropertyBlock _matProp;

    void Awake()
    {
        _transform = transform;
        _matProp = new MaterialPropertyBlock();
        _renderer = gameObject.GetComponent<Renderer>();
    }

    //starts time-to-live counter when trigger is hit
    void OnTriggerEnter(Collider other) => _startTTL = true;

    void OnDisable() => _startTTL = false;

    void Update()
    {
        if (!_startTTL)
        {
            return;
        }
        _timeInTrigger += Time.deltaTime;
        
        //Return object to pool if TTL is on
        if (objSettings.hasTTL && _timeInTrigger >= objSettings.timeToLive)
        {
            if (_pool != null)
                _pool.Release(this);
            else
                Destroy(gameObject);
        }
    }

    //using flyweight pattern to reduce memory usage by materials
    //Assign new color to materialpropertyblock
    public void ChangeColor(int randomSpawn)
    {
        objSpawn = randomSpawn;
        _renderer.GetPropertyBlock(_matProp);
        _matProp.SetColor("_BaseColor", GetColor());
        _renderer.SetPropertyBlock(_matProp);
    }

    //get color based on spawnpoint
    Color GetColor()
    {
        switch (objSpawn)
        {
            case 2:
                _newColor = new Color(1f, 0f, 0f, 1f);
                return _newColor;
            case 1:
                _newColor = new Color(0f, 1f, 0f, 1f);
                return _newColor;
                
            case 0:
                _newColor = new Color(0f, 0f, 1f, 1f);
                return _newColor;
            default:
                _newColor = new Color(1f, 1f, 1f, 1f);
                return _newColor;
        }
    }

    public void SetPool(IObjectPool<ObjectScript> pool)
    {
        _pool = pool;
    }
    public void ResetObject() => _timeInTrigger = 0f;
}
