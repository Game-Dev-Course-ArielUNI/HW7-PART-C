using UnityEngine;
using System.Collections;

public class EnemyShooter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform shootOrigin;

    [Header("Shooting")]
    [SerializeField] private float shootRange = 25f;
    [SerializeField] private float fireRate = 1.5f;
    [SerializeField] private int damage = 1;

    private LineRenderer line;
    private float nextFireTime;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        line.enabled = false;
    }

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
        Vector3 start = shootOrigin.position;
        Vector3 direction = shootOrigin.forward;
        Vector3 end = start + direction * shootRange;

        RaycastHit hit;
        if (Physics.Raycast(start, direction, out hit, shootRange))
        {
            end = hit.point;

            if (hit.collider.CompareTag("Player"))
            {
                PlayerHealth health = hit.collider.GetComponent<PlayerHealth>();
                if (health != null)
                {
                    health.TakeDamage(damage);
                }
            }
        }

        StartCoroutine(ShowLaser(start, end));
    }

    private IEnumerator ShowLaser(Vector3 start, Vector3 end)
    {
        line.enabled = true;
        line.SetPosition(0, start);
        line.SetPosition(1, end);

        yield return new WaitForSeconds(0.05f);

        line.enabled = false;
    }
}









//using UnityEngine;

//public class EnemyShooter : MonoBehaviour
//{
//    [Header("Shooting")]
//    [SerializeField] private Transform shootOrigin;
//    [SerializeField] private float shootRange = 25f;
//    [SerializeField] private float fireRate = 1.5f;
//    [SerializeField] private int damage = 1;

//    private float nextFireTime;

//    private void Update()
//    {
//        if (Time.time >= nextFireTime)
//        {
//            Shoot();
//            nextFireTime = Time.time + fireRate;
//        }
//    }

//    private void Shoot()
//    {
//        Ray ray = new Ray(shootOrigin.position, shootOrigin.forward);
//        RaycastHit hit;

//        if (Physics.Raycast(ray, out hit, shootRange))
//        {
//            if (hit.collider.CompareTag("Player"))
//            {
//                PlayerHealth health = hit.collider.GetComponent<PlayerHealth>();
//                if (health != null)
//                {
//                    health.TakeDamage(damage);
//                }
//            }
//        }

//        Debug.DrawRay(shootOrigin.position, shootOrigin.forward * shootRange, Color.red, 0.5f);
//    }
//}
