using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInputSource : MonoBehaviour, IUnitInputSource
{
    public Vector3 GetInputDirection(UnitMovement unit)
    {
        if (currentTarget != null)
        {
            var dir = (currentTarget.transform.position - transform.position).normalized;
            dir.y = 0;
            return dir;
            //transform.position += dir * movement.GetSpeed() * Time.deltaTime;
        }
        return Vector3.zero;
    }

    private Transform currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SearchTarget());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SearchTarget()
    {
        while(true)
        {
            if (currentTarget != null)
            {
                yield return null;
                continue;
            }
            else
            {
                //search near
                var cols = Physics.OverlapSphere(transform.position, 30f);
                float dist = float.MaxValue;
                for (int i = 0; i < cols.Length; i++)
                {
                    var building = cols[i].GetComponent<Building>();
                    if (building == null || !building.CanBeEatenBy(this.GetComponent<Player>()))
                        continue;

                    float d = Vector3.Distance(cols[i].transform.position, transform.position);
                    if (d < dist)
                    {
                        dist = d;
                        currentTarget = building.transform;
                    }
                }
                if (currentTarget != null)
                {
                    yield return null;
                    continue;
                }

                //search other player
                dist = float.MaxValue;
                var players = GameManager.Instance.GetPlayerList(this.GetComponent<Player>());
                for (int i = 0; i < players.Count; i++)
                {
                    float d = Vector3.Distance(players[i].transform.position, transform.position);
                    if (d < dist)
                    {
                        dist = d;
                        currentTarget = players[i].transform;
                    }
                }
                yield return null;
            }
        }
    }
}
