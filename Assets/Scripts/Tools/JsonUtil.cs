using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;  
using System;  

public class JsonUtil {

	static public void Dump(string msg,Exception ex){
		Console.WriteLine(msg + ":::"+ ex.Message);
	}

	static public JSONObject ReadJson(string filename){
		return JSONObject.Create (Read (filename));
	}

	static public string Read(string filename) {

		string result = null;
		
		// Handle any problems that might arise when reading the text
		try {

			StreamReader theReader = new StreamReader(filename, Encoding.Default);
			using (theReader) {

				while (true) {
					string line = theReader.ReadLine();
					if (line==null) break;
					result = ( result==null ? "" : result + "\n" );
					result += line;
				}
				// Done reading, close the reader and return true to broadcast success    
				theReader.Close();
			}
		}
		// If anything broke in the try block, we throw an exception with information
		// on what didn't work
		catch (Exception e) {
			Dump ("failed to load file", e);
		}
		return result;
	}

}