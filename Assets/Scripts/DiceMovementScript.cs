using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiceMovementScript : MonoBehaviour
{
    public Transform Pos;
    bool isPrepared = false;
    public bool PreparationStart = false;
    public float Dist = 0;

    void Update()
    {
        if (PreparationStart)
        {
            foreach (GameObject dice in GameObject.FindGameObjectsWithTag("dices"))
            {
                dice.GetComponent<Outline>().enabled = false;
            }
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Pos.position, Dist*Time.deltaTime*3);
            if (gameObject.transform.position == Pos.position)
            {
                isPrepared = true;
                PreparationStart = false;
            }
        }
        if (isPrepared)
        {
            if (Input.GetMouseButton(0))
            {
                foreach (GameObject dice in GameObject.FindGameObjectsWithTag("dices"))
                {
                    dice.GetComponent<Outline>().enabled = false;
                }
                gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(Input.GetAxisRaw("Mouse X")*100, Input.GetAxisRaw("Mouse Y")*100, 0),ForceMode.VelocityChange);
            }
            if (Input.GetMouseButtonUp(0))
            {
                foreach (GameObject dice in GameObject.FindGameObjectsWithTag("dices"))
                {
                    dice.GetComponent<DiceRoll>().NotPlayable = false;
                }
                isPrepared = false;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-100,-50,100));
                gameObject.GetComponent<DiceMovementScript>().enabled = false;
            }
        }
    }
    private void OnMouseDown()
    {
        foreach (GameObject dice in GameObject.FindGameObjectsWithTag("dices"))
        {
            DiceMovementScript script = dice.GetComponent<DiceMovementScript>();
            dice.GetComponent<Outline>().OutlineColor = new Color(0,0.6f,0,1);
            dice.GetComponent<Rigidbody>().useGravity = false;
            script.PreparationStart = true;
            script.Dist = Vector3.Distance(script.transform.position, script.Pos.position);
        }
    }
    private void OnMouseEnter()
    {
        foreach (GameObject dice in GameObject.FindGameObjectsWithTag("dices"))
        {
            dice.GetComponent<Outline>().OutlineColor = Color.green;
        }
    }
    private void OnMouseExit()
    {
        foreach (GameObject dice in GameObject.FindGameObjectsWithTag("dices"))
        {
            dice.GetComponent<Outline>().OutlineColor = Color.blue;
        }
    }
}
