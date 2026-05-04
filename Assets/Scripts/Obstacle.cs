using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    [SerializeField] protected float speed = 5f;

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        transform.Translate(Vector3.left * SpawnManager.gameSpeed * Time.deltaTime);

        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }

    public abstract void OnHitPlayer();
}
