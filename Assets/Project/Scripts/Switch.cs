using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField]
    List<Collider> targets;

    Transform initalTransform;

    public bool isPushed { get; private set; }
    void Start()
    {
        initalTransform = transform;
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (targets.Contains(other))
        {
            isPushed = true;
            transform.localPosition -= new Vector3(0, 0.01f, 0);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (targets.Contains(other))
        {
            isPushed = false;
            transform.localPosition += new Vector3(0, 0.01f, 0);
        }
    }
}
