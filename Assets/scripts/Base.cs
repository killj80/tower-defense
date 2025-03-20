using UnityEngine;

public class Base : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<EnemyPath>().BaseReached();
    }
}
