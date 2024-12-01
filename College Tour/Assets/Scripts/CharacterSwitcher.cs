using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public GameObject walkingCharacter; 
    public GameObject cyclingCharacter; 
    private GameObject currentCharacter;
    public GameObject followObject;

    void Start()
    {
        currentCharacter = Instantiate(walkingCharacter, transform.position, transform.rotation);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            SwitchCharacter();
        }
        if (currentCharacter != null && followObject != null)
        {
            followObject.transform.position = new Vector3(currentCharacter.transform.position.x, currentCharacter.transform.position.y + 20.0f, currentCharacter.transform.position.z);
            followObject.transform.rotation = Quaternion.Euler(currentCharacter.transform.rotation.eulerAngles.x + 90,
                                                         currentCharacter.transform.rotation.eulerAngles.y,
                                                         currentCharacter.transform.rotation.eulerAngles.z);            
        }
    }

    void SwitchCharacter()
    {
        Vector3 spawnPosition = transform.position;
        Quaternion spawnRotation = Quaternion.identity;
        if (currentCharacter != null)
        {
            spawnPosition = currentCharacter.transform.position;
            spawnRotation = Quaternion.Euler(0, currentCharacter.transform.eulerAngles.y, 0);
            Destroy(currentCharacter);
        }

        if (currentCharacter.CompareTag("WalkingCharacter"))
        {
            currentCharacter = Instantiate(cyclingCharacter, spawnPosition, spawnRotation);
            currentCharacter.tag = "CyclingCharacter";
            ///Destroy(currentCharacter);
        }
        else
        {
            currentCharacter = Instantiate(walkingCharacter, spawnPosition, spawnRotation);
            currentCharacter.tag = "WalkingCharacter";
            ///Destroy(currentCharacter);
        }
    }
}