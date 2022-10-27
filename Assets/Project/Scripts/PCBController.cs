using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCBController : MonoBehaviour
{
    [SerializeField]
    SolderHole LEDLeftFootHole;
    [SerializeField]
    SolderHole LEDRightFootHole;
    [SerializeField]
    GameObject LED;
    [SerializeField]
    GameObject holderedLED;
    [SerializeField]
    GameObject holderedLEDLight;
    [SerializeField]
    SolderHole resisterLeftFootHole;
    [SerializeField]
    SolderHole resisterRightFootHole;
    [SerializeField]
    GameObject resister;
    [SerializeField]
    GameObject holderedResister;

    [SerializeField]
    int solderingTime = 100;
    [SerializeField]
    GameObject pushSwitch;

    bool solderCompleted = false;

    SolderHole[] holes;

    void Start()
    {
        holderedResister.SetActive(false);
        holderedLED.SetActive(false);
        holes = new SolderHole[] { LEDLeftFootHole, LEDRightFootHole, resisterLeftFootHole, resisterRightFootHole };
        foreach (var hole in holes)
        {
            hole.isSoldered = false;
            hole.solderingTime = solderingTime;
        }
    }

    void Update()
    {
        // check insert and snap
        if (LEDLeftFootHole.footTouching && LEDRightFootHole.footTouching && !LEDLeftFootHole.isInserted)
        {
            // snap LED
            Object.Destroy(LED);
            holderedLED.SetActive(true);
            LEDLeftFootHole.isInserted = true;
            LEDRightFootHole.isInserted = true;
        }
        if (resisterLeftFootHole.footTouching && resisterRightFootHole.footTouching && !resisterLeftFootHole.isInserted)
        {
            // snap resister
            Object.Destroy(resister);
            holderedResister.SetActive(true);

            resisterLeftFootHole.isInserted = true;
            resisterRightFootHole.isInserted = true;
        }

        // check solder completed
        if (!solderCompleted)
        {
            bool completed = true;
            foreach (var hole in holes)
            {
                completed &= hole.isSoldered;
            }
            solderCompleted = completed;
        }

        if (solderCompleted)
        {
            holderedLEDLight.SetActive(pushSwitch.GetComponent<Switch>().isPushed);
        }
    }
}
