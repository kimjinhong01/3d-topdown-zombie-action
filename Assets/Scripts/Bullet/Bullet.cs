using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public bool isMelee;
    public bool isRock;

    // 땅에 닿으면 제거
    void OnCollisionEnter(Collision collision)
    {
        if (!isRock && collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject, 3);
        }
    }

    // 벽에 닿으면 제거
    void OnTriggerEnter(Collider other)
    {
        if (!isMelee && other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
