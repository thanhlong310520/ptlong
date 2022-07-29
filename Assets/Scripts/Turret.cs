using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;
    public float range = 15f; // phạm vi hoạt động

    string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    // for shooting
    public float fireRate = 1f;
    private float fireCountdown = 0;
    public GameObject bulletPrefab;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); // khi Start hoat dong thi goi ham UpdateTarget sau 0s va lap lai sau 0.5f;
    }
    void Update()
    {
        if (target == null) // neeus target rỗng thì không làm gì cả
            return;
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation,turnSpeed*Time.deltaTime).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(new Vector3(0, rotation.y, 0));

        if(fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1 / fireRate;
        }
        fireCountdown -= Time.deltaTime;

    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); // tìm tất cả các enemy
        GameObject neareatEnemy = null; // khai bao 1 gameObject chua enemy gan nhat;
        float shotestDistance = Mathf.Infinity; // mới đầu gám vị trí ngắn nhất = vô cực
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); // khoang cach cua enemy toi turret
            if(distanceToEnemy < shotestDistance)
            {
                shotestDistance = distanceToEnemy; // neu khoang cach ngan nhat ma lon hon khoang cach cua enemy thi doi
                neareatEnemy = enemy; // gan GO bang enemy gan nhat
            }
        }
        if (neareatEnemy != null && shotestDistance <= range)
        {
            // nếu vị trí của enemy gần nhất mà nhỏ hơn bán kính hoạt động thì gán vị trí target bằng vị trí của enemy
            target = neareatEnemy.transform;
        }
        else
            target = null;
    }

    void Shoot()
    {
        GameObject buletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        Bullet bullet = buletGO.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
