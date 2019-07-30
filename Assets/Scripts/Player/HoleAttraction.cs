using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleAttraction : MonoBehaviour
{
    [SerializeField]
    float force;
    [SerializeField]
    Transform gravityCenter;
    [SerializeField]
    Player player;

    //private void FixedUpdate()
    //{
    //    var cols = Physics.OverlapSphere(transform.position, 1f);

    //    foreach (var c in cols)
    //    {
    //        var rb = c.GetComponent<Rigidbody>();
    //        if (rb == null)
    //            continue;

    //        Vector3 dir = (rb.position - transform.position).normalized;
    //        rb.AddForce(dir * force, ForceMode.Acceleration);
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        var building = other.GetComponent<Building>();
        if (building == null)
            return;
        if (!building.CanBeEatenBy(player))
            return;

        var rb = other.GetComponent<Rigidbody>();
        Vector3 dir = (rb.position - gravityCenter.position).normalized;
        rb.AddForce(dir * force, ForceMode.Acceleration);
        other.transform.localScale -= Vector3.one * Time.deltaTime * 0.5f;
    }

}
