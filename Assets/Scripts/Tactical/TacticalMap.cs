using System;
using System.Collections.Generic;

public class TacticalMap {

	public List<Tile> tiles;
	public Tile[,] grid;
	public int width, height;

	public float viewWidth, viewHeight, viewScrollLimit;

	public TacticalMap(){
		width = height = 0;
		grid = new Tile[0, 0];
		tiles = new List<Tile> ();

		viewWidth = viewHeight = viewScrollLimit = 0;
	}
		
	public TacticalMap prepare(int width, int height){
		this.width = width;
		this.height = height;
		tiles.Clear ();
		grid = new Tile[width, height];

		viewWidth = width * TacticalShared.TILE_VISUAL_WIDTH;
		viewHeight = height * TacticalShared.TILE_VISUAL_HEIGHT;
		viewScrollLimit = (viewWidth > viewHeight ? viewWidth : viewHeight) / 2f;

		return this;
	}

	public Tile makeTile( int logx, int logy, TileType type) {
		Tile tile = new Tile (logx, logy, type);
		tiles.Add(tile);
		grid [logx, logy] = tile;
		return tile;
	}

	public List<Tile> getTiles(){ return tiles; }

	public Tile getTile(int x,int y){
		return grid [x, y];
	}

	public Tile getTileSafe(int x,int y){
		if (x < 0 || y < 0 || x >= width || y >= height)
			return null;
		return grid [x, y];
	}

	public float visualXOffset(){ return viewWidth / 2f; }
	public float visualYOffset(){ return viewHeight / 2f; }

	public float visualWidth(){ return viewWidth; }
	public float visualHeight(){ return viewHeight; }

	public float visualScrollLimit(){return viewScrollLimit;}

}
