using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour

{
    [SerializeField]
    private float moveSpeed; 

    [SerializeField]
    private GameObject[] weapons; 
    private int weaponIndex = 0; 

    [SerializeField]
    private Transform shootTransform; 

    [SerializeField]
    private float shootInterval = 0.05f; 
    private float lastShotTime = 0f;


    void Update()
    {
        if (GameManager.instance != null && GameManager.instance.IsGameOver)
        {
            return;
        }

        if (Mouse.current == null || Camera.main == null)
        {
            Shoot();
            return;
        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        float toX=Mathf.Clamp(mousePos.x, -2.35f, 2.35f); 

        transform.position = new Vector3(
            toX,
            transform.position.y,
            transform.position.z
        );

        Shoot();
    
    }

    void Shoot() {
        if (weapons == null || weapons.Length == 0 || shootTransform == null)
        {
            return;
        }

        if (Time.time - lastShotTime > shootInterval) {
            Instantiate(weapons[weaponIndex], shootTransform.position, Quaternion.identity);
            lastShotTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy") || other.CompareTag("Boss")) {
            if (GameManager.instance != null)
            {
                GameManager.instance.SetGameOver();
            }

            Destroy(gameObject);
        } else if (other.CompareTag("Coin"))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.IncreaseCoin();
            }

            Destroy(other.gameObject); 
        }

    }

    public void Upgrade()
    {
        if (weapons == null || weapons.Length == 0)
        {
            return;
        }

        weaponIndex += 1;
        if (weaponIndex >= weapons.Length)
        {
            weaponIndex = weapons.Length - 1;
        }
    }


}
