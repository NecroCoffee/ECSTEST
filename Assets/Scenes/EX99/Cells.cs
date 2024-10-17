using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells : MonoBehaviour
{
    Material material;



    private void Awake()
    {
        material = this.GetComponent<Material>();
    }

    private void OnMouseEnter()
    {
        material.color= Color.red;
    }

    private void OnMouseExit()
    {
        material.color= Color.white;
    }
}
