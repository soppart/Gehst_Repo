using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followWhenClose : MonoBehaviour
{
    
    public float maxRange = 10f;
    public float minRange = 2f;
    public float speed = 2f;
    Transform target;
    
//public float rotSpeed = 80f;
     //private bool m_FacingRight = true; 
   
    //public Rigidbody2D m_Rigidbody;
    //public Vector3 m_ZAxis;
public Vector2 enemy;

void Awake() {
     
 }
 // Use this for initialization
 void Start () {
     //rigidbody.freezeRotation = true;
     //Vector3 position = new Vector3(transform.position.x,transform.position.y,0);
     target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
     

    //  m_Rigidbody = GetComponent<Rigidbody2D>();
    //     //This locks the RigidBody so that it does not move or rotate in the z axis (can be seen in Inspector).
    //     m_Rigidbody.constraints = RigidbodyConstraints2D.FreezePositionZ | RigidbodyConstraints2D.FreezeRotationZ;
    //     //Set up vector for moving the Rigidbody in the z axis
    //     m_ZAxis = new Vector3(0, 0, 5);
     
     
      
 }
 
 // Update is called once per frame
 void Update () {


void OnTriggerEnter2D(){
        Debug.Log ("Trigger!");

}
//enemy = new Vector2(0f, -90f);
 transform.right = target.position - transform.position;
    //  if (target == null){
    //         GameObject go = GameObject.Find ("Player");

    //         if (go != null) {
    //             target = go.transform;
    //         }
    //     }

    //     if (target == null)
    //     return;

                                            //  Vector3 dir = target.position - transform.position;
                                            //       dir. Normalize();

        if((Vector2.Distance(transform.position,target.position)<maxRange)
        && (Vector2.Distance(transform.position,target.position)>minRange)){
     //transform.LookAt(target);
    //   transform.Rotate(new Vector3(0,0,-target.position.z),Space.Self);//correcting the original rotatio

    //   float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

    //   Quaternion desiredRot = Quaternion.Euler(0,0, zAngle);

    //   transform.rotation = Quaternion.RotateTowards( transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
   
 //transform.LookAt(targetPosFlattened);
       //transform.Translate(Vector2.right * Time.deltaTime);
       transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime); transform.right = target.position - transform.position;
    
     }
 }
}