using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerColorController : MonoBehaviour
{
    private MeshRenderer _mr;
    public MeshRenderer _Mr
    {
        get { return (_mr == null) ? _mr = GetComponentInChildren<MeshRenderer>() : _mr; }
    }

    private Color color;
    MaterialPropertyBlock propertyBlock;

    // Start is called before the first frame update
    void Start()
    {
        propertyBlock = new MaterialPropertyBlock();
        HMSAnalyticsManager.Instance.SendEventWithBundle("GameStart", "isGameStart", "GameStarted");
    }

    // Update is called once per frame
    void Update()
    {
        color = Color.Lerp(Color.white, Color.red, (InputManager.Instance.forceMultiplier-1)/2);
        propertyBlock.SetColor("_Color", color);
        _Mr.SetPropertyBlock(propertyBlock);
    }
}
