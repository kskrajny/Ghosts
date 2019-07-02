using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{

	public static Starter starter;
	[HideInInspector]
	public Vector2Int vec = Vector2Int.zero;
	[HideInInspector]
	public Board board = null;
	[HideInInspector]
	public RectTransform rectrans = null;
	[HideInInspector]
	public Ghost ghost = null;
	public bool ready = false; // says if current ghost can go there
	public static Color32 highligth = new Color32(180, 200, 50, 200);
	public Color32 standard;
			
    public void Setup(Board b, Vector2Int p)
    {
        this.board = b;
		this.vec = p;
		this.rectrans = GetComponent<RectTransform>();
    }
	
	public void Color(bool ready)
	{
		if(ready)
		{
			this.GetComponent<SpriteRenderer>().color = Cell.highligth;
		} 
		else
		{
			this.GetComponent<SpriteRenderer>().color = this.standard;
		}
	}
	
	void OnMouseDown()
	{
		if(this.ready && starter.stage==2)
		{
			starter.Readiness(false);
			this.ghost = starter.currghost;
			starter.currghost.field = this;
			starter.currghost.StandardColor();
			starter.currghost.move(this);
			starter.stage = 1;
			starter.currghost = null;
			starter.NextPlayer();
		}
	}
}	