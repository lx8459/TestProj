using System;
using System.Collections.Generic;
using UnityEngine;

public class TweenManager : MonoBehaviour
{
    private static TweenManager _instance;
    public static TweenManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<TweenManager>();
                if (_instance == null)
                {
                    GameObject obj = new(typeof(TweenManager).Name);
                    _instance = obj.AddComponent<TweenManager>();
                }
            }
            return _instance;
        }
    }

    private List<TweenBase> activeTweens = new List<TweenBase>();

    private void Update()
    {
        for (int i = 0; i < activeTweens.Count; i++)
        {
            if (!activeTweens[i].isPlaying)
            {
                // 如果Tween已经停止（自然结束或被Kill），从列表中移除
                activeTweens.RemoveAt(i);
                i--; // 移除后索引需要回退一位，以免跳过下一个元素
            }
            else
            {
                // 继续更新Tween
                activeTweens[i].Update(Time.deltaTime);
            }
        }
    }

    public void RegisterTween(TweenBase tween)
    {
        if (!activeTweens.Contains(tween))
        {
            activeTweens.Add(tween);
        }
    }

    public void UnregisterTween(TweenBase tween)
    {
        if (activeTweens.Contains(tween))
        {
            tween.Kill(); // 确保Tween被Kill
            activeTweens.Remove(tween);
        }
    }
}

public static class TweenExtensions
{
    public static MoveTween DoMove(this Transform target, Vector3 to, float duration, Action onComplete = null, EaseType easeType = EaseType.Linear)
    {
        var tween = new MoveTween(target, to, duration, onComplete, easeType);
        TweenManager.Instance.RegisterTween(tween);
        tween.Play();
        return tween;
    }
    public static ScaleTween DoScale(this Transform target, Vector3 to, float duration, Action onComplete = null, EaseType easeType = EaseType.Linear)
    {
        var tween = new ScaleTween(target, to, duration, onComplete, easeType);
        TweenManager.Instance.RegisterTween(tween);
        tween.Play();
        return tween;
    }
}
