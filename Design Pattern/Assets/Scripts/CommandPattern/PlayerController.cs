using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveDistance = 1;
    [SerializeField] private float moveSpeed = 5;
    public bool canMove = true;
    
    public void Move(Vector2 direction)
    {
        if (canMove)
        {
            canMove = false;
            transform.DOMove(new Vector3(transform.position.x + direction.x * moveDistance,
                    transform.position.y + direction.y * moveDistance, 0), 1f / moveSpeed).onComplete = () =>
                {
                    canMove = true;
                };

        }
    }
    
}
