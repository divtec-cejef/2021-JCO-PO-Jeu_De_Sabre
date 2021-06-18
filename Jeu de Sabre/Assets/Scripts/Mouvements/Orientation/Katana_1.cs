using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class Katana_1 : MonoBehaviour
{
    /* Permet de récupérer l'appui d'une touche du PSMove */ // Bientôt obsolète
    private static PSMoveActions actions;
    
    private static KatanaOrientation KOrientation;
    private static bool isInitDone = false;

    public static void init()
    {
        KOrientation = GameInit.getKatanaPlayer1();
        Debug.Log("MANETTE_1");
        actions = new PSMoveActions();
        actions.Buttons.Move.performed += ctx => KOrientation.defaultCalibration();
        isInitDone = true;
    }
    
    private void Update()
    {
        if(isInitDone)
            KOrientation.onUpdate();
    }
    
    private void OnEnable()
    {
        actions.Buttons.Enable();
    }

    private void OnDisable()
    {
        actions.Buttons.Disable();
    }
}
