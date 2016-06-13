using UnityEngine;
using System.Collections;
using NUnit.Framework;

public class TacticalMapTest : MonoBehaviour {

	[Test]
	[Category("Failing Tests")]
	public void constructor(){
		TacticalMap map = new TacticalMap ();

		Assert.AreEqual (map.width, 0);
		Assert.AreEqual (map.height, 0);
		Assert.AreEqual (map.tiles.Count, 0);

		Assert.AreEqual (map.grid.GetLength(0), 0);
		Assert.AreEqual (map.grid.GetLength(1), 0);

	}

	[Test]
	[Category("Failing Tests")]
	public void prepare(){
		TacticalMap map = new TacticalMap ().prepare (10, 12);

		Assert.AreEqual (map.width, 10);
		Assert.AreEqual (map.height, 12);
		Assert.AreEqual (map.tiles.Count, 0);

		Assert.AreEqual (map.grid.GetLength(0), 10);
		Assert.AreEqual (map.grid.GetLength(1), 12);

		Assert.AreEqual (map.visualWidth(), 340f);
		Assert.AreEqual (map.visualHeight(), 360f);
		Assert.AreEqual (map.visualXOffset(), 170f);
		Assert.AreEqual (map.visualYOffset(), 180f);

	}

	[Test]
	[Category("Failing Tests")]
	public void makeTile_getTile_getTiles(){
		
		TacticalMap map = new TacticalMap ().prepare (4, 4);
		TileType someTileType = new TileType ();

		// invocation
		Tile tile = map.makeTile (2, 3, someTileType );

		// assertions
		Assert.AreEqual (tile.logicalX, 2);
		Assert.AreEqual (tile.logicalY, 3);
		Assert.AreSame (tile.getType (), someTileType);

		Assert.AreEqual (map.getTiles ().Count, 1);

		Tile test = map.getTiles () [0];
		Assert.AreSame (test, tile);

		Assert.AreEqual (map.getTile (0, 0), null);
		Assert.AreSame (map.getTile (2, 3), tile);

	}

	[Test]
	[Category("Failing Tests")]
	public void getTileSafe(){
		Assert.Fail ("write me");
	}

}
