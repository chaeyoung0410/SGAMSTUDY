using UnityEngine;

public class Coin : MonoBehaviour
{
    private float minY = -7f;

    void Start()
    {
        Jump();
    }

    void Jump()
    {
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        if (rigidBody == null)
        {
            return;
        }

        float randomJumpForce = Random.Range(4f, 8f);
        Vector2 jumpVelocity = Vector2.up * randomJumpForce;
        jumpVelocity.x = Random.Range(-2f,2f);

        rigidBody.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
        
    }

}
