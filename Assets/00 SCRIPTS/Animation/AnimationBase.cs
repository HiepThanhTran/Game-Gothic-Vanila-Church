using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimationBase<T> : MonoBehaviour, IAnimation<T>
{
    public abstract void ChangeAnim(T state);
}

