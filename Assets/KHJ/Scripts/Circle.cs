using UnityEngine;

public class Circle
{
    public static Vector2 GetPointOnUnitCircle(Vector2 center, float angle)
    {
        angle %= 360f;

        var x = Mathf.Cos(angle * Mathf.Deg2Rad);
        var y = Mathf.Sin(angle * Mathf.Deg2Rad);

        return new Vector2(center.x + x, center.y + y);
    }
}
