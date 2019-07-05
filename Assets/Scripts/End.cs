using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class End : MonoBehaviour
{	
	public Starter starter;
	
    void Start()
    {
        this.Disable();
    }

    public void Show(int i)
	{
		this.Enable();
		this.GetComponent<Text>().text = "Player "+i+" wins!!!";
	}
	
	public void Hide()
	{
		this.Disable();
		this.GetComponent<Text>().text = "";
	}
	 
	private void Enable()
	{
		this.GetComponent<BoxCollider2D>().enabled = true;
	}
	
	private void Disable()
	{
		this.GetComponent<BoxCollider2D>().enabled = false;
	}
}
