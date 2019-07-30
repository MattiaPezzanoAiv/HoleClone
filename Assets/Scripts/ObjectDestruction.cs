using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestruction : MonoBehaviour
{
    public System.Action<Building> onBuildingEaten;


    private void OnTriggerExit(Collider other)
    {
        var building = other.GetComponent<Building>();
        if(building != null)
        {
            //call global event
            onBuildingEaten.Invoke(building);

            Destroy(building.gameObject);
        }
    }

}
