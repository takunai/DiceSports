using UnityEngine;

public class MovingWall : MonoBehaviour
{
    // 壁の移動速度
    public float speed = 5.0f;

    void Update()
    {
        // 壁を前方に移動させる
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}