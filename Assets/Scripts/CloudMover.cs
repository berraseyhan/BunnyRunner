using UnityEngine;

public class CloudMover : MonoBehaviour
{
    private float speed = 2f;

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -15f)
            Destroy(gameObject);
    }
}