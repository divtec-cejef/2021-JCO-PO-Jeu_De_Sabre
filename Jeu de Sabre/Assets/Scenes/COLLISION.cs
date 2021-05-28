
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
   
   //Récuperer la vitesse du sabre et definir les damages en consequences
   int OnDamage(int degat)
   {
      switch (degat)
      {
         
      }

      return degat;
   }
   
   private void OnCollisionEnter(Collision collision)
   {
      int degat = 0;
      
      compteur+= OnDamage(degat);;

   }

}
