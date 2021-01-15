using UnityEngine;
using System.Collections;

public static class TransformExtensions
{
    /// <summary>
    /// 指定のオブジェクトの方向に回転する
    /// </summary>
    /// <param name="self">Self.</param>
    /// <param name="target">Target.</param>
    /// <param name="forward">正面方向</param>
    public static void LookAt2D(this Transform self, Transform target, Vector2 forward)
    {
        LookAt2D(self, target.position, forward);
    }

    public static void LookAt2D(this Transform self, Vector3 target, Vector2 forward)
    {
        var forwardDiff = GetForwardDiffPoint(forward);
        Vector3 direction = target - self.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        self.rotation = Quaternion.AngleAxis(angle - forwardDiff, Vector3.forward);
    }

    /// <summary>
    /// 正面の方向の差分を算出する
    /// </summary>
    /// <returns>The forward diff point.</returns>
    /// <param name="forward">Forward.</param>
    static private float GetForwardDiffPoint(Vector2 forward)
    {
        if (Equals(forward, Vector2.up)) return 90;
        if (Equals(forward, Vector2.right)) return 0;
        return 0;
    }
}