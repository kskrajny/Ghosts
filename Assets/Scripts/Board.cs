using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class Board : MonoBehaviour
{
	public GameObject obj;
	public Cell[,] cells = new Cell[8,8];
	
	public Cell getCell(int x, int y)
	{
		return cells[x,y];
	}
	
	
	public void Create(){
		for(int x=0;x<8;x++){
			for(int y=0;y<8;y++){
				GameObject newCell = Instantiate(obj);
				RectTransform rt = 	newCell.GetComponent<RectTransform>();
				rt.anchoredPosition = new Vector2(x*100+50, y*100+50);
				this.cells[x,y] = newCell.GetComponent<Cell>();
				this.cells[x,y].Setup(this, new Vector2Int(x,y));
				int color = (x+y)%2;
				if(color == 0)
				{
					this.cells[x,y].standard = new Color32(180,250,250,250);
					this.cells[x,y].Color(false);
				} else {
					this.cells[x,y].standard = new Color32(180,250,250,50);
					this.cells[x,y].Color(false);
				}
			}
		}
	}

}
