using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    
    void OnMouseDown()
    {
       	this.Hide();
    }
	
	void Start()
	{
		this.Hide();
	}
	
	public void Hide()
	{
		this.MakeTransparent();
		this.Disable();
	}
	
	public void Show()
	{
		this.MakeVisible();
		this.Enable();
	}
	
	public void MakeVisible()
	{
		this.GetComponent<SpriteRenderer>().color = new Color32(200, 120, 0, 250);
	}
	
	void MakeTransparent()
	{
		this.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 0);
	}
	
	public void Enable()
	{
		this.GetComponent<BoxCollider2D>().enabled = true;
	}
	
	void Disable()
	{
		this.GetComponent<BoxCollider2D>().enabled = false;
	}
}
