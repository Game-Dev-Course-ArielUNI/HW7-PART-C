using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] private Transform shootOrigin;
    [SerializeField] private float shootRange = 25f;
    [SerializeField] private float fireRate = 1.5f;
    [SerializeField] private int damage = 1;

    private float nextFireTime;

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Shoot()
    {
        Ray ray = new Ray(shootOrigin.position, shootOrigin.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, shootRange))
        {
            if (hit.collider.CompareTag("Player"))
            {
                PlayerHealth health = hit.collider.GetComponent<PlayerHealth>();
                if (health != null)
                {
                    health.TakeDamage(damage);
                }
            }
        }

        Debug.DrawRay(shootOrigin.position, shootOrigin.forward * shootRange, Color.red, 0.5f);
    }
}
