using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLayersManager : MonoBehaviour
{
    [Header("Layers:")] 
    public SingleUnityLayer DeadEndTrigger;
    public SingleUnityLayer Ground;
    public SingleUnityLayer Player;
    public SingleUnityLayer Obstacle;
    public SingleUnityLayer Boss;
    public SingleUnityLayer LampOil;
    public SingleUnityLayer Bandages;
    public SingleUnityLayer FlipProjectileTrigger;
}
