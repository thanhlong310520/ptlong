using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform target;
    public float speed = 70f;

    public float exlosionRadius;
    public GameObject bulletImpactEffectPrefab;

    public int dame = 30;
    public void Seek(Transform _target)
    {
        target = _target;
    }
    
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if(dir.magnitude <= distanceThisFrame){
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        transform.LookAt(target);

    }

    void HitTarget()
    {
        GameObject effect = Instantiate(bulletImpactEffectPrefab, transform.position, transform.rotation);
        if (exlosionRadius > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(effect, 5f);
        Destroy(gameObject);
        
    }
    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if(e != null)
        {
            e.TakeDamage(dame);
        }
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, exlosionRadius);
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
}
