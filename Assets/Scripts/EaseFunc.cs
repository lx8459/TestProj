using UnityEngine;

public enum EaseType
{
    Linear,
    EaseInSine,
    EaseOutSine,
    EaseInOutSine,
    EaseInBack,
    EaseOutBack,
    EaseInOutBack,
}

public delegate float EaseFunction(float time);

public static class EaseFunctions
{
    private const float overshoot = 1.70158f;
    public static float Linear(float t) => t;

    public static float EaseInSine(float t) => -Mathf.Cos(t * (Mathf.PI / 2f)) + 1f;

    public static float EaseOutSine(float t) => Mathf.Sin(t * (Mathf.PI / 2f));

    public static float EaseInOutSine(float t) => -(Mathf.Cos(Mathf.PI * t) - 1f) / 2f;

    public static float EaseInBack(float t) => t * t * ((overshoot + 1) * t - overshoot);

    public static float EaseOutBack(float t) => 1f - EaseInBack(1f - t);

    public static float EaseInOutBack(float t)
    {
        t *= 2;
        if (t < 1) return 0.5f * (t * t * ((overshoot + 1) * t - overshoot));
        return 0.5f * ((t -= 2) * t * ((overshoot + 1) * t + overshoot) + 2);
    }
}