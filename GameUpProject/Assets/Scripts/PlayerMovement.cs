﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private FieldPath path;
    private GameObject currentField;
    public Vector3 positionToTravelTo;
    public int currentPathIndex;
    private FieldAltPoints currentFieldAltPoints;
    public float movementSpeed = 15f;

    private int spacesToMove = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentPathIndex = 0;
        path = GameObject.Find("Field Container").GetComponent<FieldPath>();
        currentField = path.fields[0];
        positionToTravelTo = currentField.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NextField")
        {
            other.tag = "Untagged";
            moveToNextField();
        }
        else if(other.tag == "LastField")
        {
            other.tag = "Untagged";
            currentField.GetComponent<FieldEffect>().TriggerEffect();
        }
    }

    private void FixedUpdate()
    {  
        // Maybe you can disable / enable the movement script when needed to be used so that you don't have the constant position update
        transform.position = Vector3.MoveTowards(transform.position, positionToTravelTo, 15f * Time.deltaTime);
    }

    public void MoveNFields(int n)
    {
        spacesToMove = n;
        GameObject lastField = currentPathIndex+ spacesToMove >= path.fields.Length ?
            path.fields[currentPathIndex + spacesToMove - path.fields.Length] :
            path.fields[currentPathIndex+ spacesToMove];
        lastField.tag = "LastField";
        moveToNextField();
    }

    public void moveToNextField()
    {
        spacesToMove--;
        //initial field
        currentField = path.fields[currentPathIndex];
        currentFieldAltPoints = currentField.GetComponent<FieldAltPoints>();
        currentFieldAltPoints.playersOnField--;

        //next field
        currentPathIndex = (currentPathIndex+1)%(path.fields.Length);
        if (path.fields[currentPathIndex].tag != "LastField")
        {
            path.fields[currentPathIndex].tag = "NextField";
        }
        currentField = path.fields[currentPathIndex];
        currentFieldAltPoints = currentField.GetComponent<FieldAltPoints>();
        currentFieldAltPoints.playersOnField++;
        positionToTravelTo = currentFieldAltPoints.altPoints[currentFieldAltPoints.playersOnField - 1].transform.position;


    }

}
