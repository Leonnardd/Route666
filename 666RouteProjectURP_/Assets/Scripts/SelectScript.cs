using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectScript : MonoBehaviour
{
    [SerializeField]private Material mat;
    private Transform _selection;
    private Material defMat;
    public GameObject ImgSee;
    public Image img;
    private bool paused=false;
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
                if(Input.GetKeyDown(KeyCode.E)){
                    paused = !paused;
                    if(paused){
                        ImgSee.SetActive(true);
                        img.sprite = selection.GetComponent<Selectable>().img;
                        Time.timeScale = 0f;
                    }
                    else{
                        ImgSee.SetActive(false);
                        Time.timeScale = 1f;
                    }
                }
                var selectionRenderer = selection.GetComponent<Renderer>();
                if(selectionRenderer != null){
                    if(selectionRenderer.material != mat){
                        defMat = selectionRenderer.material;
                    selectionRenderer.material = mat;
                    }   
                }
                _selection = selection;
            }
        }
    }
}
