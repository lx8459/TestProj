using System;
using UnityEngine;

public class MoveTween : TweenBase
{
    private Vector3 _startPos;
    private Vector3 _endPos;

    public MoveTween(Transform target, Vector3 to, float duration, Action onComplete = null, EaseType easeType = EaseType.Linear)
        : base(target, duration, onComplete, easeType)
    {
        _startPos = target.position;
        _endPos = to;
    }

    protected override void OnUpdate(float timeRatio)
    {
        target.position = Vector3.LerpUnclamped(_startPos, _endPos, timeRatio); 
    }
}
