using UnityEngine;

public class Circle
{
    public static Vector2 GetPointOnUnitCircle(Vector2 center, float angle)
    {
        angle %= 360;

        var x = Mathf.Cos(angle);
        var y = Mathf.Sin(angle);

        return new Vector2(x, y);
    }
}
