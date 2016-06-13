using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TacticalControl : MonoBehaviour {

    public TileType[] tileTypeList;

	public GameObject tileParent;

	// Use this for initialization
	void Start () {

		foreach (TileType tileType in tileTypeList)
			TacticalShared.tileTypes.add (tileType);
	
		SimpleMap.make (TacticalShared.map, TacticalShared.tileTypes);

		createVisualMap ( TacticalShared.map );
	}

	void createVisualMap( TacticalMap map ){

		float offx = map.visualXOffset ();
		float offy = map.visualYOffset ();

		foreach (Tile tile in map.getTiles()) {

			GameObject newTile = (GameObject)Instantiate( 
				tile.getType().prefab, 
				new Vector3( tile.getX() - offx, tile.getY() - offy, 0f ), 
				Quaternion.identity );

			newTile.transform.parent = tileParent.transform;

		}
			
	}

}
