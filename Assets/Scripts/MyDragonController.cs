using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyAR;

public class MyDragonController : MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public float speed;

    private bool foundTarget1;
    private bool foundTarget2;
    private bool foundTarget3;

    private bool isTurning;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        this.Reset();
    }

    void Reset()
    {
        target1.SetActive(true);
        target2.SetActive(true);
        target3.SetActive(true);
        this.foundTarget1 = false;
        this.foundTarget2 = false;
        this.foundTarget3 = false;
        this.isTurning = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {       
        if (!foundTarget1 || !foundTarget2 || !foundTarget3)
        {
            //setting target position
            Vector3 targetPosition = target1.transform.position;
            this.isTurning = true;
            //Debug.Log("Obj Pos: " + this.transform.position +
            //    " > Target 1 Pos: " + target1.transform.position +
            //    " > Target 2 Pos: " + target2.transform.position +
            //    " > Target 3 Pos: " + target3.transform.position);
            if (foundTarget1 && !foundTarget2)
            {
                targetPosition = target2.transform.position;
                this.isTurning = true;
            }
            if (foundTarget1 && foundTarget2 && !foundTarget3)
            {
                targetPosition = target3.transform.position;
                this.isTurning = true;
            }
            //Debug.Log("Position goal: " + targetPosition);

            float step = speed * Time.deltaTime;

            //Turning character
            Vector3 targetDir = targetPosition - this.transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            float angleBetween = Vector3.Angle(transform.forward, targetDir);
            //Debug.DrawRay(transform.position, newDir, Color.red);
            // Move our position a step closer to the target.
            this.transform.rotation = Quaternion.LookRotation(newDir);

            if (angleBetween < 1)
            {
                this.isTurning = false;
            }

            if (!this.isTurning)
            {
                // Moving
                Vector3 movement = Vector3.MoveTowards(this.transform.position, targetPosition, step);
                this.transform.position = movement;
            }
        }
        else
        {
            // Arrived in target3
            anim.SetBool("hasArrived", true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!foundTarget1)
        {
            foundTarget1 = this.CheckCollision(this.target1, other);
            //Debug.Log("Collision with Target 1: " + foundTarget1 + " > Pos: " + other.gameObject.transform.position);
            return;
        }
        if (!foundTarget2)
        {
            foundTarget2 = this.CheckCollision(this.target2, other);
            //Debug.Log("Collision with Target 2" + foundTarget2 + " > Pos: " + other.gameObject.transform.position);
            return;
        }
        if (!foundTarget3)
        {
            foundTarget3 = this.CheckCollision(this.target3, other);
            //Debug.Log("Collision with Target 3" + foundTarget3 + " > Pos: " + other.gameObject.transform.position);
            return;
        }
    }

    bool CheckCollision(GameObject target, Collider other)
    {
        if (other.gameObject.Equals(target))
        {
            other.gameObject.SetActive(false);
            return true;
        }
        return false;
    }

}
