using UnityEngine;
using System.Collections;

public class TextUtil {

	static public GameObject makeText3D(string key, string words, float x, float y ){ 

		GameObject text = new GameObject (key);
		text.transform.position = new Vector3 (x, y, +10);
		text.transform.rotation = Quaternion.identity;
		text.transform.localScale = new Vector3 (3f, 3f, 3f);

		TextMesh mesh = text.AddComponent<TextMesh> ();
		mesh.fontSize = 12;
		mesh.text = words;
		mesh.color = Color.red; // Set the text's color to red
		mesh.richText = true;
		mesh.font = Resources.Load<Font> ("Arial");
		mesh.alignment = TextAlignment.Center;
		mesh.anchor = TextAnchor.MiddleCenter;

		return text;

	}

	static public void addToScene( GameObject text, GameObject textParent ) {

		// push into hierarchy
		text.transform.parent = textParent.transform;

	}

}
