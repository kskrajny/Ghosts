using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
	public End end;
	public Board board;
	public GameObject obj; 
    public Ghost[] ghosts = new Ghost[8];
	public int Good = 4; // how many good ghosts alive
	public int Bad = 4; // how many bad ghosts alive
	public int ID;
	public int RolesToSet = 4;
	
	public void Setup()
	{
		for(int i=0;i<8;i++)
		{
			if(ghosts[i] != null)
			{
				Destroy(ghosts[i].gameObject);
			}
		}
		Good = 4;
		Bad = 4;
		RolesToSet = 4;
	}
	
	public void ToOpp()
	{
		for(int i=0;i<8;i++)
		{
			if(ghosts[i] != null)
			{
				ghosts[i].OppColor();
			}
		}
	}
	
	public void ToStandard()
	{
		for(int i=0;i<8;i++)
		{
			if(ghosts[i] != null)
			{
				ghosts[i].StandardColor();
			}
		}
	}
	
	// after that ghosts doesnt have role set yet
	public void Create(Starter s)
	{
		if(this.ID == 1)
		{
			for(int x=2;x<6;x++)
			{
				for(int y=0;y<2;y++)
				{
					int GhostID = y*4+x-2; // it is within {0,..,7}
					GameObject newGhost = Instantiate(obj);
					Cell cell = this.board.getCell(x,y);
					this.ghosts[GhostID] = newGhost.GetComponent<Ghost>();
					this.ghosts[GhostID].Setup(this, cell, GhostID);
					cell.ghost = this.ghosts[GhostID];
					this.ghosts[GhostID].StandardColor();
				}
			}
		}
		if(this.ID == 2)
		{
			for(int x=2;x<6;x++)
			{
				for(int y=0;y<2;y++)
				{
					int GhostID = y*4+x-2; // it is within {0,..,7}
					GameObject newGhost = Instantiate(obj);
					Cell cell = this.board.getCell(x,7-y);
					this.ghosts[GhostID] = newGhost.GetComponent<Ghost>();
					this.ghosts[GhostID].Setup(this, cell, GhostID);
					this.ghosts[GhostID].Setup(this, cell, GhostID);
					cell.ghost = this.ghosts[GhostID];
					this.ghosts[GhostID].StandardColor();
				}
			}
		}
	}
	
	public void Przegrana()
	{
		int i = (this.ID+1)%2;
		this.end.show(i);
	}
	
	public void Wygrana()
	{
		this.end.show(this.ID+1);
	}
}
