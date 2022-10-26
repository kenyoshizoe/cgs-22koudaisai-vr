using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolderingIronStand : MonoBehaviour
{
    [SerializeField]
    Collider target;
    [SerializeField]
    Transform snapPosition;

    [SerializeField]
    bool debug = false;
    [SerializeField]
    Material debugNormalMaterial;
    [SerializeField]
    Material debugHoldableMaterial;
    [SerializeField]
    Material debugHoldingMaterial;

    bool isHoldable;
    bool isHolding;

    GameObject debugBall;

    void Start()
    {
        this.gameObject.GetComponent<Collider>().isTrigger = true;
        isHoldable = false;
        isHolding = false;

        if (debug) {
            debugBall = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            debugBall.transform.SetParent(this.transform);
            debugBall.transform.localPosition = new Vector3(0.5f, 0.0f, 0.0f);
            debugBall.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            debugBall.GetComponent<Renderer>().material = debugNormalMaterial;
        }
    }

    void Update()
    {
        if (debug) {
            if (isHolding){
                debugBall.GetComponent<Renderer>().material = debugHoldingMaterial;
            } else if (isHoldable) {
                debugBall.GetComponent<Renderer>().material = debugHoldableMaterial;
            } else {
                debugBall.GetComponent<Renderer>().material = debugNormalMaterial;
            }
        }
    }

    void OnTriggerStay(Collider other) {
        if (other != target) return;

        if (!target.GetComponentInParent<OVRGrabbable>().isGrabbed && !isHolding) {
            isHolding = true;
            target.GetComponentInParent<Rigidbody>().isKinematic = true;
            target.GetComponentInParent<Rigidbody>().transform.position = snapPosition.position;
            target.GetComponentInParent<Rigidbody>().transform.rotation = snapPosition.rotation;
        }
    }

    // For Debug
    void OnTriggerEnter(Collider other) {
        if (other != target) return;
        isHoldable = true;
    }
    void OnTriggerExit(Collider other) {
        if (other != target) return;
        isHolding = false;
        isHoldable = false;
    }
}
