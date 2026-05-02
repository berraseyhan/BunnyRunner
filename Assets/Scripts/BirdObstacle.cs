using UnityEngine;

public class BirdObstacle : Obstacle
{
    [SerializeField] private bool isLow = true;

    public bool IsLow => isLow;

    public override void OnHitPlayer()
    {
        Debug.Log("Kusa carptin!");
    }
}