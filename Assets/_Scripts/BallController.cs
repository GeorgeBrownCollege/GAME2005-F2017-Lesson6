using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float time;

    private float fps;

    private float upm;

    private float velocityX;
    private float velocityY;
    public float Velocity;
    public float angle;

    private float accelerationY;

    private float ground;

    public float tripTime;

    public float maxHeight;
    public float maxY;

    public float expectedAngle;

    // Use this for initialization
    void Start()
    {
        this.time = 0f;

        this.fps = 50f;

        this.upm = 8f;

        this.Velocity /= upm;
        this.angle *= Mathf.Deg2Rad;

        this.velocityX = this.Velocity * Mathf.Cos(this.angle);
        this.velocityY = this.Velocity * Mathf.Sin(this.angle);

        this.accelerationY = -9.8f / upm;

        this.ground = -12.2f;

        this.calculateTripTime();
        this.calculateMaxHeight();
        this.calculateAngle();

        this.maxY = this.ground;
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        if (transform.position.y > ground) {
            time += Time.fixedDeltaTime;

            positionY();
            positionX();

            if (maxY < transform.position.y) {
                maxY = transform.position.y;
            }
        } else {
            transform.position = new Vector3(transform.position.x, ground, 0f);
            //time = 0f;
        }


    }


    void positionY() {
        var currentPosY = transform.position.y;
        var currentPosX = transform.position.x;
        var newPositionY = currentPosY +
            (this.velocityY * time) + 
            ((0.5f) * this.accelerationY * Mathf.Pow(time, 2));

        transform.position = new Vector3(currentPosX, newPositionY, 0f);
    }

    void positionX() {
        var currentPosY = transform.position.y;
        var currentPosX = transform.position.x;
        var newPositionX = currentPosX +
            (this.velocityX * time);

        transform.position = new Vector3(newPositionX, currentPosY, 0f);
    }

    void calculateTripTime() {
        this.tripTime = 2f *
            Velocity * Mathf.Sin(this.angle) / Mathf.Abs(this.accelerationY) * 1.5f;
    }

    void calculateMaxHeight() {
        this.maxHeight = Mathf.Pow(Velocity, 2) *
            Mathf.Pow(Mathf.Sin(angle), 2) / 
            ((2.0f) * Mathf.Abs(this.accelerationY));
    }

    void calculateAngle() {
        this.expectedAngle = Mathf.Atan2(this.velocityY, this.velocityX) *
            Mathf.Rad2Deg;
    }

   

}