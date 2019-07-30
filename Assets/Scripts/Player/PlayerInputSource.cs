using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputSource : MonoBehaviour , IUnitInputSource
{
    public Vector3 GetInputDirection(UnitMovement p)
    {
        if (!Input.GetMouseButton(0))
            return Vector2.zero;

        Vector3 input = new Vector2();

        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(r, out hit, float.MaxValue, 1 << LayerMask.NameToLayer("PlayerInput"), QueryTriggerInteraction.Collide))
        {
            input = (hit.point - p.transform.position);
            input.y = 0;
            input = input.normalized;
        }

        return input;
    }
}
