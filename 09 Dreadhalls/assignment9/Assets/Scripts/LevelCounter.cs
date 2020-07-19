using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LevelCounter : MonoBehaviour {

	private Text text;
	private static int level = 1;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		level = DontDestroy.Level;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Level: " + level;
	}
}
