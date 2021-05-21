
using System;
using UnityEngine;
using System.Collections;
using System.Timers;
using UnityEngine.UI;

public class COLLISION : MonoBehaviour
{
   public int compteur;
  
   
   void OnGUI()
   {
      GUI.TextArea(new Rect(0, 0, 30, 20), compteur.ToString());
   }

   private void OnCollisionEnter(Collision collision)
   {
      compteur++;

   }
   

   /*
   void OnCollisionStay(Collision collision)
   {
      foreach (ContactPoint contact in collision.contacts)
      {
         print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
         // Visualize the contact point
         Debug.DrawRay(contact.point, contact.normal, Color.white);
      }
   }

*/

}
