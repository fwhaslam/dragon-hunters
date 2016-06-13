using UnityEngine;
using System.Collections;

public class Tile {

    TileType type;
	public int logicalX, logicalY;
	public float visualBaseX, visualBaseY;
	public bool stepRow;

	public Tile( int logx, int logy, TileType type){

		this.type = type;

		this.logicalX = logx;
		this.logicalY = logy;
		this.stepRow = (logicalY & 1) == 1;  // row is offset 1/2 tile

		this.visualBaseX = (logicalX * 2 + (logicalY & 1)) * TacticalShared.TILE_VISUAL_WIDTH/2f;
		this.visualBaseY = (logicalY) * TacticalShared.TILE_VISUAL_HEIGHT;

		// tile offset ( Y is negative at bottom )
		this.visualBaseX += TacticalShared.TILE_VISUAL_WIDTH/4f;
		this.visualBaseY += TacticalShared.TILE_VISUAL_HEIGHT/2f;
			
	}
		
	public float getX(){
		return visualBaseX;
	}

	public float getY(){ 
		return visualBaseY;
	}

	public void setType(TileType type){
		this.type = type;
	}

	public TileType getType(){
		return type;
	}

}
