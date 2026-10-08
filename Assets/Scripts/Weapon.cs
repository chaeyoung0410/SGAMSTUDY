using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    [SerializeField]
    private float moveSpeed = 20; 

    void Start()
    {
        Destroy(gameObject, 1f); 
    }

    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy == null)
        {
            return;
        }

        if (enemy.CompareTag("Boss"))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.SetGameOver();
            }

            Destroy(gameObject);
            return;
        }

        enemy.TakeDamage(1f);
        Destroy(gameObject);
    }
    
    
}
