using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
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
        if (other.gameObject.CompareTag("enemy") && canTakeDamage)
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
        SceneManager.LoadScene("GameOver");
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