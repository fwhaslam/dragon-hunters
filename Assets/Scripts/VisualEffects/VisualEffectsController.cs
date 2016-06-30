using UnityEngine;
using System.Collections;

public class VisualEffectsController : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GameObject blackboard = GameObject.Find("Blackboard");
//		blackboard.GetComponent<Renderer>().material.color = Color.red;

		Texture2D texture = new Texture2D(128, 128);
		blackboard.GetComponent<Renderer>().material.mainTexture = texture;

		long start = System.DateTime.Now.Ticks;
		float[,] heights = MakePlasmaEffect (0.25f);

		float min = 0f;
		float max = 0f;

		for (int y = 0; y < texture.height; y++) {
			for (int x = 0; x < texture.width; x++) {
				
				float height = heights [x, y];   // range is 0f to 0.109f
				if (height < min) min = height;
				if (height > max) max = height;

				// cuttoff at lighter color
				height += 0.25f;
				if (height > 1f) height = 1f;
				if (height < 0.4f) height = 0.4f;

				Color color = new Color (height, height, height);

				texture.SetPixel(x, y, color);
			}
		}
		texture.Apply();

		long end = System.DateTime.Now.Ticks;
		print ("min/max=" + min + "/" + max+"   ticks to complete="+(end-start));
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	float[,] MakePlasmaEffect (float bumpy) {
	
		// map size
		int size = 128;

		float[,] heights = new float[size+1,size+1];

		// bumpyness
		float ceiling = 1f - bumpy;
		float bumpyness = bumpy;


		// prepare with heights in middle, and zero around edge ...
		int step = size / 4;
		for (int y = 0; y <= size; y += step) {

			for (int x = 0; x <= size; x += step) {

				if (x == 0 || y == 0 || x == size || y == size)
					heights [x, y] = 0f;
				else 
					heights[x,y] = Random.Range( 0f, ceiling );
			}
		}

		// scan towards zero
		for ( int step2 = step/2; step > 1; step = step2, step2 /= 2 ) {

			bumpyness *= 0.7f;  // previously halved this value

			for (int y = step; y <= size; y+=step) {
				
				for (int x = step; x <= size; x += step) {

					float A = ( x<=0 || y<=0 ? 0f : heights [x - step, y - step]);
					float B = ( y<=0 ? 0f : heights [x, y - step]);
					float C = ( x<=0 ? 0f : heights [x - step, y]);
					float D = heights [x, y];

					float Middle = (A + B + C + D) / 4 + Random.Range (-bumpyness, bumpyness);
					heights [x - step2, y - step2] = Middle;


					float N = (A + B) / 2 + Random.Range (-bumpyness, bumpyness);
					heights [x - step2, y - step] = N;
					float E = (B + D) / 2 + Random.Range (-bumpyness, bumpyness);
					heights [x, y - step2] = E;
					float S = (C + D) / 2 + Random.Range (-bumpyness, bumpyness);
					heights [x - step2, y] = S;
					float W = (A + C) / 2 + Random.Range (-bumpyness, bumpyness);
					heights [x - step, y - step2] = W;

				}

			}
		}

		return heights;
	}

}
