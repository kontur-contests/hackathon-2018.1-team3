using UnityEngine;

public abstract class MovingObject: MonoBehaviour
{
    protected abstract float ObjectSpeed { get; }

    protected void MoveObject(Rigidbody2D rb, Vector2 movement)
    {
        rb.MovePosition(rb.position + movement);
    }

    protected float GetMovementMultiplier()
    {
        return ObjectSpeed * Time.deltaTime;
    }
    
    protected Vector3 CalculateNecessaryMovementValues(Vector3 otherMovement)
    {
        var currentPosition = transform.position;
        var multiplier = GetMovementMultiplier();
        return multiplier * (otherMovement - currentPosition);
    }
}