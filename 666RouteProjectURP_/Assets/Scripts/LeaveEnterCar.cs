using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveEnterCar : MonoBehaviour
{
    public CarController carController;
    public PlayerMovement playerMovement;

    public BoxCollider enterTrigger;
    public bool outsideCar;

    public Transform InsideCarTransform;
    public Transform OutsideCarSpawner;
    private CharacterController charControl;

    // Start is called before the first frame update
    void Start()
    {
        charControl = GetComponent<CharacterController>();
        if(!outsideCar){
            GetComponent<Transform>().SetParent(InsideCarTransform);
            GetComponent<Transform>().localPosition = new Vector3(0,0,0);
            playerMovement.enabled = false;
            charControl.enabled = false;
        }
         else{
            carController.CanDrive = false;
            charControl.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<BoxCollider>() == enterTrigger){
            if(Input.GetKeyDown(KeyCode.E)){
                outsideCar = !outsideCar;
                CheckLocation();
            }
        }
    }
    private void CheckLocation(){
        if(outsideCar == false){
            GetComponent<Transform>().SetParent(InsideCarTransform);
            GetComponent<Transform>().localPosition = new Vector3(0,0,0);
            carController.CanDrive = true;
            playerMovement.enabled = false;
            charControl.enabled = false;
        }
        else{
            carController.CanDrive = false;
            GetComponent<Transform>().SetParent(OutsideCarSpawner);
            GetComponent<Transform>().localPosition = new Vector3(0,0,0);
            GetComponent<Transform>().SetParent(null);
            charControl.enabled = true;
            playerMovement.enabled = true;
        }
    }
}
