using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolderHole : MonoBehaviour
{
    [SerializeField]
    List<Collider> targetFootColliders;
    [SerializeField]
    Collider solderingIron;
    [SerializeField]
    Collider solderingWire;
    [SerializeField]
    GameObject solder;

    [SerializeField]
    bool debug;
    [SerializeField]
    Material debugRedMaterial;
    [SerializeField]
    Material debugGreenMaterial;
    [SerializeField]
    Material debugBlueMaterial;
    public float solderingTime;
    float t;

    public bool isInserted;

    bool m_isSoldered;
    public bool isSoldered
    {
        get { return m_isSoldered; }
        set
        {
            solder.SetActive(value);
            m_isSoldered = value;
        }
    }

    public bool footTouching = false;
    bool solderingIronTouching = false;
    bool solderingWireTouching = false;
    GameObject debugBall;

    void Start()
    {
        isInserted = false;
        isSoldered = false;
        if (debug)
        {
            debugBall = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            debugBall.transform.SetParent(this.transform);
            debugBall.transform.localPosition = new Vector3(0.0f, 0.0f, -0.03f);
            debugBall.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            debugBall.GetComponent<Renderer>().material = debugGreenMaterial;
        }
        gameObject.GetComponentInChildren<ParticleSystem>().Stop();
    }

    void Update()
    {
        if (debug)
        {
            if (isSoldered)
            {
                debugBall.GetComponent<Renderer>().material = debugRedMaterial;
            }
            else if (solderingWireTouching)
            {
                debugBall.GetComponent<Renderer>().material = debugBlueMaterial;
            }
            else
            {
                debugBall.GetComponent<Renderer>().material = debugGreenMaterial;
            }
        }

        if (isInserted && solderingIronTouching && solderingWireTouching)
        {
            // count up
            t += Time.deltaTime;
            if (t > solderingTime)
            {
                isSoldered = true;
            }
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
        }
        else
        {
            t = 0;
            gameObject.GetComponentInChildren<ParticleSystem>().Stop();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (targetFootColliders.Contains(other))
            footTouching = true;
        else if (other == solderingIron)
            solderingIronTouching = true;
        else if (other == solderingWire)
            solderingWireTouching = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (targetFootColliders.Contains(other))
            footTouching = false;
        else if (other == solderingIron)
            solderingIronTouching = false;
        else if (other == solderingWire)
            solderingWireTouching = false;
    }

}
