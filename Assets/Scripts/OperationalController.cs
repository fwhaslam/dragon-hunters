using UnityEngine;
using System.Collections;

public class OperationalController : MonoBehaviour {

	public GameObject textParent;

	// Use this for initialization
	void Start () {
	
		GameObject plane = makeBackground();
		makeOneMesh (plane);
	
		GameObject text = TextUtil.makeText3D ("somekey","Some <b>Bold</b> Words", 12.5f, 12.5f);
		TextUtil.addToScene (text, textParent);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	GameObject makeBackground(){
		GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
		plane.transform.parent = transform;

		return plane;
	}

	void makeOneMesh(GameObject plane){

		//GameObject plane = new GameObject ();

		// points in mesh
		Vector3[] newVertices = {
			new Vector3(0,0,0),new Vector3(25,0,0),new Vector3(0,25,0),new Vector3(25,25,0),
		};
		// index into points, 3 at a time
		int[] newTriangles = {  0,2,1,  1,2,3  };
		// per point, float ratio of location in texture
		Vector2[] newUV = {
			new Vector2(0,0), new Vector2(1,0), new Vector2(0,1), new Vector2(1,1)
		};

		Mesh mesh = new Mesh();
		mesh.vertices = newVertices;
		mesh.uv = newUV;
		mesh.triangles = newTriangles;

		plane.GetComponent<MeshFilter>().mesh = mesh;
		//plane.transform.parent = transform;


	}


	void makeText(string words, float x, float y ){ 

		float resize = 3f;
		Vector3 scale = new Vector3 (resize, resize, resize);

		//GameObject newText = (GameObject)Instantiate(textPrefab, new Vector3(x,y,+10),  Quaternion.identity );
		GameObject text = new GameObject();
		text.transform.position = new Vector3 (x, y, +10);
		text.transform.rotation = Quaternion.identity;
		text.transform.localScale = scale;

		TextMesh mesh = text.AddComponent<TextMesh> ();
		mesh.fontSize = 12;
		mesh.text = words;
		mesh.color = Color.red; // Set the text's color to red
		mesh.richText = true;
		mesh.font =  Resources.Load<Font>("Arial");
		mesh.alignment = TextAlignment.Center;
		mesh.anchor = TextAnchor.MiddleCenter;

		// put into hierarchy
		text.transform.parent = textParent.transform;

	}

}
