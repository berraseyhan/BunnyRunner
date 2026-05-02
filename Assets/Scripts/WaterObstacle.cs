using UnityEngine;

public class WaterObstacle : Obstacle
{
    public override void OnHitPlayer()
    {
        Debug.Log("Suya dustun!");
    }
}
