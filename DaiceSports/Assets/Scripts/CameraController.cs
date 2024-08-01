using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f; // カメラの移動速度
    public float lookSpeed = 2f; // マウスでの視点の回転速度

    private float yaw = 0f; // 水平方向の回転角度
    private float pitch = 0f; // 垂直方向の回転角度

    void Update()
    {
        // WASDキーでカメラを移動
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(moveX, 0, moveZ);

        // マウスで視点を回転
        yaw += lookSpeed * Input.GetAxis("Mouse X");
        pitch -= lookSpeed * Input.GetAxis("Mouse Y");

        // 回転角度を制限
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        transform.eulerAngles = new Vector3(pitch, yaw, 0);
    }
}