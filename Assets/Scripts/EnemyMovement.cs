using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{

    private Transform target;
    private int wavepointIndex = 0;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();

        target = WayPoints.waypoints[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            GetNextWayPoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    void GetNextWayPoint()
    {
        if (wavepointIndex >= WayPoints.waypoints.Length - 1)
        {
            PathEnd();
            return;
        }

        wavepointIndex++;
        target = WayPoints.waypoints[wavepointIndex];
    }

    void PathEnd()
    {
        PlayerStats.Lives-= enemy.damage;
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }
}
