using UnityEngine;

public class Bomb : PickUpElement<Crate>
{
    protected override void OnHit(GameObject hitObject)
    {
        

        base.OnHit(hitObject);
    }
}