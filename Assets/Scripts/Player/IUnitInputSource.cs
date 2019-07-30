using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitInputSource 
{

    Vector3 GetInputDirection(UnitMovement unit);
}
