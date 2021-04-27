using UnityEngine;
public class PlayerMovementInfo 
{
    public float forwardAndBackward = 0.0f; // Keyboard Input
    public float leftAndRight       = 0.0f; // Keyboard Input
    public bool  jump               = false; // Keyboard Input

    public float speed = 0.0f; // the speed (i.e., velocity) at which the player is currently moving
    public Vector3 direction = Vector3.zero; // a vector describing the direction the player is currently moving
    public Vector3 normalizedDirection = Vector3.zero; // a normalized vector describing the direction the player is currently moving
    public Vector3 distance = Vector3.zero; // the distance the player should move at this time

    public bool movingForwards = false;
    public bool movingBackwards = false;

    public float baseSpeed; // the base walking speed of the animation
    public float runningAmplifier; // the increase in walking speed of the running animation
}

