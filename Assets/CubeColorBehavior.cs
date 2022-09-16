using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColorBehavior : MonoBehaviour
{
    private MeshRenderer _render;

    // Start is called before the first frame update
    void Start()
    {
        _render = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    public void ChangeColor()
    {
        _render.material.color = Color.blue;
    }
}
