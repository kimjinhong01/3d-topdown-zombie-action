using UnityEngine;

public class StartZone : MonoBehaviour
{
    public GameManager manager;

    // 플레이어가 밟으면 스테이지 시작
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            manager.StageStart();
    }
}
