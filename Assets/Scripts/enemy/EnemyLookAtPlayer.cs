using UnityEngine;

public class EnemyLookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0f;

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
