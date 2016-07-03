using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MeshController : MonoBehaviour {
	Mesh mesh;

	void Awake()
	{
		mesh = GetComponent<MeshFilter> ().mesh;
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public IList GetData()
	{
		var vertices = mesh.vertices.OrderBy (e => e.y).ThenBy (e => e.z).ThenBy(e => e.x).ToList ();
		List<float[]> vertexList = new List<float[]> ();
		for(var i = 0; i < vertices.Count; i++){
			vertexList.Add (new float[]{vertices[i].x*this.transform.localScale.x,vertices[i].y*this.transform.localScale.y,vertices[i].z*this.transform.localScale.z});
		}
		return vertexList;

	}
}
