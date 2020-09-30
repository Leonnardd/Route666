using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveEnterCar : MonoBehaviour
{
    public CarController carController;
    public PlayerMovement playerMovement;

    public BoxCollider enterTrigger;
    public bool outsideCar;
    private bool inTrigger;

    public Transform InsideCarTransform;
    public Transform OutsideCarSpawner;
    private CharacterController charControl;
    private PlayerFlashlight playerFlash;

    public GameObject triggerTxt;

    // Start is called before the first frame update
    void Start()
    {
        playerFlash = GetComponent<PlayerFlashlight>();
        charControl = GetComponent<CharacterController>();
        if(!outsideCar){
            GetComponent<Transform>().SetParent(InsideCarTransform);
            GetComponent<Transform>().localPosition = new Vector3(0,0,0);
            playerMovement.enabled = false;
            charControl.enabled = false;
            playerFlash.isFlash = false;
            playerFlash.canFlash = false;
        }
         else{
            carController.CanDrive = false;
            charControl.enabled = true;
            playerFlash.canFlash = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(inTrigger){
            if(outsideCar){
                triggerTxt.SetActive(true);
            }
            else{
                triggerTxt.SetActive(false);
            }
            if(Input.GetKeyDown(KeyCode.E)){
                outsideCar = !outsideCar;
                CheckLocation();
            }
        }
        else{
            triggerTxt.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<BoxCollider>() == enterTrigger){
            inTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<BoxCollider>() == enterTrigger){
            inTrigger = false;
        }
    }
    
    private void CheckLocation(){
        if(!outsideCar){
            GetComponent<Transform>().SetParent(InsideCarTransform);
            GetComponent<Transform>().localPosition = new Vector3(0,0,0);
            carController.CanDrive = true;
            playerMovement.enabled = false;
            charControl.enabled = false;
            playerFlash.isFlash = false;
            playerFlash.canFlash = false;
            
        }
        else{
            carController.CanDrive = false;
            GetComponent<Transform>().SetParent(OutsideCarSpawner);
            GetComponent<Transform>().localPosition = new Vector3(0,0,0);
            GetComponent<Transform>().SetParent(null);
            charControl.enabled = true;
            playerMovement.enabled = true;
            playerFlash.canFlash = true;
        }
    }
}
