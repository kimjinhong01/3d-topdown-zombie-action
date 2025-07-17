using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void Update()
    {
        // 카메라 위치를 offset에 맞게 위치 조정
        transform.position = target.position + offset;
    }
}
