using UnityEngine;

public abstract class MovingObject: MonoBehaviour
{
    protected abstract float ObjectSpeed { get; }

    protected void MoveObject(Rigidbody2D rb, Vector2 movement)
    {
        //transform.Translate(movement);
        rb.MovePosition(rb.position + movement);
    }

    protected float GetMovementMultiplier()
    {
        return ObjectSpeed * Time.deltaTime;
    }
}