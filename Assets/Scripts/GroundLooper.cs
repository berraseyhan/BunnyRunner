using UnityEngine;

public class GroundLooper : MonoBehaviour
{
    private float spriteWidth;
    private float leftExitPoint = -11f;

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = spriteRenderer.bounds.size.x;
    }

    void Update()
    {
        transform.Translate(Vector3.left * SpawnManager.gameSpeed * Time.deltaTime);

        if (transform.position.x <= leftExitPoint)
        {
            RepositionToFront();
        }
    }

    void RepositionToFront()
    {
        GroundLooper[] allPieces = FindObjectsByType<GroundLooper>();

        float furthestRightX = transform.position.x;

        foreach (GroundLooper piece in allPieces)
        {
            if (piece.transform.position.x > furthestRightX)
            {
                furthestRightX = piece.transform.position.x;
            }
        }

        Vector3 newPos = transform.position;
        newPos.x = furthestRightX + (spriteWidth - 0.07f);
        transform.position = newPos;
    }
}