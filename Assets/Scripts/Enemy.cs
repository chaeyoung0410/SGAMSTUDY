using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject coin; 


    [SerializeField]
    private float moveSpeed = 5f;

    private float minY = -7f;
    [SerializeField]
    private float hp = 1f;

    private bool isDead;

    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    public void TakeDamage(float damage)
    {
        if (isDead)
        {
            return;
        }

        hp -= damage;

        if (hp <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        if (GameManager.instance != null)
        {
            GameManager.instance.IncreaseScore(10);
        }

        if (coin != null)
        {
            Instantiate(coin, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }

}
