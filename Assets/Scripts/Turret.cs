using UnityEngine;
using System.Collections;

internal enum EnemyType
{
    Strongest,
    Fastest,
    Normal
}

public class Turret : MonoBehaviour {

    

    public static bool strongest = false;
    public static bool fastest = false;
    private Transform target;
    private Enemy targetEnemy;

    [Header("General")]

    [SerializeField]
    private static EnemyType enemyType = EnemyType.Normal;
    public float range = 12f;
    public bool useFireEffect = false;
    public ParticleSystem fireEffect;
    public bool useLaserPointer = false;
    public LineRenderer laserPointer;
    public Transform laserStart;

    [Header("Use Bullets (default)")]

    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("Use Laser")]
    public bool useLaser = false;

    public int damageOverTime = 30;
    public float slowAmount = .5f;

    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    [Header("Unity Setup fields")]

    public string enemyTag = "Enemy";

    public Transform PartToRotate;
    public float turnSpeed = 10f;

    public Transform firePoint;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        
        if (nearestEnemy != null && shortestDistance <= range)
        {
            if (target == null)
            {
                target = nearestEnemy.transform;
                targetEnemy = nearestEnemy.GetComponent<Enemy>();
                if (useFireEffect)
                {
                    fireEffect.Play();
                }
            }
        }
        else
        {
            target = null;
            if (target == null)
            {
                if(useFireEffect)
                {
                    fireEffect.Stop();
                }
                if (laserPointer)
                {
                    laserPointer.enabled = false;
                }
            }
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
                   
            }

            return;
        }
            

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountDown <= 0f)
            {
                Shoot();
                fireCountDown = 1f / fireRate;
                
            }

            fireCountDown -= Time.deltaTime;
        }

	}

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (laserPointer)
        {
            LaserPointer();
        }
    }

    void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowAmount);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);

    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);

    }

    void LaserPointer()
    {
        if (!laserPointer.enabled)
        {
            laserPointer.enabled = true;
        }

        laserPointer.SetPosition(0, laserStart.position);
        laserPointer.SetPosition(1, target.position);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void SelectNormalEnemy()
    {
        enemyType = EnemyType.Normal;
    }

    public void SelectFastestEnemy()
    {
        enemyType = EnemyType.Fastest;
    }

    public void SelectStrongestEnemy()
    {
        enemyType = EnemyType.Strongest;
    }
}
