using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDController : MonoBehaviour
{
    [SerializeField]
    GameObject leftFoot;
    [SerializeField]
    GameObject rightFoot;
    [SerializeField]
    GameObject light;

    public bool isSoldered
    {
		get { return isSoldered; }
		set {
            // 足の長さをvalueの値に応じて変更する処理
            if (value) {
                // 足短くする
            } else {
                // 足伸ばす
            }
            isSoldered = value;
        }
	}

    public void On()
    {

    }
    public void Off()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
