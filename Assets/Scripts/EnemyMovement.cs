using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private Vector2 startPosition;
    [SerializeField] private float patrolDistance = 2f;
    private int moveDirection = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        startPosition = rb.position;
    }

    private void FixedUpdate()
    {
        MoveEnemy();
        CheckPatrolLimit();
    }

    private void MoveEnemy()
    {
        Vector2 newPosition = rb.position;

        newPosition.x += moveDirection
                       * moveSpeed
                       * Time.fixedDeltaTime;

        rb.MovePosition(newPosition);
    }

    private void CheckPatrolLimit()
    {
        if (rb.position.x >= startPosition.x + patrolDistance)
        {
            moveDirection = -1;
            FlipSprite();
        }

        else if (rb.position.x <= startPosition.x - patrolDistance)
        {
            moveDirection = 1;
            FlipSprite();
        }
    }

    private void FlipSprite()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
}