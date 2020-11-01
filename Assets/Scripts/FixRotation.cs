using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotation : MonoBehaviour
{
     Quaternion rotation;
    // private bool m_FacingRight = true;
  void Awake()
  {
       rotation = transform.rotation;
  }

//    void Update () 
//      {
//         // Switch the way the player is labelled as facing.
//         m_FacingRight = !m_FacingRight;

//         // Multiply the player's x local scale by -1.
//         Vector3 theScale = transform.localScale;
//         theScale.x *= -1;
//         transform.localScale = theScale;
//      }
  void LateUpdate()
  {
        transform.rotation = rotation;
  }

}
