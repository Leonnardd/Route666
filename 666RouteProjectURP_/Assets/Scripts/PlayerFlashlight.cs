using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashlight : MonoBehaviour
{
    public GameObject lightObj;
    public Animator batAnim;

    public float secondsDurability;
    private float secondsLeft;
    public bool isFlash = false;
    public bool canFlash;
    private float percentage;
    void Start()
    {
        secondsLeft = secondsDurability;
        percentage = 100;
    }

    // Update is called once per frame
    void Update(){   
        //batAnim.gameObject.SetActive(canFlash);
        if(canFlash){
            if(Input.GetKeyDown(KeyCode.F)){
                isFlash = !isFlash;
            }
        }
        else{
            if(secondsLeft < secondsDurability){
                secondsLeft+= Time.deltaTime/5;
            }
        }
        lightObj.SetActive(isFlash);
        if(isFlash){
            if(secondsLeft > 0){
                secondsLeft-= Time.deltaTime;
            }
        }
        percentage = Mathf.Round((secondsLeft/secondsDurability)*100);
        print(percentage);
        batAnim.SetFloat("Percentage",percentage);
    }
}
