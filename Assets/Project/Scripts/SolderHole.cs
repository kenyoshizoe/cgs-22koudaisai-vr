using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolderHole : MonoBehaviour
{
    [SerializeField]
    Collider targetFootCollider;
    [SerializeField]
    GameObject targetFoot;
    [SerializeField]
    Collider solderingIron;
    [SerializeField]
    Collider solderingWire;
    [SerializeField]
    GameObject solder;

    public float solderingTime;
    float t;

    public bool isInserted;

    public bool isSoldered
    {
        get { return isSoldered; }
        set
        {
            // show up solder
            isSoldered = value;
        }
    }

    public bool footTouching = false;
    bool solderingIronTouching = false;
    bool solderingWireTouching = false;

    void Start()
    {
        isInserted = false;
        isSoldered = false;
    }

    void Update()
    {
        if (isInserted && solderingIronTouching && solderingWireTouching)
        {
            // count up
            t += Time.deltaTime;
            if (t > solderingTime)
            {
                isSoldered = true;
            }
        }
        else
        {
            t = 0;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider == targetFootCollider)
            footTouching = true;
        else if (other.collider == solderingIron)
            solderingIronTouching = true;
        else if (other.collider == solderingWire)
            solderingWireTouching = true;
    }

    void OnCollisionExit(Collision other)
    {
        if (other.collider == targetFootCollider)
            footTouching = false;
        else if (other.collider == solderingIron)
            solderingIronTouching = false;
        else if (other.collider == solderingWire)
            solderingWireTouching = false;
    }

}
