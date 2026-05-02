using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    [SerializeField] protected float speed = 5f;

    protected virtual void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }

    public abstract void OnCollect();
}