using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{
    public Transform sunTransform;
    public Button dayButton, nightButton;
    private List<Material> emissiveMaterials = new List<Material>();

    void Start()
    {
        dayButton.onClick.AddListener(delegate { SetDaytime(); });
        nightButton.onClick.AddListener(delegate { SetNightime(); });

        var tempLODGroup = FindObjectsOfType<LODGroup>();

        foreach (var lodGroup in tempLODGroup)
        {
            foreach(MeshRenderer renderer in lodGroup.gameObject.GetComponentsInChildren<Renderer>())
            {
                foreach (Material mat in renderer.materials)
                {
                    if (mat.HasProperty("_emissionMultiplier"))
                    {
                        emissiveMaterials.Add(mat);
                    }
                }
            }          
        }
    }

    private void SetDaytime()
    {
        sunTransform.localRotation = Quaternion.Euler(0, 0, 127);
        foreach (var mat in emissiveMaterials)
        {
            mat.SetFloat("_emissionMultiplier", 0);
        }
    }

    private void SetNightime()
    {
        sunTransform.localRotation = Quaternion.Euler(0, 0, 185);
        foreach (var mat in emissiveMaterials)
        {
            mat.SetFloat("_emissionMultiplier", 10000);
        }
    }
}
