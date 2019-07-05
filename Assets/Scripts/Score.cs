using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public void Change(int g, int b)
	{
	   	this.GetComponent<Text>().text = "Good: "+g+"\nBad: "+b;
	}
}
