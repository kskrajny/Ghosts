using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public Starter starter;
	
	void OnMouseDown()
	{
		starter.Play();
	}
}
