using System;
using Init;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TrackerConnecter : MonoBehaviour
{
    private IntPtr player1Tracker;
    private IntPtr player2Tracker;

    private bool isInit = false;

    public void Init()
    {
        //player1Tracker = PSMoveAPI.tracker_new
        player1Tracker = PSMoveAPI.psmove_tracker_new();
        // while (PSMoveAPI.psmove_tracker_enable( player1Tracker, GameInit.GetControllerHandler().GetPlayer1Controller()) !=
        //        PSMoveTracker_Status.Tracker_CALIBRATED) ;

        isInit = true;
         
        //
        // PSMoveTracker_Status status1 = PSMoveAPI.psmove_tracker_enable(player1Tracker, GameInit.GetControllerHandler().GetPlayer1Controller());
        //
        // Debug.Log(status1);
    }

    private void Update()
    {
        if (isInit)
        {
            
            PSMoveAPI.psmove_tracker_update_image(player1Tracker);
            PSMoveAPI.psmove_tracker_update(player1Tracker, GameInit.GetControllerHandler().GetPlayer1Controller());

            if (PSMoveAPI.psmove_tracker_get_status(player1Tracker, GameInit.GetControllerHandler().GetPlayer1Controller()) == PSMoveTracker_Status.Tracker_TRACKING)
            {
                float x = 0f, y = 0f, radius = 0f;
                // PSMoveAPI.psmove_tracker_get_position(player1Tracker,
                //     GameInit.GetControllerHandler().GetPlayer1Controller(), ref x, ref y, ref radius);
                print(string.Format("Tracking: x:{0:0.000}, " +
                                     "y:{1:0.000}, radius:{2:0.000}", x, y, radius));
            }
            else
            {
                print("Not Tracking !");
            }
        }
    }
}
