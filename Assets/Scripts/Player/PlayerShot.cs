using UnityEngine;

public class PlayerShot : Shot
{

    protected override bool ShotCondition()
    {
        return base.ShotCondition() && Input.GetKey(KeyCode.Mouse0);
    }



}
