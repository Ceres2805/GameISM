using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public GameObject walkingCharacter; 
    public GameObject cyclingCharacter; 

    private GameObject currentCharacter;

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