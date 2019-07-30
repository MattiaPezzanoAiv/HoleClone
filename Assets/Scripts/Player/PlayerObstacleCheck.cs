using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObstacleCheck : MonoBehaviour
{
    //this should check level of player and level of building
    [SerializeField]
    private Player myPlayer;

    private void OnTriggerEnter(Collider other)
    {
        var go = other.gameObject;
        var building = other.GetComponent<Building>();
        if (go.layer == LayerMask.NameToLayer("Standing") && building != null && building.CanBeEatenBy(myPlayer))
        {
            go.layer = LayerMask.NameToLayer("Falling");

            //building.GetComponent<Collider>().enabled = false;

            if (building.Owner == null)
                building.Owner = myPlayer;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var go = other.gameObject;
        var building = other.GetComponent<Building>();
        if (go.layer == LayerMask.NameToLayer("Falling") && building != null && building.CanBeEatenBy(myPlayer))
        {
            go.layer = LayerMask.NameToLayer("Standing");

            //if (building.Owner == myPlayer)
            //{
            //    building.Owner = null;
            //}
        }
    }
}
