using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectScript : MonoBehaviour
{
    [SerializeField]private Material mat;
    private Transform _selection;
    private Material defMat;
    void Update()
    {
        if(_selection != null){
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defMat;
            _selection = null;
        }
        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2f, Screen.height/2f, 0f));
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit)){
            var selection = hit.transform;
        
            if(selection.CompareTag("Selectable")){
                var selectionRenderer = selection.GetComponent<Renderer>();
                if(selectionRenderer != null){
                    defMat = selectionRenderer.material;
                    selectionRenderer.material = mat;
                }
                _selection = selection;
            }
        }
    }
}
