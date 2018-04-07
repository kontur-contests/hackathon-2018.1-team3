using Assets.Scripts.Models;
using UnityEngine;

public abstract class MovingObject: MonoBehaviour
{
    protected abstract float ObjectSpeed { get; }

    protected void MoveObject(CurrentMovement currentMovement)
    {
        transform.Translate(currentMovement.XAxisMovement, currentMovement.YAxisMovement, 0);
    }
}