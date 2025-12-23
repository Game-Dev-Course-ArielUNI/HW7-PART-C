using UnityEngine;

public class EnemyLookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void Update()
    {
        if (player == null) return;

        Vector3 dir = player.position - transform.position;
        dir.y = 0f;

        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(dir);
        }
    }
}








//using UnityEngine;

//public class EnemyLookAtPlayer : MonoBehaviour
//{
//    [SerializeField] private Transform player;

//    private void Update()
//    {
//        Vector3 direction = player.position - transform.position;
//        direction.y = 0f;

//        if (direction != Vector3.zero)
//        {
//            transform.rotation = Quaternion.LookRotation(direction);
//        }
//    }
//}
