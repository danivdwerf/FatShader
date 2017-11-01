using UnityEngine;

using System.Collections.Generic;

public class WeightManager : MonoBehaviour 
{
    private List<Material> materials;
    private int extrusionID;
	void Start () 
    {
        materials = new List<Material>();
        extrusionID = Shader.PropertyToID("_Amount");

        var childrenderers = this.GetComponentsInChildren<SkinnedMeshRenderer>();
        for (var i = 0; i < childrenderers.Length; i++)
        {
            var childMaterials = childrenderers[i].materials;
            for (var j = 0; j < childMaterials.Length; j++)
                materials.Add(childMaterials[j]);
        }

        this.setWeight(0, false);
	}

    public void setWeight(float value, bool add)
    {
        var original = materials[0].GetFloat(extrusionID);
        if (original + value < 0)
            return;
        
        if (add)
            value += original;

        for (var i = 0; i < materials.Count; i++)
            materials[i].SetFloat(extrusionID, value);
    }
}
