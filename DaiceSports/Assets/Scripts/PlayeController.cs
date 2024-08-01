using UnityEngine;

public class PlayeController : MonoBehaviour
{
    public Transform Camera;
    public float PlayerSpeed;
    public float RotationSpeed;

    Vector3 speed = Vector3.zero;
    Vector3 rot = Vector3.zero;

    public Animator PlayerAnimater;
    bool isRun;

    // Start is called before the first frame update
    void Start()
    {
        // GameManagerからダイスの目を取得してスピードを設定
        if (GameManager.instance != null)
        {
            int diceResult = GameManager.instance.diceResult;
            PlayerSpeed = diceResult * 0.1f;
        }
        else
        {
            Debug.LogError("GameManagerが見つかりません！");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotation();
        Camera.transform.position = transform.position;

        // プレイヤーのY座標をチェック
        if (transform.position.y <= -100)
        {
            Destroy(gameObject);
        }
    }

    void Move()
    {
        speed = Vector3.zero;
        rot = Vector3.zero;
        isRun = false;

        if (Input.GetKey(KeyCode.W))
        {
            rot.y = 0;
            MoveSet();
        }
        if (Input.GetKey(KeyCode.S))
        {
            rot.y = 180;
            MoveSet();
        }
        if (Input.GetKey(KeyCode.A))
        {
            rot.y = -90;
            MoveSet();
        }
        if (Input.GetKey(KeyCode.D))
        {
            rot.y = 90;
            MoveSet();
        }

        transform.Translate(speed);
        PlayerAnimater.SetBool("run", isRun);
    }

    void MoveSet()
    {
        speed.z = PlayerSpeed;
        transform.eulerAngles = Camera.transform.eulerAngles + rot;
        isRun = true;
    }

    void Rotation()
    {
        var speed = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed.y = -RotationSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed.y = RotationSpeed;
        }

        Camera.transform.eulerAngles += speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DamageWall")
        {
            Destroy(gameObject);
        }
    }
}