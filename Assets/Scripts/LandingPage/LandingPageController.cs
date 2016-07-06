using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LandingPageController : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//List<string> filenames = FileUtil.GetAllPaths ();
		//foreach ( string filename in filenames ) {
		//	print (" FILENAME = " + filename);
		//}

		FileUtil.visitAssetFiles ((string filepath) => {
			if (filepath.EndsWith(".tsv")) print("FILE="+filepath);
		});

		//print (" FILENAMES = " + filenames);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
