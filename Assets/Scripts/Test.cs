using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform target;
    public Vector3 toPos;
    public float moveTime;
    public Vector3 toScale;
    public float scaleTime;
    public EaseType easeType;

    private TweenBase moveTween;
    private TweenBase scaleTween;
    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 50), "DoMove"))
        {
            moveTween = target.DoMove(toPos, moveTime, () => Debug.Log("MoveComplete"), easeType);
        }
        if (GUI.Button(new Rect(10, 60, 100, 50), "KillMove"))
        {
            moveTween?.Kill();
        }
        if (GUI.Button(new Rect(110, 10, 100, 50), "DoScale"))
        {
            scaleTween = target.DoScale(toScale, scaleTime, () => Debug.Log("ScaleComplete"), easeType);
        }
        if (GUI.Button(new Rect(110, 60, 100, 50), "KillScale"))
        {
            scaleTween?.Kill();
        }
    }
}
