using UnityEngine;

public class HealthyFood : FoodBehaviour 
{
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        weight.setWeight(-0.01f, true);
    }
}
