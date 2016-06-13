using System;
using System.Collections;
using System.Collections.Generic;


public class SimpleMap {

	static public void make(TacticalMap map, TileTypeStore store){

		map.prepare (23, 27);

		TileType grass = store.find ("Grass");
		TileType desert = store.find ("Desert");
		TileType edge = store.find ("Edge");

		for (int iy = 0; iy < map.height; iy++) {
			for (int ix = 0; ix < map.width; ix ++) {
				TileType pick = ( ((ix + iy) %3 ) == 0 ? grass : desert);
				map.makeTile (ix, iy, pick);
			}
		}
			
		markEdge ( edge, map );

	}

	static void markEdge( TileType edge, TacticalMap map ){
		
		foreach (Tile tile in map.getTiles()) {

			if (tile.logicalX == 0 || tile.logicalX >= map.width - 1 ||
				tile.logicalY == 0 || tile.logicalY >= map.height - 1) {

					tile.setType (edge);
			}
		}
	}

}

