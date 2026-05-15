using UnityEngine;

public class PlayerBomb : Shot
{
    [SerializeField] private int bombLimit;


    protected override bool ShotCondition()
    {
        return base.ShotCondition() && Input.GetKey(KeyCode.Mouse1) && bombLimit > 0;
    }


    protected override void DoShot()
    {
        base.DoShot();
        bombLimit--;
    }
}
