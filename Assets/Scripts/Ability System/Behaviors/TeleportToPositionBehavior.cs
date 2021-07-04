using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToPositionBehavior : AbilityBehaviors
{
    new public const string name = " Teleport to Position";
    new public const string description = "Teleport yourself to point in area";

    private Vector3 positionTeleport;
    private float rangeTeleport;


    public TeleportToPositionBehavior(Vector3 positionToTeleport, float rangeTeleport) : base(name, description)
    {
        this.positionTeleport = positionToTeleport;
        this.rangeTeleport = rangeTeleport;
    }


    public override void PerformBehaviors(GameObject self, GameObject target)
    {
        self.transform.position = GetRandomPosition(positionTeleport, rangeTeleport);
        self.GetComponent<Ball>().TemporarilyDontMove();
    }

    private Vector3 GetRandomPosition(Vector3 position, float range)
    {
        return position + new Vector3(Random.Range(-range, range), 0, Random.Range(-range, range));
    }
}
