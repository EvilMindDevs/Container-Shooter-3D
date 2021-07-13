using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController : MonoBehaviour
{
    private WinLoseManager _wl;
    public WinLoseManager _Wl
    {
        get { return (_wl == null) ? _wl = FindObjectOfType<WinLoseManager>() : _wl; }
    }

    private int localBoxCount = 0;

    private void OnTriggerStay(Collider other)
    {
        ShootingController box = other.GetComponentInParent<ShootingController>();
        if (box != null)
        {
            localBoxCount++;
        }
        if (localBoxCount == _Wl.targetBoxCount)
        {
            _Wl.boxEvent.Invoke(true);
        }
    }

    private void Update()
    {
        localBoxCount = 0;
    }
}
