using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerUI : MonoBehaviour
{
    bool open = false;
    public GameObject UICanvas;
    void Update()
    {
        if ( Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            open = !open;
            UICanvas.SetActive(open);
        }
    }
}
