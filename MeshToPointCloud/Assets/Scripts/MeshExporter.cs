using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;
using System;
using System.Text;
using System.IO;

public class MeshExporter : MonoBehaviour {
	[SerializeField]
	MeshController meshController;
	[SerializeField]
	string outDir;
	[SerializeField]
	string outFileName;


	void Awake()
	{
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("e")){
			Export ();
		}
	}

	void Export()
	{
		List<IList> dataList = new List<IList> ();
		Hashtable result = new Hashtable ();
		result.Add ("data",meshController.GetData());
		var resultText = Json.Serialize (result);
		File.WriteAllText (Application.streamingAssetsPath + "/" + outDir + "/" + outFileName,resultText);

	}
}
