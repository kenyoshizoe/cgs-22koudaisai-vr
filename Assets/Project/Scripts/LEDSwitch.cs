using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 触れたらLEDが点灯する
public class LEDSwitch : MonoBehaviour
{
	public string tagName;
	public string showObjectName;  
	GameObject showObject;

	void Start() 
	{
		showObject = GameObject.Find(showObjectName);
		if (showObject) // 見つけたら
		{
			showObject.SetActive(false); // 消す
		}
	}

	
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == tagName)
            {
				showObject.SetActive(true); // 消していたものを点灯する
            
            }
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == tagName)
            {
				showObject.SetActive(false); // 点灯したものを消す
            
            }
	}
}
