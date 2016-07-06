using UnityEngine;
using NUnit.Framework;

public class JsonUtilTest {

	[Test]
	[Category("Failing Tests")]
	public void Read(){

		string result = JsonUtil.Read ("Assets/Editor/Tools/SampleReadFile.txt");

		Assert.AreEqual ("Hello There", result);

	}

	[Test]
	[Category("Failing Tests")]
	public void ReadJson(){

		string body = JsonUtil.Read ("Assets/Editor/Tools/SampleJsonFile.json");
		JSONObject result = JsonUtil.ReadJson("Assets/Editor/Tools/SampleJsonFile.json");

		Assert.AreEqual ( body, 
			result.ToString(true));

	}
}
