using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Starter : MonoBehaviour
{
    public Board board;
	public Player player1;
	public Player player2;
	public Ghost currghost;
	public Player currplayer;
	public int stage = -8;
	public Color32 good = new Color32(180, 100, 100, 100);
	public Color32 bad = new Color32(180, 100, 200, 100);
	
	public void NextPlayer()
	{
		this.currplayer.ToOpp();
		if(currplayer.Equals(player1))
		{
			currplayer = player2;
		} else 
		{
			currplayer = player1;
		}
		this.currplayer.ToStandard();
	}

	public void Readiness(bool ready)
	{
		if(currghost != null)
		{
			int x = currghost.field.vec.x;
			int y = currghost.field.vec.y;
			for(int i=-1;i<2;i++)
			{
				for(int j=-1;j<2;j++)
				{
					if(x+i>-1 && x+i<8 && y+j>-1 && y+j<8 && (i!=0 || j!=0))
					{
						this.board.cells[x+i,y+j].ready = ready;
						this.board.cells[x+i,y+j].Color(ready);
					}
				}
			}
		}
	}
	
	public void Play()
	{
		this.player1.Setup();
		this.player2.Setup();
		player1.Create(this);
		player2.Create(this);
		player2.ToOpp();
		this.currplayer = player1;
		this.stage = -7;
	}

    void Start()
    {
		board.Create();
		Ghost.starter = this;
		Cell.starter = this;
        this.Play();
    }
}
