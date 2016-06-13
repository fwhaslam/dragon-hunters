using UnityEngine;
using NUnit.Framework;

public class JsonUtilTest {

	[Test]
	[Category("Failing Tests")]
	public void Read(){

		string result = new JsonUtil ().Read ("Assets/Editor/utils/SampleReadFile.txt");

		Assert.AreEqual ("Hello There", result);

	}

	[Test]
	[Category("Failing Tests")]
	public void ReadJson(){

		string body = new JsonUtil ().Read ("Assets/Editor/utils/SampleJsonFile.json");
		JSONObject result = new JsonUtil ().ReadJson("Assets/Editor/utils/SampleJsonFile.json");

		Assert.AreEqual ( body, 
			result.ToString(true));

	}
}
