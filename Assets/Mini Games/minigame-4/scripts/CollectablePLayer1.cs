﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePLayer1 : MonoBehaviour
{
    public int points=0;
    //vrednost obicnog bureta 1
    //vrednost specijalnog bureta 2

     void Update()
    {
       
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "RegularBarel")
        {
            points += 1;
            Destroy(other.gameObject);           
        }
        else if(other.gameObject.tag == "SpecialBarel")
        {
            points += 2;
            Destroy(other.gameObject);           
        }
    }
}
