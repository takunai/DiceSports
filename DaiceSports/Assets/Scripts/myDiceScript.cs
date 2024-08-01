using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class myDiceScript : MonoBehaviour
{
    void Start()
    {
        // リジッドボディの参照を取得
        Rigidbody rb = transform.GetComponent<Rigidbody>();

        // ランダムな角速度を設定
        rb.angularVelocity = new Vector3(
            Random.Range(-10f, 10f),
            Random.Range(-10f, 10f),
            Random.Range(-10f, 10f)
        );

        // ランダムな速度を設定
        rb.velocity = new Vector3(
            Random.Range(-10f, 10f),
            Random.Range(-10f, 10f),
            Random.Range(-10f, 10f)
        );

        // 15秒後にMainSceneに移動
        StartCoroutine(WaitAndLoadMainScene(15f));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 check_1 = transform.TransformDirection(Vector3.forward);
            Vector3 check_4 = transform.TransformDirection(Vector3.right);
            Vector3 check_5 = transform.TransformDirection(Vector3.up);
            int result = 0;

            if (Mathf.Abs(Mathf.Round(check_1.y)) != 1)
            {
                if (Mathf.Abs(Mathf.Round(check_4.y)) != 1)
                {
                    if (Mathf.Round(check_5.y) == 1)
                    {
                        result = 2;
                    }
                    else
                    {
                        result = 5;
                    }
                }
                else
                {
                    if (Mathf.Round(check_4.y) == 1)
                    {
                        result = 4;
                    }
                    else
                    {
                        result = 3;
                    }
                }
            }
            else
            {
                if (Mathf.Round(check_1.y) == 1)
                {
                    result = 1;
                }
                else
                {
                    result = 6;
                }
            }

            Debug.Log("出た目は " + result + " です");

            // GameManagerにダイスの目を保存
            GameManager.instance.diceResult = result;
        }
    }

    IEnumerator WaitAndLoadMainScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("MainScene");
    }
}