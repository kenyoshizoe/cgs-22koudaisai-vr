using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resister : MonoBehaviour
{
    [SerializeField]
    GameObject leftFoot;
    [SerializeField]
    GameObject rightFoot;
    [SerializeField]
    float longLength = 0.05f;
    [SerializeField]
    float shortLength = 0.02f;

    float m_footLength;

    public float footLength
    {
        set
        {
            leftFoot.transform.localPosition = new Vector3(0.07f, -value, 0);
            leftFoot.transform.localScale = new Vector3(0.01f, value, 0.01f);
            rightFoot.transform.localPosition = new Vector3(-0.07f, -value, 0);
            rightFoot.transform.localScale = new Vector3(0.01f, value, 0.01f);
            m_footLength = value;
        }
        get { return m_footLength; }
    }

    void LongFoot()
    {
        this.footLength = longLength;
    }
    void ShortFoot()
    {
        this.footLength = shortLength;
    }

    void Start()
    {
        LongFoot();
    }

    // debug
    // int time;
    // void Update()
    // {
    //     if (time % 1000 == 0)
    //     {
    //         LongFoot();
    //     }
    //     else if (time % 1000 == 500)
    //     {
    //         ShortFoot();
    //     }
    //     time = (time + 1) % 1000;
    // }
}
