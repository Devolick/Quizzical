using UnityEngine;
using System.Collections;
using System;

public abstract class Base : MonoBehaviour
{
    protected bool FillLayer {
        private get;
        set;
    }

    // Use this for initialization
    void Awake()
    {
        FillLayer = true;
        _Awake();
    }

    void Start()
    {
        FillRayLayer();
        _Start();
    }

    void FixedUpdate() {
        _FixedUpdate();
    }

    void Update() {
        _Update();
    }

    protected virtual void _Awake() { }

    protected virtual void _Start() { }

    protected virtual void _FixedUpdate() { }

    protected virtual void _Update() { }

    /// <summary>
    /// filter layers by sorting layers for ray cast
    /// warning: layer depth by int bit 32 slots
    /// </summary>
    void FillRayLayer()
    {
        if (FillLayer)
        {
            if (this.transform.parent == null)
            {
                Vector3 posLayer = transform.position;
                posLayer.z = Mathf.Abs(this.gameObject.layer - 32);
                transform.position = posLayer;
            }
            else
            {
                Vector3 posLayer = transform.localPosition;
                posLayer.z = -0.1f;
                transform.localPosition = posLayer;
            }
        }
    }

}
