using DG.Tweening;
using UnityEngine;

public class Npc : MonoBehaviour
{
    [SerializeField] private Vector3 movePos;
    [SerializeField] private float moveDuration = 1f;
    private void Awake()
    {
        EventManager.onCatch += Move;
    }

    private void Move()
    {
        transform.DOMove(movePos, moveDuration);
    }
}
