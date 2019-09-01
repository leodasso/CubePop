using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColliderExtension 
{
    public static Vector2 Left(this Bounds bounds)
    {
        return new Vector2(bounds.center.x - bounds.extents.x, bounds.center.y);
    }

    public static Vector2 Right(this Bounds bounds)
    {
        return new Vector2(bounds.center.x + bounds.extents.x, bounds.center.y);
    }

    public static Vector2 Top(this Bounds bounds)
    {
        return new Vector2(bounds.center.x, bounds.center.y + bounds.extents.y);
    }

    public static Vector2 Bottom(this Bounds bounds)
    {
        return new Vector2(bounds.center.x, bounds.center.y - bounds.extents.y);
    }

    public static Vector2 Left(this CapsuleCollider2D collider)
    {
        Vector2 localPoint = new Vector2(-collider.size.x/2, 0);
        return collider.transform.TransformPoint(localPoint);
    }
    
    public static Vector2 Right(this CapsuleCollider2D collider)
    {
        Vector2 localPoint = new Vector2(collider.size.x/2, 0);
        return collider.transform.TransformPoint(localPoint);
    }
    
    public static Vector2 Top(this CapsuleCollider2D collider)
    {
        Vector2 localPoint = new Vector2(0, collider.size.y /2);
        return collider.transform.TransformPoint(localPoint);
    }
    
    public static Vector2 Bottom(this CapsuleCollider2D collider)
    {
        Vector2 localPoint = new Vector2(0, -collider.size.y /2);
        return collider.transform.TransformPoint(localPoint);
    }
}
