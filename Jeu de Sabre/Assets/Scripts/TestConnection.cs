using System;
using System.Configuration;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestConnection : MonoBehaviour {

    public static System.IntPtr handle;
    public static System.IntPtr handle1;
    public static bool initDone = false;

	private void Start () {
        PSMove_Bool init = PSMoveAPI.psmove_init(PSMoveAPI.PSMove_Version.PSMOVE_CURRENT_VERSION);

        if(init == PSMove_Bool.PSMove_True) {

            //handle = PSMoveAPI.psmove_connect();
            handle = PSMoveAPI.psmove_connect_by_id(0);
            handle1 = PSMoveAPI.psmove_connect_by_id(1);

            if(handle == System.IntPtr.Zero || PSMoveAPI.psmove_update_leds(handle) == 0 ||handle1 == System.IntPtr.Zero || PSMoveAPI.psmove_update_leds(handle1) == 0) {
                Debug.LogError("Could not connect to default PSMove controller");
            } else {
                Debug.Log("Connection established to default PSMove controller");
                
                initDone = true;
                // Initialisation des mouvements de la manette
                PSMoveSabre1.init();
                PSMoveSabre2.init();
            }

        } else {
            Debug.LogError("Could not init PSMove API");
        }
    }

    private void OnApplicationQuit() {
        PSMoveAPI.psmove_disconnect(handle);
    }
}
