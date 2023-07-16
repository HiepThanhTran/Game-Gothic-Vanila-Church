using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimation<T>
{
    void ChangeAnim(T state);
}