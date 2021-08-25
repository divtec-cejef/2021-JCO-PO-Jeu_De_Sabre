using System;
using Init;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TrackerConnecter : MonoBehaviour
{
    public static IntPtr player1Tracker;
    public static IntPtr player2Tracker;

    private bool isInit;

    public void Awake()
    {
        isInit = false;
        PSMoveAPI.PSMoveTrackerSettings test = new PSMoveAPI.PSMoveTrackerSettings();
        PSMoveAPI.PSMoveTrackerSettings test2 = new PSMoveAPI.PSMoveTrackerSettings();
        //player1Tracker = PSMoveAPI.tracker_new
        player1Tracker = PSMoveAPI.psmove_tracker_new_with_camera_and_settings(0, ref test);
        // while (PSMoveAPI.psmove_tracker_enable( player1Tracker, GameInit.GetControllerHandler().GetPlayer1Controller()) !=
        //        PSMoveTracker_Status.Tracker_CALIBRATED) ;
        player2Tracker = PSMoveAPI.psmove_tracker_new_with_camera_and_settings(1, ref test2);
        PSMoveTracker_Status status1 = PSMoveAPI.psmove_tracker_enable(player1Tracker, GameInit.GetControllerHandler().GetPlayer1Controller());
        PSMoveTracker_Status status2 = PSMoveAPI.psmove_tracker_enable(player2Tracker, GameInit.GetControllerHandler().GetPlayer2Controller());
        print(test);
        print(status1);
        print(player1Tracker);
        print(test2);
        print(status2);
        print(player2Tracker);

        isInit = true;
         
        //
        
       
        
        //
        //
        // Debug.Log(status1);
    }

    private void Update()
    {
        if (isInit)
        {
            print("Cam 1 " + PSMoveAPI.psmove_tracker_get_status(player1Tracker, GameInit.GetControllerHandler().GetPlayer1Controller()));
            print("Cam 2 " + PSMoveAPI.psmove_tracker_get_status(player2Tracker, GameInit.GetControllerHandler().GetPlayer2Controller()));

            // PSMoveAPI.psmove_tracker_update_image(player1Tracker);
            // int i = PSMoveAPI.psmove_tracker_update(player1Tracker, GameInit.GetControllerHandler().GetPlayer1Controller());
            // print(i.ToString());



            // if (PSMoveAPI.psmove_tracker_get_status(player1Tracker, GameInit.GetControllerHandler().GetPlayer1Controller()) == PSMoveTracker_Status.Tracker_TRACKING)
            // {
            //     float x = 0f, y = 0f, radius = 0f;
            //     // PSMoveAPI.psmove_tracker_get_position(player1Tracker,
            //     //     GameInit.GetControllerHandler().GetPlayer1Controller(), ref x, ref y, ref radius);
            //     print(string.Format("Tracking: x:{0:0.000}, " +
            //                          "y:{1:0.000}, radius:{2:0.000}", x, y, radius));
            // }
            // else
            // {
            //     print("Not Tracking !");
            // }
        }
    }
}
