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
    SolderHole ResisterLeftFootHole;
    [SerializeField]
    SolderHole ResisterRightFootHole;
    [SerializeField]
    int solderingTime = 100;

    bool solderCompleted = false;

    SolderHole[] holes;

    void Start()
    {
        holes = new SolderHole[] { LEDLeftFootHole, LEDRightFootHole, ResisterLeftFootHole, ResisterRightFootHole };
        foreach (var hole in holes)
        {
            hole.solderingTime = solderingTime;
        }
    }

    void Update()
    {
        // check insert and snap
        if (LEDLeftFootHole.footTouching && LEDRightFootHole.footTouching)
        {
            // snap led
            LEDLeftFootHole.isInserted = true;
            LEDRightFootHole.isInserted = true;
        }
        if (ResisterLeftFootHole.footTouching && ResisterRightFootHole.footTouching)
        {
            // snap resister
            ResisterLeftFootHole.isInserted = true;
            ResisterRightFootHole.isInserted = true;
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
            // Activate LED?
        }
    }
}
