using System;
using UnityEngine;

public class ScaleTween : TweenBase
{
    private Vector3 _startScale;
    private Vector3 _endScale;

    public ScaleTween(Transform target, Vector3 to, float duration, Action onComplete = null, EaseType easeType = EaseType.Linear)
        : base(target, duration, onComplete, easeType)
    {
        _startScale = target.localScale;
        _endScale = to;
    }

    protected override void OnUpdate(float timeRatio)
    {
        target.localScale = Vector3.Lerp(_startScale, _endScale, timeRatio);
    }
}
