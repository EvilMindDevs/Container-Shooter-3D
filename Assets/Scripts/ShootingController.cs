using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{

    public float shootingForce = 150;
    private Rigidbody _rb;
    public Rigidbody _Rb
    {
        get { return (_rb == null) ? _rb = GetComponent<Rigidbody>() : _rb; }
    }

    private void OnEnable()
    {
        InputManager.Instance.onReleased.AddListener(Move);
    }

    private void OnDisable()
    {
        InputManager.Instance.onReleased.RemoveListener(Move);
    }

    private void Move(Vector2 direction, float forceMultiplier)
    {
        Debug.Log("FM" + forceMultiplier);
        if (_Rb.velocity.magnitude > Vector3.zero.magnitude) return;
        _Rb.AddForce(new Vector3(direction.x * shootingForce, 200, direction.y * shootingForce) * forceMultiplier);
    }
}
