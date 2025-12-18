using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    
    [SerializeField] private PlayerController playerControllerReference;
    [SerializeField] private Pool poolReference;
    
     private CommandInvoker _commandInvokerRef = new CommandInvoker();
    

    public void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>().normalized;
        if (direction != Vector2.zero && playerControllerReference.canMove)
        {
            _commandInvokerRef.NewCommand(direction, playerControllerReference);
            _commandInvokerRef.EmptyRedo();
        }
    }

    public void OnUndo()
    {
        if (playerControllerReference.canMove)
        {
            _commandInvokerRef.Undo();
        }
    }
    
    public void OnRedo(InputValue value)
    {
        if (playerControllerReference.canMove)
        {
            _commandInvokerRef.Redo();
        }
    }

    public void OnClick(InputValue value)
    {
        if (value.isPressed)
        {
            poolReference.SpawnObject();
        }
    }
}
