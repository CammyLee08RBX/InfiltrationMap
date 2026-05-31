using UnityEngine;

[ExecuteAlways] // Works in Edit Mode
[RequireComponent(typeof(Renderer))]
public class PerObjectColor : MonoBehaviour
{
    [ColorUsage(true, true)]
    public Color objectColor = Color.white;

    private Renderer rend;

    private void OnValidate()
    {
        ApplyUniqueColor();
    }

    private void Awake()
    {
        ApplyUniqueColor();
    }

    private void ApplyUniqueColor()
    {
        rend = GetComponent<Renderer>();
        if (rend == null) return;

        // If this object is still using the shared material, make a unique copy
        if (rend.sharedMaterial != null && rend.sharedMaterial == rend.sharedMaterials[0])
        {
            rend.material = new Material(rend.sharedMaterial); // Creates a unique instance
        }

        // Now change the color on this object's unique material
        if (rend.material.HasProperty("_Color"))
        {
            rend.material.color = objectColor;
        }
    }
}