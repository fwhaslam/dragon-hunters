using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileTypeStore {

	Dictionary<string,TileType> tileTypes = new Dictionary<string,TileType>();

	public void add( TileType type) {
		tileTypes [type.name] = type;
	}

	public TileType find(string key){
		return tileTypes [key];
	}

}
	
