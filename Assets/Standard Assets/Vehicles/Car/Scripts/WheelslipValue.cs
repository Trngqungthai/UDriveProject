using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelslipValue : MonoBehaviour
{
    WheelCollider WheelC;
    public float RoadForwardStiffness = 3.5f;
    public float TerrainForwardStiffness = 0.6f;
    public float RoadSidewaysStiffness = 1.4f;
    public float TerrainSidewaysStiffness = 0.2f;
    private bool Changed = false;
    private void Start()
    {
        WheelC = GetComponent<WheelCollider>();
    }
    private void Update()
    {
        if (SaveScript.OnTheRoad == true)
        {
            if (Changed == false)
            {    
                Changed = true;
                WheelFrictionCurve fFriction = WheelC.forwardFriction;
                fFriction.stiffness = RoadForwardStiffness;
                WheelC.forwardFriction = fFriction;
                
                WheelFrictionCurve sFriction = WheelC.sidewaysFriction;
                sFriction.stiffness = RoadSidewaysStiffness;
                WheelC.sidewaysFriction = sFriction;
            }
        }
        if (SaveScript.OnTheTerrain == true)
        {
            if (Changed == true)
            {
                Changed = false;
                WheelFrictionCurve fFriction = WheelC.forwardFriction;
                fFriction.stiffness = TerrainForwardStiffness;
                WheelC.forwardFriction = fFriction;

                WheelFrictionCurve sFriction = WheelC.sidewaysFriction;
                sFriction.stiffness = TerrainSidewaysStiffness;
                WheelC.sidewaysFriction = sFriction;
            }
        }
    }
}
