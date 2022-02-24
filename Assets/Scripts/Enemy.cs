using UnityEngine;

public class Enemy : MonoBehaviour {

    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float health = 100;
    public int strenght = 1;
    public int damage = 2;
    public int worth = 15;

    void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage (float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
    }

    public void Slow (float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        PlayerStats.Money += worth;
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }
}
