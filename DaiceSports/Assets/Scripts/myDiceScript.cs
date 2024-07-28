using UnityEngine;
using System.Collections;

public class myDiceScript : MonoBehaviour
{
    void Start()
    {
        transform.GetComponent<Rigidbody>().angularVelocity = Vector3.forward * 10;
        transform.GetComponent<Rigidbody>().velocity = new Vector3(1, 1, 0) * 10;
    }
    void Update(){
		if(Input.GetMouseButtonDown(1)){
			Vector3 check_1 = transform.TransformDirection(Vector3.forward);
			Vector3 check_4 = transform.TransformDirection(Vector3.right);
			Vector3 check_5 = transform.TransformDirection(Vector3.up);
			int result = 0;

			if(Mathf.Abs(Mathf.Round(check_1.y)) != 1){
				if(Mathf.Abs(Mathf.Round(check_4.y)) != 1){
					if(Mathf.Round(check_5.y) == 1){
						result = 2;
					}else{
						result = 5;
					}
				}else{
					if(Mathf.Round(check_4.y) == 1){
						result = 4;
					}else{
						result = 3;
					}
				}
			}else{
				if(Mathf.Round(check_1.y) == 1){
					result = 1;
				}else{
					result = 6;
				}
			}

			Debug.Log ("出た目は " + result + " です");
		}
	}
}