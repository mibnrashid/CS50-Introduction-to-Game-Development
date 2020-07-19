using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {

	public GameObject empty;
	private Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		text.color = new Color(0, 0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (empty != null) {
			
		}
		else {
			text.color = new Color(0, 0, 1, 1);
			text.text = "You Won!!!";
		}
	}
}
