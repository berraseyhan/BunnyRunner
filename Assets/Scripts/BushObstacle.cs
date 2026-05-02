using UnityEngine;

public class BushObstacle : Obstacle
{
    public override void OnHitPlayer()
    {
        Debug.Log("Caliya carptin!");
    }
}
