using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentConfig : MonoBehaviour
{

    public float Rc;
    public float Rs;
    public float Ra;
    public float Ravoid;

    public float Kc;
    public float Ks;
    public float Ka;
    public float Kw;
    public float Kavoid;
    public float Kplayer;
    public float KMinH;

    public float maxA;
    public float maxV;
    public float MaxFieldOfViewAngle = 180;

    public float WanderJitter;
    public float WanderRadius;
    public float WanderDistance;
}
