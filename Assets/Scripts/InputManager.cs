using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : Singleton<InputManager>
{

    private Vector2 startPosition;
    private Vector2 finishPosition;
    private Vector2 ShootingVector;
    public float forceMultiplier;

    public ReleaseEvent onReleased = new ReleaseEvent();

    private void Start()
    {
        forceMultiplier = 1;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            forceMultiplier += .01f;
            forceMultiplier = Mathf.Clamp(forceMultiplier, 1, 3);
        }
        if (Input.GetMouseButtonDown(0))
        {
            
            startPosition = Vector2.zero;
            finishPosition = Vector2.zero;
            startPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            finishPosition = Input.mousePosition;
            CalculateShootingVector();
        }
    }

    private void CalculateShootingVector()
    {
        ShootingVector = (startPosition - finishPosition).normalized;
        onReleased.Invoke(ShootingVector, forceMultiplier);
        forceMultiplier = 1;
    }
}


public class ReleaseEvent : UnityEvent<Vector2, float>
{

}