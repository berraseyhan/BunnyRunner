using UnityEngine;

public class FenceObstacle : Obstacle
{
    public override void OnHitPlayer()
    {
        Debug.Log("Cite carptin!");
    }
}
