using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TacticalControl : MonoBehaviour {

    public TileType[] tileTypeList;

	public GameObject tileParent;

	public GameObject textParent;

	// Use this for initialization
	void Start () {

		fixTileTypes ();
		buildSimpleMap ();
		createVisualMap ( TacticalShared.map );

		GameObject text = TextUtil.makeText3D ("somekey","Some <b>Bold</b> Words", 0f, 0f);
		TextUtil.addToScene (text, textParent);

	}

	/**
	 * Inject tile types into shared space.
	 */
	void fixTileTypes(){
		foreach (TileType tileType in tileTypeList)
			TacticalShared.tileTypes.add (tileType);
	}

	void buildSimpleMap(){
		SimpleMap.make (TacticalShared.map, TacticalShared.tileTypes);
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
