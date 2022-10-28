using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSolderingWire : MonoBehaviour
{
    Vector3 initialLocalPosition;
    Vector3 initialLocalScale;
    void Start()
    {
        initialLocalPosition = transform.Find("Visual").localPosition;
        initialLocalScale = transform.Find("Visual").localScale;
    }
    public void RestLength()
    {
        transform.Find("Visual").localPosition = initialLocalPosition;
        transform.Find("Visual").localScale = initialLocalScale;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
