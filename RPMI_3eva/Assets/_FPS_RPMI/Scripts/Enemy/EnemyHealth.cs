using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health System Configuration")]
    [SerializeField] int health;
    [SerializeField] int maxHealth;

    [Header("Feedback Configuration")]
    [SerializeField] Material damagedMat;
    [SerializeField] MeshRenderer enemyRend;
    [SerializeField] GameObject deathVfx;
    Material baseMat;

    private void Awake()
    {
        health = maxHealth;
        baseMat = enemyRend.material;
    }





    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            health = 0;
            deathVfx.SetActive(true);
            deathVfx.transform.position = transform.position;    
            gameObject.SetActive(false);

        }
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        enemyRend.material = damagedMat;
        Invoke(nameof(ResetEnemyMat), 0.1f);
    }

   void ResetEnemyMat()
    {
        enemyRend.material = baseMat;
    }
    
       
  




}
