using UnityEngine;

public class Missile : MonoBehaviour
{
    void Update()
    {
        // x축이 계속 돌아감
        transform.Rotate(Vector3.right * 30 * Time.deltaTime);
    }
}
