using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class End : MonoBehaviour
{	
	public Starter starter;
	
    void Start()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void show(int i)
	{
		this.GetComponent<BoxCollider2D>().enabled = true;
		this.GetComponent<Text>().text = "Player "+i+"wins!!!";
	}
	
	void OnMouseDown()
	{
		this.GetComponent<BoxCollider2D>().enabled = false;
		this.GetComponent<Text>().text = "";
		this.starter.Play();
	}
}
