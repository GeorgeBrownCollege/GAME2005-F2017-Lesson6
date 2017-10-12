using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public float acceleration = -4.9f;
    public float velocity = 2.0f;
    public float time = 0.0f;
    public float ground = -2.471f;
    private float totalTime = 0f;
    private float upm = 1f;
    private float spf = 60f;
    public float angle = 45;

	// Use this for initialization
	void Start () {
        // scaling the distance by units per meter
        acceleration /= upm;
        velocity /= upm;
	}

	
	// Update is called once per frame
	void FixedUpdate () {

        if (transform.position.y > ground) {
            
        
        time += Time.fixedDeltaTime;
        float distanceY = transform.position.y + 
                                   this.velocity * 
                                   Mathf.Sin(Mathf.Deg2Rad * angle) * 
                                   time /spf + (acceleration * (time * time) / spf);


        float distanceX = transform.position.x + 
                                   this.velocity * 
                                   Mathf.Cos(Mathf.Deg2Rad * angle) * time / spf;
                                       

        transform.position = new Vector3(distanceX, distanceY, 0f);
        }
        else {
            transform.position = new Vector3(transform.position.x, ground, 0f);
        }

     }


	}

