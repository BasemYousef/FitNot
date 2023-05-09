using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public interface ICharacterMovement
{
   public void MoveTo(Vector3 location);
   public void HandleInput();
}
