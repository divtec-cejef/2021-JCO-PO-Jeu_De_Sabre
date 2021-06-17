using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    private static UiUpdater updater;
    private static ControllerConnecter connecter;
    public Text Score_j1;
    public Text Score_j2;

    private void Awake()
    {
        connecter = new ControllerConnecter();
        updater = new UiUpdater(Score_j1, Score_j2);
    }


    public static UiUpdater getUiUpdater()
    {
        return updater;
    }

    /**
     * Déconnection des manettes lors de la fermeture de l'application
     */
    private void OnApplicationQuit()
    {
        PSMoveAPI.psmove_disconnect();
    }
}
