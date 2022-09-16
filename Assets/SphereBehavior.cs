using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject _endText;
    private CubeColorBehavior _cubeColor;

    private void OnTriggerEnter(Collider other)
    {
        _endText.SetActive(true);
        _cubeColor.ChangeColor();
    }



}
