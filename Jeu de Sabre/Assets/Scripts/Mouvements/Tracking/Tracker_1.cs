using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker_1 : MonoBehaviour
{

    /* Camera PSEye */
    private static System.IntPtr tracker;
    public static void init()
    {
        //tracker = TestConnection.tracker_1;

        PSMoveAPI.psmove_tracker_enable(tracker, TestConnection.manette_1);
    }


    private void Update()
    {
        //print(PSMoveAPI.psmove_tracker_get_status(tracker, TestConnection.manette_1));
    }
}
