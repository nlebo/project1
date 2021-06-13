using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEMove : MonoBehaviour
{
    protected float speed;
    protected Vector3 Dic;

    public virtual void Move() { }
    public virtual void Stop() { }
    public virtual void Jump() { }
    public virtual void SetSpeed(float _speed) { }

    public virtual void SetObject(object obj) { }

    public virtual bool IsMove() { return false; }
    public virtual void SetAnim() { }
}
