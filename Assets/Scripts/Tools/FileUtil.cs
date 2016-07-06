using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;  
using System;  


public class FileUtil {

	/*static public T[] GetAtPath<T> (string path) {

		ArrayList al = new ArrayList();
		string [] fileEntries = Directory.GetFiles(Application.dataPath+"/"+path);
		foreach(string fileName in fileEntries)
		{
			int index = fileName.LastIndexOf("/");
			string localPath = "Assets/" + path;

			if (index > 0)
				localPath += fileName.Substring(index);

			Object t = Resources.LoadAssetAtPath(localPath, typeof(T));

			if(t != null)
				al.Add(t);
		}
		T[] result = new T[al.Count];
		for(int i=0;i<al.Count;i++)
			result[i] = (T)al[i];

		return result;
	}*/

	/**
	* 
	*/
	static void visitFilesUnder ( string path, Action<String> action ) {

		action ("================= @ "+path);
		foreach(string filename in Directory.GetFiles( path )) {
			action (filename);
		}

		foreach (string dirname in Directory.GetDirectories(path)) {
			visitFilesUnder (dirname,action);
		}

	}

	/**
	 * 
	 */
	static public void visitAssetFiles ( Action<String> action ) {
		visitFilesUnder (Application.dataPath, action);
	}

	/**
	 * 
	 */
	static public List<String> GetAllPaths () {
		List<String> result = new List<String>();
		visitFilesUnder ( Application.dataPath,
			( filepath ) => result.Add( filepath )
		);
		return result;
	}
		
}
