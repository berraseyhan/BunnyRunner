using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    

    protected virtual void Update()
    {
        transform.Translate(Vector3.left * SpawnManager.gameSpeed * Time.deltaTime);

        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }

    public abstract void OnCollect();
}