using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
public float speed = 10f;
public float startHealth = 100;
public int killValue = 10;
public GameObject deathEffect;
public Image healthBar;

private float health;
private Transform target;
private int waypointIndex = 0;

    void Start()
        {
            target = Waypoints.points[0];
            health = startHealth;
        }

    public void TakeDamage(int amount)
        {
        health -= amount;
        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
            {
                Die();
            }
        }

    private void Die()
        {
            GameObject deathParticles = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(deathParticles, 2f);
            PlayerStats.money += killValue;
            Destroy(gameObject);
        }

private void Update()
{
    Vector3 dir = target.position - transform.position;
    transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

    if(Vector3.Distance(transform.position, target.position) <= 0.3f)
    {
        GetNextWaypoint();
    }
}
    private void GetNextWaypoint()
{
    if(waypointIndex >= Waypoints.points.Length - 1)
    {
        EndPath();
        return;
    }
    waypointIndex++;
    target = Waypoints.points[waypointIndex];
}

    private void EndPath()
    {
        PlayerStats.lives--;
        Destroy(gameObject);
    }

}
