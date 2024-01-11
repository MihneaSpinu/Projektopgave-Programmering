using System.Collections;
using System.Threading;
using UnityEngine;

public class Dummy_Test_Atk : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private float damageDelay = 1f; // delay in seconds
    [SerializeField] private int damage = 10;
    private bool canTakeDamage = true;
    
    // Start is called before the first frame update
    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.

    }
    // Update is called once per frame
    void Update()
    {

    }

private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("seard") && canTakeDamage)
        {
            StartCoroutine(DamageDelay());
            TakeDamage(damage);
            Debug.Log("I took damage");
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    IEnumerator DamageDelay()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageDelay);
        canTakeDamage = true;
    }

    public void Die()
    {
        Debug.Log("I died");
        Destroy(gameObject);
    }

    public int GetHealth()
    {
        return health;
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
    }
}

/*
CanvasRect = GameObject.Find("Canvas").GetComponent<RectTransform>();
        GameObject healthBar = Instantiate(healthBarPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        healthBar.transform.SetParent(CanvasRect.transform, false);
        healthBar.transform.position = new Vector3(healthBar.transform.position.x + 130, healthBar.transform.position.y + 20, healthBar.transform.position.z);
        healthBar.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
*/