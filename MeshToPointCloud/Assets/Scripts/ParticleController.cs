using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticleController : MonoBehaviour {
	ParticleSystem ps;

	[SerializeField]
	float pointSize;
	[SerializeField]
	Color color;

	[SerializeField]
	MeshFilter targetMesh;

	void Awake ()
	{
		
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("p")){
			ps = GetComponent<ParticleSystem> ();
			ps.Stop ();
			var points = targetMesh.mesh.vertices;
			List<ParticleSystem.Particle> particles = new List<ParticleSystem.Particle> ();
			for(var i = 0; i < points.Length; i++){
				var particle = new ParticleSystem.Particle ();
				particle.size = pointSize;
				particle.position = points [i];
				particle.color = color;
				particles.Add (particle);
			}
			ps.SetParticles (particles.ToArray(),particles.Count);
		}

	}
}
