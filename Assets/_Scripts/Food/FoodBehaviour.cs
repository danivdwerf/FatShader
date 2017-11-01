using UnityEngine;
using System.Collections;

public class FoodBehaviour : MonoBehaviour
{
    protected string name;
    public string Name{get{return this.name;}}
    protected WeightManager weight;
    private Renderer renderer;

    protected virtual void Start()
    {
        this.name = this.gameObject.name;
        weight = FindObjectOfType<WeightManager>();
        renderer = this.GetComponent<Renderer>();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;
        this.renderer.enabled = false;
        StartCoroutine("resetFood");
    }

    protected IEnumerator resetFood()
    {
        yield return new WaitForSeconds(4.0f);
        this.renderer.enabled = true;
    }
}
