using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolderingIronStand : MonoBehaviour
{
    [SerializeField]
    public Collider target;
    [SerializeField]
    bool debug = false;
    [SerializeField]
    Material debug_normal_material;
    [SerializeField]
    Material debug_holding_material;

    bool is_holding;
    GameObject debug_ball;

    void Start()
    {
        this.gameObject.GetComponent<Collider>().isTrigger = true;
        is_holding = false;
        if (debug) {
            debug_ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            debug_ball.transform.SetParent(this.transform);
            debug_ball.transform.localPosition = new Vector3(0.0f, 0.0f, 0.2f);
            debug_ball.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            debug_ball.GetComponent<Renderer>().material = debug_normal_material;
        }
    }

    void Update()
    {
        if (debug) {
            debug_ball.GetComponent<Renderer>().material
                = (is_holding ? debug_holding_material : debug_normal_material);
        }
    }

    void OnTriggerStay(Collider other) {
        if (target == other) {
            if (target.GetComponentInParent<OVRGrabbable>().isGrabbed) {
                is_holding = false;
                target.gameObject.GetComponentInParent<Rigidbody>().constraints
                    = RigidbodyConstraints.None;
            } else {
                is_holding = true;
                target.gameObject.GetComponentInParent<Rigidbody>().constraints
                    = RigidbodyConstraints.FreezeAll;
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if (target == other) {
            is_holding = false;
        }
    }
}
