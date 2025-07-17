using System.Collections;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject meshObj;      // 수류탄 프리팹
    public GameObject effectObj;    // 파티클 프리팹
    public Rigidbody rigid;

    void Start()
    {
        StartCoroutine(Explosion());
    }

    // 폭발 효과
    IEnumerator Explosion()
    {
        // 3초 뒤 폭발
        yield return new WaitForSeconds(3f);
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
        meshObj.SetActive(false);
        effectObj.SetActive(true);

        RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, 15, Vector3.up, 0, LayerMask.GetMask("Enemy"));

        // Ray에 감지된 Enemy들 데미지 입히기
        foreach (RaycastHit hitObj in rayHits)
        {
            hitObj.transform.GetComponent<Enemy>().HitByGrenade(transform.position);
        }

        Destroy(gameObject, 5);
    }
}
