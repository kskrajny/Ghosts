	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
	public static Starter starter;
	public Cell field;
	public static Color32 highligth = new Color32(200, 0, 150, 250);
	public static Color32 bad = new Color32(250, 0, 0, 250);
	public static Color32 good = new Color32(0, 0, 250, 250);
	public static Color32 opponent = new Color32(50, 250, 50, 250);
	public bool role = false;
	public Player player;
	public int ID;
    
	void Start()
	{
		this.StandardColor();
	}
	
	public void Setup(Player p, Cell f, int id)
	{
		this.player = p;
		this.field = f;
		this.move(f);
		this.ID = id;
		
	}
	
	void OnMouseDown()
	{
		if(starter.currplayer.Equals(this.player) && starter.stage < 1)
		{
			starter.stage++;
			this.player.RolesToSet--;
			this.role = true;
			this.GoodColor();
			if(this.player.RolesToSet == 0)
			{
				starter.NextPlayer();
			}
		}
		if(starter.currplayer.Equals(this.player) && starter.stage == 1)
		{
			starter.currghost = this;
			this.FancyColor();
			starter.stage = 2;
			starter.Readiness(true);
		}
		if(!starter.currplayer.Equals(this.player) && starter.stage == 2)
		{
			Cell cell = this.field;
			starter.Readiness(false);
			field.ghost = starter.currghost;
			starter.currghost.field = field;
			starter.currghost.StandardColor();
			starter.currghost.move(field);
			starter.stage = 1;
			starter.currghost = null;
			starter.NextPlayer();
			if(this.role == true)
			{
				this.player.Good--;
				if(this.player.Good < 1) 
				{
					this.player.Przegrana();
				}
			}
			if(this.role == false)
			{
				this.player.Bad--;
				if(this.player.Bad < 1) 
				{
					this.player.Wygrana();
				}
			}
			Destroy(this.gameObject);
		}
		
	}
    
	public void StandardColor()
	{
		if(this.role == false)
		{
			this.GetComponent<SpriteRenderer>().color = Ghost.bad;
		}
		if(this.role == true)
		{
			this.GetComponent<SpriteRenderer>().color = Ghost.good;
		}
	}
	
	public void GoodColor()
	{
		this.GetComponent<SpriteRenderer>().color = Ghost.good;
	}
	
	public void FancyColor()
	{
		this.GetComponent<SpriteRenderer>().color = Ghost.highligth;
	}
	
	public void OppColor()
	{
		this.GetComponent<SpriteRenderer>().color = Ghost.opponent;
	}
	
	public void move(Cell Nfield)
	{
		this.field = Nfield;
		this.GetComponent<RectTransform>().anchoredPosition =
			Nfield.GetComponent<RectTransform>().anchoredPosition;
	}
	
}
