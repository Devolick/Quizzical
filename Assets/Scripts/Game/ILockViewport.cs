using UnityEngine;
using System.Collections;
using System;

public interface ILockViewport {
    bool LockViewportTouch { get; }
    void LockByCollider();
}