using UnityEngine;

public class Carrot : Collectible
{
    public override void OnCollect()
    {
        Debug.Log("Havuc toplandi!");
    }
}
