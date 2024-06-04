using System;
using UnityEngine;

public abstract class TweenBase
{
    public Action onComplete; // 完成回调
    public float duration; // 持续时间
    public float elapsedTime; // 已消耗时间
    public bool isPlaying; // 是否正在播放
    public EaseFunction easeFunction; // 缓动函数
    protected Transform target; // 目标变换对象

    public TweenBase(Transform target, float duration, Action onComplete = null, EaseType easeType = EaseType.Linear)
    {
        elapsedTime = 0f;
        isPlaying = false;
        this.target = target;
        this.duration = duration;
        this.onComplete = onComplete;

        switch (easeType)
        {
            case EaseType.Linear:
                easeFunction = EaseFunctions.Linear;
                break;
            case EaseType.EaseInSine:
                easeFunction = EaseFunctions.EaseInSine;
                break;
            case EaseType.EaseOutSine:
                easeFunction = EaseFunctions.EaseOutSine;
                break;
            case EaseType.EaseInOutSine:
                easeFunction = EaseFunctions.EaseInOutSine;
                break;
            case EaseType.EaseInBack:
                easeFunction = EaseFunctions.EaseInBack;
                break;
            case EaseType.EaseOutBack:
                easeFunction = EaseFunctions.EaseOutBack;
                break;
            case EaseType.EaseInOutBack:
                easeFunction = EaseFunctions.EaseInOutBack;
                break;
            default:
                break;
        }
    }

    public virtual void Update(float deltaTime)
    {
        if (!isPlaying)
        {
            TweenManager.Instance.UnregisterTween(this);
            return;
        }

        elapsedTime += deltaTime;
        float t = Mathf.Clamp01(elapsedTime / duration);

        // 应用缓动效果
        t = easeFunction(t);

        OnUpdate(t);

        if (elapsedTime >= duration)
        {
            onComplete?.Invoke();
            Kill();
        }
    }

    protected abstract void OnUpdate(float timeRatio);

    public void Play()
    {
        isPlaying = true;
    }

    public void Kill()
    {
        isPlaying = false;
    }
}
