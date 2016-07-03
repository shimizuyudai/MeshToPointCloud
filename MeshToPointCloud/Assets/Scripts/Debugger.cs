using UnityEngine;
using System.Collections;
using MiniJSON;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;

public class Debugger : MonoBehaviour
{
	ParticleSystem ps;
	[SerializeField]
	string inDir;
	[SerializeField]
	string fileName;

	[SerializeField]
	int loadDataNUM;
	[SerializeField]
	float pointSize;
	[SerializeField]
	Color baseColor;
	[SerializeField]
	Color color;
	List<ParticleSystem.Particle> particles;
	int cnt;



	void Awake ()
	{
		ps = GetComponent<ParticleSystem> ();
		ps.Stop ();
		var points = GetPoints ();
		particles = new List<ParticleSystem.Particle> ();
		for(var i = 0; i < points.Count; i++){
			var particle = new ParticleSystem.Particle ();
			particle.startSize = pointSize;
			particle.position = points [i];
			particle.startColor = baseColor;
			particles.Add (particle);
		}
		ps.SetParticles (particles.ToArray(),particles.Count);
	}

	public List<Vector3> GetPoints ()
	{
		List<Vector3> result = new List<Vector3> ();
		var path = Application.streamingAssetsPath + "/" + inDir + "/" + fileName;
		if (File.Exists (path)) {
			var text = File.ReadAllText (path);
			var json = (IDictionary)Json.Deserialize (text);
			var data = (IList)json ["data"];
			if (data != null) {
				for (var i = 0; i < data.Count; i++) {
					print (data[i]);
					var pointdata = (IList)data[i];
					var x = float.Parse (pointdata [0].ToString ());
					var y = float.Parse (pointdata [1].ToString ());
					var z = float.Parse (pointdata [2].ToString ());
					Vector3 point = new Vector3 (x,y,z);
					result.Add (point);
				}
			}
		}
		return result;
	}

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		List<ParticleSystem.Particle> tempParticles = new List<ParticleSystem.Particle> ();
		for(var i = 0; i < particles.Count; i++){
			var particle = new ParticleSystem.Particle ();
			particle.startSize = pointSize;
			particle.position = particles [i].position;
			if (i > cnt) {
				particle.startColor = baseColor;
			} else {
				particle.startColor = color;
			}
			tempParticles.Add (particle);
		}
		ps.SetParticles (tempParticles.ToArray(),particles.Count);

		if(Input.GetKey("a")){
			cnt++;
			cnt = Mathf.Min(cnt,particles.Count);
		}
	}
}
