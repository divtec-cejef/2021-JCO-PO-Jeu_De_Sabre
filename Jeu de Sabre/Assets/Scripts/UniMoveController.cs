// /**
//  * UniMoveExtended Eric Itomura, 2013
//  * http://eric.itomura.org/unimovex
//  **/ 
//
//
// /**
//  * UniMove API - A Unity plugin for the PlayStation Move motion controller
//  * Copyright (C) 2012, 2013, Copenhagen Game Collective (http://www.cphgc.org)
//  * 					         Patrick Jarnfelt
//  * 					         Douglas Wilson (http://www.doougle.net)
//  * 
//  * 
//  * All rights reserved.
//  *
//  * Redistribution and use in source and binary forms, with or without
//  * modification, are permitted provided that the following conditions are met:
//  *
//  *    1. Redistributions of source code must retain the above copyright
//  *       notice, this list of conditions and the following disclaimer.
//  *
//  *    2. Redistributions in binary form must reproduce the above copyright
//  *       notice, this list of conditions and the following disclaimer in the
//  *       documentation and/or other materials provided with the distribution.
//  *
//  * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
//  * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
//  * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
//  * ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE
//  * LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
//  * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
//  * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
//  * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
//  * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
//  * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
//  * POSSIBILITY OF SUCH DAMAGE.
//  **/
//
// /**
//  * PS Move API - An interface for the PS Move Motion Controller
//  * Copyright (c) 2012 Benjamin Venditti <benjamin.venditti@gmail.com>
//  * Copyright (c) 2012 Thomas Perl <m@thp.io>
//  * All rights reserved.
//  *
//  * Redistribution and use in source and binary forms, with or without
//  * modification, are permitted provided that the following conditions are met:
//  *
//  *    1. Redistributions of source code must retain the above copyright
//  *       notice, this list of conditions and the following disclaimer.
//  *
//  *    2. Redistributions in binary form must reproduce the above copyright
//  *       notice, this list of conditions and the following disclaimer in the
//  *       documentation and/or other materials provided with the distribution.
//  *
//  * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
//  * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
//  * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
//  * ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE
//  * LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
//  * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
//  * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
//  * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
//  * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
//  * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
//  * POSSIBILITY OF SUCH DAMAGE.
//  **/
//
// #define YISUP
//
// using System;
// using UnityEngine;
// using System.Runtime.InteropServices;
//
// #region enums and structs
//
// /// <summary>
// /// The Move controller can be connected by USB and/or Bluetooth.
// /// </summary>
// public enum PSMoveConnectionType 
// {
// 	Bluetooth,
// 	USB,
// 	Unknown,
// };
//
// public enum PSMove_Bool { PSMove_False = 0, PSMove_True = 1 }
//
// // Not entirely sure why some of these buttons (R3/L3) are exposed...
// public enum PSMoveButton 
// {
//     L2 = 1 << 0x00,
//     R2 = 1 << 0x01,
//     L1 = 1 << 0x02,
//     R1 = 1 << 0x03,
//     Triangle = 1 << 0x04,
//     Circle = 1 << 0x05,
//     Cross = 1 << 0x06,
//     Square = 1 << 0x07,
//     Select = 1 << 0x08,
//     L3 = 1 << 0x09,
//     R3 = 1 << 0x0A,
//     Start = 1 << 0x0B,
//     Up = 1 << 0x0C,
//     Right = 1 << 0x0D,
//     Down = 1 << 0x0E,
//     Left = 1 << 0x0F,
//     PS = 1 << 0x10,
//     Move = 1 << 0x13,
//     Trigger = 1 << 0x14,	/* We can use this value with IsButtonDown() (or the events) to get 
// 							 * a binary yes/no answer about if the trigger button is down at all.
// 							 * For the full integer/analog value of the trigger, see the corresponding property below.
// 							 */
// };
//
// // Used by psmove_get_battery().
// public enum PSMove_Battery_Level {
//     Batt_MIN = 0x00, /*!< Battery is almost empty (< 20%) */
//     Batt_20Percent = 0x01, /*!< Battery has at least 20% remaining */
//     Batt_40Percent = 0x02, /*!< Battery has at least 40% remaining */
//     Batt_60Percent = 0x03, /*!< Battery has at least 60% remaining */
//     Batt_80Percent = 0x04, /*!< Battery has at least 80% remaining */
//     Batt_MAX = 0x05, /*!< Battery is fully charged (not on charger) */
//     Batt_CHARGING = 0xEE, /*!< Battery is currently being charged */
//     Batt_CHARGING_DONE = 0xEF, /*!< Battery is fully charged (on charger) */
// };
//
// public enum PSMove_Frame {
//     Frame_FirstHalf = 0, /*!< The older frame */
//     Frame_SecondHalf, /*!< The most recent frame */
// };
//
// public enum PSMoveTracker_Status {
//     Tracker_NOT_CALIBRATED, /*!< Controller not registered with tracker */
//     Tracker_CALIBRATION_ERROR, /*!< Calibration failed (check lighting, visibility) */
//     Tracker_CALIBRATED, /*!< Color calibration successful, not currently tracking */
//     Tracker_TRACKING, /*!< Calibrated and successfully tracked in the camera */
// };
//
// public enum PSMoveTracker_Exposure {
//     Exposure_LOW, /*!< Very low exposure: Good tracking, no environment visible */
//     Exposure_MEDIUM, /*!< Middle ground: Good tracking, environment visibile */
//     Exposure_HIGH, /*!< High exposure: Fair tracking, but good environment */
//     Exposure_INVALID, /*!< Invalid exposure value (for returning failures) */
// };
//
// public enum PSMove_LED_Auto_Option
// {
// 	PSMove_LED_Auto_On,
// 	PSMove_LED_Auto_Off
// };
//
// public enum PSMove_Connect_Status
// {
// 	MoveConnect_OK,
// 	MoveConnect_Error,
// 	MoveConnect_NoData,
// 	MoveConnect_Unknown
// }
//
// public class UniMoveButtonEventArgs : EventArgs
// {
//     public readonly PSMoveButton button;
//
//     public UniMoveButtonEventArgs(PSMoveButton button)
//     {
//         this.button = button;
//     }
// }
//
// #endregion
//
// public class UniMoveController : MonoBehaviour
// {
// 	#region public instance variables
// 	
// 	/// <summary>
//     /// The handle for this controller. This pointer is what the psmove library uses for reading data via the hid library.
//     /// </summary>
//     public IntPtr handle;
// 	static public IntPtr tracker;
// 	static public IntPtr fusion;
// 	public bool disconnected = false;
// 	
// 	public PSMoveTracker_Status trackerStatus = PSMoveTracker_Status.Tracker_NOT_CALIBRATED;
// 	
// 	public float timeElapsed = 0.0f;
// 	public float updateRate = 0.05f;	// The default update rate is 50 milliseconds
// 	
// 	public static float MIN_UPDATE_RATE = 0.02f; // You probably don't want to update the controller more frequently than every 20 milliseconds
// 	
// 	public float trigger = 0f;
// 	public uint currentButtons = 0;
// 	public uint prevButtons = 0;
// 	
// 	public Vector3 rawAccel = Vector3.down;
// 	public Vector3 accel = Vector3.down;
// 	public Vector3 magnet = Vector3.zero;
// 	public Vector3 rawGyro = Vector3.zero;
// 	public Vector3 gyro = Vector3.zero;
// 	
// 	public Quaternion m_orientation = Quaternion.identity;
// 	public Quaternion m_orientationFix = Quaternion.identity;
// 	public Vector3 m_position = Vector3.zero;
// 	public Vector3 [] m_positionHistory = new Vector3[5];
// 	public Vector3 m_positionFix = Vector3.zero;
// 	public Vector3 m_positionScalePos = Vector3.one*0.01f;
// 	public Vector3 m_positionScaleNeg = -Vector3.one*0.01f;
// 	
// 	public Quaternion Orientation
// 	{
// 		get{ return m_orientation;}
// 	}
// 	
// 	public Vector3 Position
// 	{
// 		get{ return m_position; }	
// 	}
// 	
// 	public Vector3 Up
// 	{
// 		get{ return m_orientation*Vector3.up;}
// 	}
// 	
// 	public Vector3 Forward
// 	{
// 		get{ return m_orientation*Vector3.forward;}
// 	}
// 	
// 	public Vector3 Right
// 	{
// 		get{ return m_orientation*Vector3.right;}
// 	}
//
// 	
// 	// TODO: These values still need to be implemented, so we don't expose them publicly
// 	public PSMove_Battery_Level battery = PSMove_Battery_Level.Batt_20Percent;
// 	public float temperature = 0f;
// 	
// 	static public void ReinitializeLibrary()
// 	{
// 		psmove_reinit();
// 	}
// 	
// 	/// <summary>
//     /// Event fired when the controller disconnects unexpectedly (i.e. on going out of range).
//     /// </summary>
//     public event EventHandler OnControllerDisconnected;
// 	
// 	#endregion
// 	/// <summary>
// 	/// Returns whether the connecting succeeded or not.
// 	/// 
//     /// NOTE! This function does NOT pair the controller by Bluetooth.
//     /// If the controller is not already paired, it can only be connected by USB.
//     /// See README for more information.
//     /// </summary>
// 	public PSMove_Connect_Status Init(int index)
// 	{
// 		handle = psmove_connect_by_id(index);
// 		
// 		// Error check the result!
// 		if (handle == IntPtr.Zero) return PSMove_Connect_Status.MoveConnect_Error;
// 		
// 		// Make sure the connection is actually sending data. If not, this is probably a controller 
// 		// you need to remove manually from the OSX Bluetooth Control Panel, then re-connect.
// 		if (psmove_update_leds(handle) == 0) return PSMove_Connect_Status.MoveConnect_NoData;
// 		return PSMove_Connect_Status.MoveConnect_OK;
// 	}
// 	
// 	static public void SetExposure(PSMoveTracker_Exposure exposure)
// 	{
// 		if(tracker == IntPtr.Zero )
// 		{
// 			psmove_tracker_set_exposure(tracker,exposure);
// 		}
// 	}
// 	
// 	static public void SetDimming(float dimming)
// 	{
// 		if(tracker == IntPtr.Zero )
// 		{
// 			psmove_tracker_set_dimming(tracker,dimming);
// 		}
// 	}
// 	
// 	static public bool StartTracker()
// 	{
// 		if(tracker == IntPtr.Zero )
// 		{
// 			tracker = psmove_tracker_new ();
// 			//fusion = psmove_fusion_new(tracker,0.001f,1.0f);
// 		}
// 		return tracker != IntPtr.Zero;
// 	}
// 	
// 	/// <summary>
// 	/// Initialize and calibrate the tracker.
// 	/// </summary>
// 	/// <returns>
// 	/// Calibration and tracking status;
// 	/// </returns>
// 	public PSMoveTracker_Status EnableTracking()
// 	{
// 		if(tracker == IntPtr.Zero )
// 		{
// 			StartTracker();
// 		}
// 		
// 		PSMoveTracker_Status status = psmove_tracker_enable_with_color(tracker,handle,(byte)0,(byte)0,(byte)255);
// 		
// 		trackerStatus = status;
// 		
// 		psmove_tracker_set_auto_update_leds(tracker, handle, PSMove_Bool.PSMove_False );
// 		
// 		if(status == PSMoveTracker_Status.Tracker_TRACKING
// 			|| status == PSMoveTracker_Status.Tracker_CALIBRATED )
// 		{
// 			psmove_tracker_update_image(tracker);
// 			psmove_tracker_update(tracker,handle);
// 			status = psmove_tracker_get_status(tracker, handle);
// 		}
// 		m_positionFix = Vector3.zero;
// 		m_positionScalePos = Vector3.one*0.1f;
// 		m_positionScaleNeg = -Vector3.one*0.1f;
// 		for( int i = 0; i < m_positionHistory.Length ; ++i )
// 		{
// 			m_positionHistory[i] = Vector3.zero;
// 		}
// 		return status;
// 	}
// 	
// 	public void DisableTracking()
// 	{
// 		if(tracker != IntPtr.Zero && handle != IntPtr.Zero )
// 		{
// 			psmove_tracker_disable(tracker,handle);
// 		}
// 	}
// 	
// 	public virtual void OnDestroy()
// 	{
// 		if( handle != IntPtr.Zero)
// 		{
// 			Disconnect();	
// 		}
// 	}
// 	
// 	
// 	static public void DestroyTracker()
// 	{
// 		if(tracker != IntPtr.Zero )
// 		{
// 			psmove_tracker_free (tracker);
// 			tracker = IntPtr.Zero;	
// 		}
// 		if(fusion != IntPtr.Zero )
// 		{
// 			psmove_fusion_free (fusion);	
// 			fusion = IntPtr.Zero;
// 		}
// 	}
// 	
// 	/// <summary>
//     /// Static function that returns the number of *all* controller connections.
//     /// This count will tally both USB and Bluetooth connections.
//     /// Note that one physical controller, then, might register multiple connections.
//     /// To discern between different connection types, see the ConnectionType property below.
//     /// </summary>
// 	public static int GetNumConnected()
// 	{
// 		return psmove_count_connected();
// 	}
// 	
// 	/// <summary>
//     /// The amount of time, in seconds, between update calls.
//     /// The faster this rate, the more responsive the controllers will be.
//     /// However, update too fast and your computer won't be able to keep up (see below).
//     /// You almost certainly don't want to make this faster than 20 milliseconds (0.02f).
//     /// 
//     /// NOTE! We find that slower/older computers can have trouble keeping up with a fast update rate,
//     /// especially the more controllers that are connected. See the README for more information.
//     /// </summary>
// 	public float UpdateRate 
// 	{
// 		get { return this.updateRate; }
// 		set { updateRate = Math.Max(value, MIN_UPDATE_RATE); }	// Clamp negative values up to 0
// 	}
// 	
// 	void Update() 
// 	{
// 		UpdateControllerRateLimited();
//     }
// 	
// 	
// 	void UpdateControllerRateLimited()
// 	{
// 		if (disconnected) return;
// 		
// 		// we want to update the previous buttons outside the update restriction so,
// 		// we only get one button event pr. unity update frame
// 		prevButtons = currentButtons;
// 		
// 		timeElapsed += Time.deltaTime;
// 		
// 		// Here we manually enforce updates only every updateRate amount of time
// 		// The reason we don't just do this in FixedUpdate is so the main program's FixedUpdate rate 
// 		// can be set independently of the controllers' update rate.
// 		
// 		if (timeElapsed < updateRate) return;	
// 		else timeElapsed = 0.0f;
// 		UpdateController();
// 	}
// 	
// 	void UpdateController()
// 	{
// 		
// 		uint buttons = 0;
// 		
// 		// NOTE! There is potentially data waiting in queue. 
// 		// We need to poll *all* of it by calling psmove_poll() until the queue is empty. Otherwise, data might begin to build up.
// 		while (psmove_poll(handle) > 0) 
// 		{
// 			// We are interested in every button press between the last update and this one:
// 			buttons = buttons | psmove_get_buttons(handle);
// 			
// 			// The events are not really working from the PS Move Api. So we do our own with the prevButtons
// 			//psmove_get_button_events(handle, ref pressed, ref released);
// 		}
// 		currentButtons = buttons;
// 		
// 		// For acceleration, gyroscope, and magnetometer values, we look at only the last value in the queue.
// 		// We could in theory average all the acceleration (and other) values in the queue for a "smoothing" effect, but we've chosen not to.
// 		ProcessData();
// 		
// 		// Send a report to the controller to update the LEDs and rumble.
// 		if (psmove_update_leds(handle) == 0)
// 		{
// 			Debug.Log ("led set");
// 			// If it returns zero, the controller must have disconnected (i.e. out of battery or out of range),
// 			// so we should fire off any events and disconnect it.
// 			if( this != null )
// 			{
// 				OnControllerDisconnected(this, new EventArgs());
// 			}
// 			Disconnect();
// 		}	
// 	}
// 	
// 	static public bool UpdateOnce()
// 	{
// 		if( tracker != IntPtr.Zero)
// 		{
// 			psmove_tracker_update_image(tracker);	
// 			return psmove_tracker_update(tracker,IntPtr.Zero) != 0;
// 		}
// 		return false;
// 	}
// 	
//     void OnApplicationQuit() 
// 	{
//         Disconnect();
//     }
// 	
// 	/// <summary>
//     /// Returns true if "button" is currently down.
//     /// </summary
// 	public bool GetButton(PSMoveButton b)
//     {
// 		if (disconnected) return false;
// 		
//     	return ((currentButtons & (uint)b) != 0);
//     }
//
// 	/// <summary>
//     /// Returns true if "button" is pressed down this instant.
//     /// </summary
// 	public bool GetButtonDown(PSMoveButton b)
//     {
// 		if (disconnected) return false;
//     	return ((prevButtons & (uint)b) == 0) && ((currentButtons & (uint)b) != 0);
//     }
//
// 	/// <summary>
//     /// Returns true if "button" is released this instant.
//     /// </summary
// 	public bool GetButtonUp(PSMoveButton b)
//     {
// 		if (disconnected) return false;
// 		
//     	return ((prevButtons & (uint)b) != 0) &&  ((currentButtons & (uint)b) == 0);
//     }
// 	/// <summary>
//     /// Disconnect the controller
//     /// </summary>
//
// 	public void Disconnect()
//     {
// 		if( handle != IntPtr.Zero )
// 		{
// 			DisableTracking();
// 			
// 	        SetLED(0,0,0);
// 	        SetRumble(0);
// 			psmove_disconnect(handle);
// 			handle = IntPtr.Zero;
// 			disconnected = true;
// 		}
//     }
// 	
// 	/// <summary>
//     /// Whether or not the controller has been disconnected
//     /// </summary
// 	public bool Disconnected
//     {
// 		get { return disconnected; }
//     }
// 	
//     /// <summary>
//     /// Sets the amount of rumble
//     /// </summary>
//     /// <param name="rumble">the rumble amount (0-1)</param>
//     public void SetRumble(float rumble)
//     {
// 		if (disconnected) return;
// 		
// 		// Clamp to [0,255], rounded to nearest whole number
// 		rumble = Mathf.Clamp01(rumble)*255.0f;
//         byte rumbleByte = (byte)(rumble+0.5f);
// 		
// 		psmove_set_rumble(handle, (char)rumbleByte);
//     }
// 	
// 	/// <summary>
//     /// Sets the LED color
//     /// </summary>
//     /// <param name="color">Unity's Color type</param>
//     public void SetLED(Color color)
//     {
// 		SetLED((byte)(color.r * 255), (byte)(color.g * 255), (byte)(color.b * 255));
//     }
// 	
// 	/// <summary>
//     /// Sets the LED color
//     /// </summary>
//     /// <param name="r">Red value of the LED color (0-255)</param>
//     /// <param name="g">Green value of the LED color (0-255)</param>
//     /// <param name="b">Blue value of the LED color (0-255)</param>
//     public void SetLED(byte r, byte g, byte b)
//     {
// 		if (disconnected) return;
// 		if(trackerStatus == PSMoveTracker_Status.Tracker_TRACKING ||
// 			trackerStatus == PSMoveTracker_Status.Tracker_CALIBRATED )
// 		{
// 			psmove_tracker_get_color(tracker,handle, ref r, ref g, ref b);
// 			psmove_set_leds(handle, (char)r, (char)g, (char)b);
// 		}
// 		else
// 		{
// 			psmove_set_leds(handle, (char)r, (char)g, (char)b);
// 		}
//     }
// 	
// 	/// <summary>
//     /// Value of the analog trigger button (between 0 and 1)
//     /// </summary
// 	public float Trigger
//     {
// 		get { return trigger; }
//     }
// 	
// 	/// <summary>
//     /// The 3-axis acceleration values. 
//     /// </summary>
// 	public Vector3 RawAcceleration 
// 	{
// 		get { return rawAccel; }
// 	}
// 	
// 	/// <summary>
//     /// The 3-axis acceleration values, roughly scaled between -3g to 3g (where 1g is Earth's gravity).
//     /// </summary>
// 	public Vector3 Acceleration 
// 	{
// 		get { return accel; }
// 	}
// 	
// 	/// <summary>
//     /// The raw values of the 3-axis gyroscope. 
//     /// </summary>
// 	public Vector3 RawGyroscope
// 	{
// 		get { return rawGyro; }
// 	}
// 	/// <summary>
//     /// The raw values of the 3-axis gyroscope. 
//     /// </summary>
// 	public Vector3 Gyro
// 	{
// 		get { return gyro; }
// 	}
// 	
// 	/// <summary>
//     /// The raw values of the 3-axis magnetometer.
//     /// To be honest, we don't fully understand what the magnetometer does.
//     /// The C API on which this code is based warns that this isn't fully tested.
//     /// </summary>
// 	public Vector3 Magnetometer 
// 	{
// 		get { return magnet; }
// 	}
// 	
// 	/// <summary>
//     /// The battery level
//     /// </summary>
// 	public PSMove_Battery_Level Battery 
// 	{
// 		get { return battery; }
// 	}
// 	
// 	/// <summary>
//     /// The temperature in Celcius
//     /// </summary>
// 	public float Temperature 
// 	{
// 		get { return temperature; }
// 	}
// 	
// 	/* TODO: These two values still need to be implemented, so we don't expose them publicly... yet!
//
// 	public float Battery 
// 	{
// 		get { return this.battery; }
// 	}
// 	
// 	public float Temperature 
// 	{
// 		get { return this.temperature; }
// 	}
// 	*/
// 	
// 	public string StatusInfo()
// 	{
// 		string text = "";
// 		text += IsOriented() ? "oriented" : "!oriented";
// 		text += " & ";
// 		text += trackerStatus == PSMoveTracker_Status.Tracker_TRACKING ? "tracking" : "!tracking";
// 		return text;
// 	}
// 	
// 	public PSMoveConnectionType ConnectionType 
// 	{
// 		get { return psmove_connection_type(handle); }
// 	}
// 	
// 	public bool IsOriented()
// 	{
// 		return psmove_has_orientation(handle) == PSMove_Bool.PSMove_True;
// 	}
// 	
// 	public bool Orient(PSMove_Bool enable)
// 	{
// 		bool oriented = false;
// 		psmove_enable_orientation(handle,enable);
// 		if( enable == PSMove_Bool.PSMove_True)
// 		{
// 			psmove_reset_orientation(handle);
// 			
// 			oriented = psmove_has_orientation(handle) == PSMove_Bool.PSMove_True;
// 			if( oriented )
// 			{
// 				float qw = 0.0f,qx = 0.0f,qy = 0.0f,qz = 0.0f;
// 				psmove_get_orientation(handle, ref qw, ref qx, ref qy, ref qz );
// 				
// 				Quaternion rot = new Quaternion(qx,qy,qz,qw);
// 				m_orientationFix = Quaternion.Inverse(rot);
// 			}
// 		}
// 		return  oriented;
// 	}
// 	
// 	public bool RenormalizeTracker()
// 	{
// 		if( tracker != IntPtr.Zero )
// 		{
// 			// only orient when get tracking going
// 			if( trackerStatus != PSMoveTracker_Status.Tracker_TRACKING )
// 			{
// 				float rx = 0.0f, ry = 0.0f, rrad = 0.0f;
// 				psmove_tracker_get_position(tracker, handle, ref rx, ref ry, ref rrad );
// 				
// 				float rz = psmove_tracker_distance_from_radius(tracker, rrad);
// 	
// 				m_positionFix = new Vector3(-rx,-ry,-rz);
// 				m_positionScaleNeg = -Vector3.one*0.01f;
// 				m_positionScalePos = Vector3.one*0.01f;
// 				for( int i = 0; i < m_positionHistory.Length ; ++i )
// 				{
// 					m_positionHistory[i] = Vector3.zero;
// 				}
// 				psmove_set_leds(handle,(char)0,(char)255,(char)0);
// 				psmove_update_leds(handle);
// 				return true;
// 			}
// 		}
// 		psmove_set_leds(handle,(char)255,(char)0,(char)0);
// 		psmove_update_leds(handle);
// 		return false;
// 	}
// 	 
// 	#region public methods                              
// 	
// 	/// <summary>
//     /// Process all the raw data on the Playstation Move controller
//     /// </summary>
//     public void ProcessData()
//     {	
// 		trigger = ((int)psmove_get_trigger(handle)) / 255f;
// 		
// 		{
// 			int x = 0, y = 0, z = 0;
// 			
// 			psmove_get_accelerometer(handle, ref x, ref y, ref z);
// 			
// 			rawAccel.x = x;
// 			rawAccel.y = y;
// 			rawAccel.z = z;
// 		}
// 		
// 		{
// 			float ax = 0, ay = 0, az = 0;
// 			psmove_get_accelerometer_frame(handle, PSMove_Frame.Frame_SecondHalf, ref ax, ref ay, ref az);
// 			
// 			accel.x = ax;
// 			accel.y = ay;
// 			accel.z = az;
// 		}
// 		
// 		{
// 			int x = 0, y = 0, z = 0;
// 			psmove_get_gyroscope(handle, ref x, ref y, ref z );
// 			
// 			rawGyro.x = x;
// 			rawGyro.y = y;
// 			rawGyro.z = z;
// 		}
// 		
// 		{
// 			float gx = 0, gy = 0, gz = 0;
// 			psmove_get_gyroscope_frame(handle, PSMove_Frame.Frame_SecondHalf, ref gx, ref gy, ref gz);
// 			
// 			gyro.x = gx;
// 			gyro.y = gy;
// 			gyro.z = gz;
// 		}
// 		
// 		if( psmove_has_orientation(handle) == PSMove_Bool.PSMove_True )
// 		{
// 			float qw = 0.0f,qx = 0.0f,qy = 0.0f,qz = 0.0f;
// 			psmove_get_orientation(handle, ref qw, ref qx, ref qy, ref qz );
// 			
// 			Quaternion rot = new Quaternion(qx,qy,qz,qw);
// 			rot = rot*m_orientationFix;
// #if YISUP			
// 			Vector3 euler = rot.eulerAngles;
// 			rot = Quaternion.Euler(-euler.x,-euler.y,euler.z);
// #endif	
// 			
// 			m_orientation = rot;
// 		}
// 		else
// 		{
// 			m_orientation = Quaternion.identity;
// 		}
// 		
// 		if( tracker != IntPtr.Zero)
// 		{
// 			trackerStatus = psmove_tracker_get_status(tracker,handle);
// 			if( trackerStatus == PSMoveTracker_Status.Tracker_TRACKING)
// 			{
// 				float rx = 0.0f, ry = 0.0f, rrad = 0.0f;
// 				psmove_tracker_get_position(tracker, handle, ref rx, ref ry, ref rrad );
// 				
// 				float rz = psmove_tracker_distance_from_radius(tracker, rrad);
// 				Vector3 vec = new Vector3(rx,ry,rz) + m_positionFix;
// 	#if YISUP
// 				vec.x = -vec.x;
// 				vec.y = -vec.y;
// 				vec.z = -vec.z;
// 	#endif
// 				m_positionScalePos = Vector3.Max(vec,m_positionScalePos);
// 				m_positionScaleNeg = Vector3.Min(vec,m_positionScaleNeg);
// 				
// 				Vector3 extents = m_positionScalePos-m_positionScaleNeg;
// 				
// 				vec = vec- m_positionScaleNeg;
// 				vec.x = vec.x/extents.x;
// 				vec.y = vec.y/extents.y;
// 				vec.z = vec.z/extents.z;
// 				vec = vec*2.0f - Vector3.one;
// 				
// 				for( int i = m_positionHistory.Length-1; i > 0 ;--i)
// 				{
// 					 m_positionHistory[i] = m_positionHistory[i-1];
// 				}
// 				m_positionHistory[0] = vec;
// 				
// 				//vec = m_positionHistory[0]*0.3f + m_positionHistory[1]*0.5f + m_positionHistory[2]*0.1f + m_positionHistory[3]*0.05f + m_positionHistory[4]*0.05f;
// 					
// 				m_position = vec;
// 			}
// 			else
// 			{
// 				Vector3.Lerp( m_position,Vector3.zero,Time.deltaTime);
// 			}
// 		}
// 		
// 		{
// 			int x = 0, y = 0, z = 0;
// 			psmove_get_magnetometer(handle, ref x, ref y, ref z );
// 			
// 			// TODO: Should these values be converted into a more human-understandable range?
// 			magnet.x = x;
// 			magnet.y = y;
// 			magnet.z = z;
// 		}
// 		
// 		battery = psmove_get_battery(handle);
// 		
// 		temperature = psmove_get_temperature(handle);
// 		
//     }
// 	#endregion
// 	
// 	
// 	#region importfunctions
// 	
// 	/* The following functions are bindings to Thomas Perl's C API for the PlayStation Move (http://thp.io/2010/psmove/)
// 	 * See README for more details.
// 	 * 
// 	 * NOTE! We have included bindings for the psmove_pair() function, even though we don't use it here
// 	 * See README and Pairing Utility code for more about pairing.
// 	 * 
// 	 * TODO: Expose hooks to psmove_get_btaddr() and psmove_set_btadd()
// 	 * These functions are already called by psmove_pair(), so unless you need to do something special, you won't need them.
// 	 */
// 	
// 	
// 	public enum PSMove_Version {
//          /**
//           * Version format: AA.BB.CC = 0xAABBCC
//           *
//           * Examples:
//           *  3.0.1 = 0x030001
//           *  4.2.11 = 0x04020B
//           **/
//          PSMOVE_CURRENT_VERSION = 0x030001, /*!< Current version, see psmove_init() */
//      }
// 	
// 	//psmove.h
// 	[DllImport("libpsmoveapi")]
// 	public static extern void psmove_reinit();
// 	
// 	[DllImport("libpsmoveapi")]
//      public static extern PSMove_Bool psmove_init(PSMove_Version version);
// 	
// 	[DllImport("libpsmoveapi")]
// 	public static extern int psmove_count_connected();
// 	
// 	[DllImport("libpsmoveapi")]
// 	public static extern IntPtr psmove_connect();
// 	
// 	[DllImport("libpsmoveapi")]
// 	public static extern IntPtr psmove_connect_by_id(int id);
// 	
// 	[DllImport("libpsmoveapi")]
// 	public static extern int psmove_pair(IntPtr move);
// 	
// 	[DllImport("libpsmoveapi")]
// 	public static extern PSMoveConnectionType psmove_connection_type(IntPtr move);
// 	
// 	[DllImport("libpsmoveapi")]
// 	public static extern int psmove_has_calibration(IntPtr move);
// 	
// 	[DllImport("libpsmoveapi")]
// 	public static extern void psmove_set_leds(IntPtr move, char r, char g, char b);
// 	
// 	[DllImport("libpsmoveapi")]
// 	public static extern int psmove_update_leds(IntPtr move);
// 	
// 	[DllImport("libpsmoveapi")]
// 	public static extern void psmove_set_rumble(IntPtr move, char rumble);
// 	
// 	[DllImport("libpsmoveapi")]
// 	public static extern uint psmove_poll(IntPtr move);
// 		
// 	[DllImport("libpsmoveapi")]
// 	public static extern uint psmove_get_buttons(IntPtr move);
// 	
// 	[DllImport("libpsmoveapi")]
// 	public static extern uint psmove_get_button_events(IntPtr move, ref uint pressed, ref uint released);
// 		
// 	[DllImport("libpsmoveapi")]
// 	public static extern char psmove_get_trigger(IntPtr move);
// 	
// 	[DllImport("libpsmoveapi")]
// 	public static extern float psmove_get_temperature(IntPtr move);
// 	
// 	[DllImport("libpsmoveapi")]
// 	public static extern PSMove_Battery_Level psmove_get_battery(IntPtr move);
// 	
// 	[DllImport("libpsmoveapi")]
// 	public static extern void psmove_get_accelerometer(IntPtr move, ref int ax, ref int ay, ref int az);
// 	
// 	[DllImport("libpsmoveapi")]
// 	public static extern void psmove_get_accelerometer_frame(IntPtr move,PSMove_Frame frame, ref float ax, ref float ay, ref float az);
// 	
// 	[DllImport("libpsmoveapi")]
// 	public static extern void psmove_get_gyroscope(IntPtr move, ref int gx, ref int gy, ref int gz);
// 	
// 	[DllImport("libpsmoveapi")]
// 	public static extern void psmove_get_gyroscope_frame(IntPtr move,PSMove_Frame frame, ref float gx, ref float gy, ref float gz);
// 	
// 	[DllImport("libpsmoveapi")]
// 	public static extern void psmove_get_magnetometer(IntPtr move, ref int mx, ref int my, ref int mz);
// 	
// 	[DllImport("libpsmoveapi")]
// 	public static extern void psmove_enable_orientation (IntPtr move, PSMove_Bool enabled);
// 		
// 	[DllImport("libpsmoveapi")]
// 	public static extern PSMove_Bool psmove_has_orientation (IntPtr move);
// 	
// 	[DllImport("libpsmoveapi")]
// 	public static extern void	psmove_get_orientation (IntPtr move, ref float w, ref float x, ref float y, ref float z);
// 	
// 	[DllImport("libpsmoveapi")]
// 	public static extern void psmove_reset_orientation (IntPtr move);
// 	
// 	[DllImport("libpsmoveapi")]
// 	public static extern void psmove_disconnect(IntPtr move);
// 	
// 	
// 	// psmove_tracker.h
// 	
// 	/**
// 	 * \brief Create a new PS Move Tracker instance and open the camera
// 	 *
// 	 * This will select the best camera for tracking (this means that if
// 	 * a PSEye is found, it will be used, otherwise the first available
// 	 * camera will be used as fallback).
// 	 *
// 	 * \return A new \ref PSMoveTracker instance or \c NULL on error
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern IntPtr psmove_tracker_new();
// 	
// 	/**
// 	 * \brief Create a new PS Move Tracker instance with a specific camera
// 	 *
// 	 * This function can be used when multiple cameras are available to
// 	 * force the use of a specific camera.
// 	 *
// 	 * Usually it's better to use psmove_tracker_new() and let the library
// 	 * choose the best camera, unless you have a good reason not to.
// 	 *
// 	 * \param camera Zero-based index of the camera to use
// 	 *
// 	 * \return A new \ref PSMoveTracker instance or \c NULL on error
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern IntPtr psmove_tracker_new_with_camera(int camera);
// 			
// 	
// 	/**
// 	 * \brief Configure if the LEDs of a controller should be auto-updated
// 	 *
// 	 * If auto-update is enabled (the default), the tracker will set and
// 	 * update the LEDs of the controller automatically. If not, the user
// 	 * must set the LEDs of the controller and update them regularly. In
// 	 * that case, the user can use psmove_tracker_get_color() to determine
// 	 * the color that the controller's LEDs have to be set to.
// 	 *
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 * \param move A valid \ref PSMove handle
// 	 * \param auto_update_leds \ref PSMove_True to auto-update LEDs from
// 	 *                         the tracker, \ref PSMove_False if the user
// 	 *                         will take care of updating the LEDs
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern void psmove_tracker_set_auto_update_leds(IntPtr tracker, IntPtr move,
// 	        PSMove_Bool auto_update_leds);
// 	
// 	/**
// 	 * \brief Check if the LEDs of a controller are updated automatically
// 	 *
// 	 * This is the getter function for psmove_tracker_set_auto_update_leds().
// 	 * See there for details on what auto-updating LEDs means.
// 	 *
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 * \param move A valid \ref PSMove handle
// 	 *
// 	 * \return \ref PSMove_True if the controller's LEDs are set to be
// 	 *         updated automatically, \ref PSMove_False otherwise
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern PSMove_Bool psmove_tracker_get_auto_update_leds(IntPtr tracker, IntPtr move);
// 	
// 	
// 	/**
// 	 * \brief Set the LED dimming value for all controller
// 	 *
// 	 * Usually it's not necessary to call this function, as the dimming
// 	 * is automatically determined when the first controller is enabled.
// 	 *
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 * \param dimming A value in the range from 0 (LEDs switched off) to
// 	 *                1 (full LED intensity)
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern void psmove_tracker_set_dimming(IntPtr tracker, float dimming);
//
// 	/**
// 	 * \brief Get the LED dimming value for all controllers
// 	 *
// 	 * See psmove_tracker_set_dimming() for details.
// 	 *
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 *
// 	 * \return The dimming value for the LEDs
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern float psmove_tracker_get_dimming(IntPtr tracker);
//
// 	/**
// 	 * \brief Set the desired camera exposure mode
// 	 *
// 	 * This function sets the desired exposure mode. This should be
// 	 * called before controllers are added to the tracker, so that the
// 	 * dimming for the controllers can be determined for the specific
// 	 * exposure setting.
// 	 *
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 * \param exposure One of the \ref PSMoveTracker_Exposure values
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern void psmove_tracker_set_exposure(IntPtr tracker, PSMoveTracker_Exposure exposure);
//
// 	/**
// 	 * \brief Get the desired camera exposure mode
// 	 *
// 	 * See psmove_tracker_set_exposure() for details.
// 	 *
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 *
// 	 * \return One of the \ref PSMoveTracker_Exposure values
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern PSMoveTracker_Exposure psmove_tracker_get_exposure(IntPtr tracker);
//
// 	/**
// 	 * \brief Enable or disable camera image deinterlacing (line doubling)
// 	 *
// 	 * Enables or disables camera image deinterlacing for this tracker.
// 	 * You usually only want to enable deinterlacing if your camera source
// 	 * provides interlaced images (e.g. 1080i). The interlacing will be
// 	 * removed by doubling every other line. By default, deinterlacing is
// 	 * disabled.
// 	 *
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 * \param enabled \ref PSMove_True to enable deinterlacing,
// 	 *                \ref PSMove_False to disable deinterlacing (default)
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern void psmove_tracker_enable_deinterlace(IntPtr tracker, PSMove_Bool enabled);
//
// 	/**
// 	 * \brief Enable or disable horizontal camera image mirroring
// 	 *
// 	 * Enables or disables horizontal mirroring of the camera image. The
// 	 * mirroring setting will affect the X coordinates of the controller
// 	 * positions tracked, as well as the output image. In addition, the
// 	 * sensor fusion module will mirror the orientation information if
// 	 * mirroring is set here. By default, mirroring is disabled.
// 	 *
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 * \param enabled \ref PSMove_True to mirror the image horizontally,
// 	 *                \ref PSMove_False to leave the image as-is (default)
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern void psmove_tracker_set_mirror(IntPtr tracker, PSMove_Bool enabled);
//
// 	/**
// 	 * \brief Query the current camera image mirroring state
// 	 *
// 	 * See psmove_tracker_set_mirror() for details.
// 	 *
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 *
// 	 * \return \ref PSMove_True if mirroring is enabled,
// 	 *         \ref PSMove_False if mirroring is disabled
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern PSMove_Bool psmove_tracker_get_mirror(IntPtr tracker);
//
// 	/**
// 	 * \brief Enable tracking of a motion controller
// 	 *
// 	 * Calling this function will register the controller with the
// 	 * tracker, and start blinking calibration. The user should hold
// 	 * the motion controller in front of the camera and wait for the
// 	 * calibration to finish.
// 	 *
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 * \param move A valid \ref PSMove handle
// 	 *
// 	 * \return \ref Tracker_CALIBRATED if calibration succeeded
// 	 * \return \ref Tracker_CALIBRATION_ERROR if calibration failed
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern PSMoveTracker_Status psmove_tracker_enable(IntPtr tracker, IntPtr move);
// 	
// 	/**
// 	 * \brief Enable tracking with a custom sphere color
// 	 *
// 	 * This function does basically the same as psmove_tracker_enable(),
// 	 * but forces the sphere color to a pre-determined value.
// 	 *
// 	 * Using this function might give worse tracking results, because
// 	 * the color might not be optimal for a given lighting condition.
// 	 *
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 * \param move A valid \ref PSMove handle
// 	 * \param r The red intensity of the desired color (0..255)
// 	 * \param g The green intensity of the desired color (0..255)
// 	 * \param b The blue intensity of the desired color (0..255)
// 	 *
// 	 * \return \ref Tracker_CALIBRATED if calibration succeeded
// 	 * \return \ref Tracker_CALIBRATION_ERROR if calibration failed
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern PSMoveTracker_Status
// 		psmove_tracker_enable_with_color(IntPtr tracker, IntPtr move, byte r, byte g, byte b);
//
// 	/**
// 	 * \brief Disable tracking of a motion controller
// 	 *
// 	 * If the \ref PSMove instance was never enabled, this function
// 	 * does nothing. Otherwise it removes the instance from the
// 	 * tracker and stops tracking the controller.
// 	 *
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 * \param move A valid \ref PSMove handle
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern void psmove_tracker_disable(IntPtr tracker, IntPtr move);
//
// 	/**
// 	 * \brief Get the desired sphere color of a motion controller
// 	 *
// 	 * Get the sphere color of the controller as it is set using
// 	 * psmove_update_leds(). This is not the color as the sphere
// 	 * appears in the camera - for that, see
// 	 * psmove_tracker_get_camera_color().
// 	 *
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 * \param move A Valid \ref PSmove handle
// 	 * \param r Pointer to store the red component of the color
// 	 * \param g Pointer to store the green component of the color
// 	 * \param g Pointer to store the blue component of the color
// 	 *
// 	 * \return Nonzero if the color was successfully returned, zero if
// 	 *         if the controller is not enabled of calibration has not
// 	 *         completed yet.
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern int psmove_tracker_get_color(IntPtr tracker, IntPtr move,
// 	        ref byte r, ref byte g, ref byte b);
//
// 	/**
// 	 * \brief Get the sphere color of a controller in the camera image
// 	 *
// 	 * Get the sphere color of the controller as it currently
// 	 * appears in the camera image. This is not the color that is
// 	 * set using psmove_update_leds() - for that, see
// 	 * psmove_tracker_get_color().
// 	 *
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 * \param move A Valid \ref PSmove handle
// 	 * \param r Pointer to store the red component of the color
// 	 * \param g Pointer to store the green component of the color
// 	 * \param g Pointer to store the blue component of the color
// 	 *
// 	 * \return Nonzero if the color was successfully returned, zero if
// 	 *         if the controller is not enabled of calibration has not
// 	 *         completed yet.
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern int psmove_tracker_get_camera_color(IntPtr tracker, IntPtr move,
// 	        ref byte r, ref byte g, ref byte b);
// 	
// 	/**
// 	 * \brief Set the sphere color of a controller in the camera image
// 	 *
// 	 * This function should only be used in special situations - it is
// 	 * usually not required to manually set the sphere color as it appears
// 	 * in the camera image, as this color is determined at runtime during
// 	 * blinking calibration. For some use cases, it might be useful to
// 	 * set the color manually (e.g. when the user should be able to select
// 	 * the color in the camera image after lighting changes).
// 	 * 
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 * \param move A valid \ref PSMove handle
// 	 * \param r The red component of the color (0..255)
// 	 * \param g The green component of the color (0..255)
// 	 * \param b The blue component of the color (0..255)
// 	 *
// 	 * \return Nonzero if the color was successfully set, zero if
// 	 *         if the controller is not enabled of calibration has not
// 	 *         completed yet.
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern int psmove_tracker_set_camera_color(IntPtr tracker, IntPtr move,
// 	        byte r, byte g, byte b);
// 	
// 	/**
// 	 * \brief Query the tracking status of a motion controller
// 	 *
// 	 * This function returns the current tracking status (or calibration
// 	 * status if the controller is not calibrated yet) of a controller.
// 	 *
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 * \param move A valid \ref PSMove handle
// 	 *
// 	 * \return One of the \ref PSMoveTracker_Status values
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern PSMoveTracker_Status psmove_tracker_get_status(IntPtr tracker, IntPtr move);
// 	
// 	/**
// 	 * \brief Retrieve the next image from the camera
// 	 *
// 	 * This function should be called once per main loop iteration (even
// 	 * if multiple controllers are tracked), and will grab the next camera
// 	 * image from the camera input device.
// 	 *
// 	 * This function must be called before psmove_tracker_update().
// 	 *
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern void psmove_tracker_update_image(IntPtr tracker);
// 	
// 	/**
// 	 * \brief Process incoming data and update tracking information
// 	 *
// 	 * This function tracks one or all motion controllers in the camera
// 	 * image, and updates tracking information such as position, radius
// 	 * and camera color.
// 	 *
// 	 * This function must be called after psmove_tracker_update_image().
// 	 *
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 * \param move A valid \ref PSMove handle (to update a single controller)
// 	 *             or \c NULL to update all enabled controllers at once
// 	 *
// 	 * \return Nonzero if tracking was successful, zero otherwise
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern int psmove_tracker_update(IntPtr tracker, IntPtr move);
// 	
// 	/**
// 	 * \brief Draw debugging information onto the current camera image
// 	 *
// 	 * This function has to be called after psmove_tracker_update(), and
// 	 * will annotate the camera image with sphere positions and other
// 	 * information. The camera image will be modified in place, so no
// 	 * call to psmove_tracker_update() should be carried out before the
// 	 * next call to psmove_tracker_update_image().
// 	 *
// 	 * This function is used for demonstration and debugging purposes, in
// 	 * production environments you usually do not want to use it.
// 	 *
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 */
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern void psmove_tracker_annotate(IntPtr tracker);
// 	
// 	/**
// 	 * \brief Get the current camera image as backend-specific pointer
// 	 *
// 	 * This function returns a pointer to the backend-specific camera
// 	 * image. Right now, the only backend supported is OpenCV, so the
// 	 * return value will always be a pointer to an IplImage structure.
// 	 *
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 *
// 	 * \return A pointer to the camera image (currently always an IplImage)
// 	 *         - the caller MUST NOT modify or free the returned object.
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern IntPtr psmove_tracker_get_frame(IntPtr tracker);
// 	
// 	/**
// 	 * \brief Get the current camera image as 24-bit RGB data blob
// 	 *
// 	 * This function converts the internal camera image to a tightly-packed
// 	 * 24-bit RGB image. The \ref PSMoveTrackerRGBImage structure is used
// 	 * to return the image data pointer as well as the width and height of
// 	 * the camera imaged. The size of the image data is 3 * width * height.
// 	 *
// 	 * The returned pixel data pointer points to tracker-internal data, and must
// 	 * not be freed. The returned RGB data will only be valid as long as the
// 	 * tracker exists.
// 	 *
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 * 
// 	 * \return A \ref PSMoveTrackerRGBImage describing the RGB data and size.
// 	 *         The RGB data is owned by the tracker, and must not be freed by
// 	 *         the caller. The return value is valid only for the lifetime of
// 	 *         the tracker object.
// 	 **/
// 	//[DllImport("libpsmoveapi_tracker")]
// 	//public static extern PSMoveTrackerRGBImage psmove_tracker_get_image(IntPtr tracker);
// 	
// 	/**
// 	 * \brief Get the current position and radius of a tracked controller
// 	 *
// 	 * This function obtains the position and radius of a controller in the
// 	 * camera image.
// 	 *
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 * \param move A valid \ref PSMove handle
// 	 * \param x A pointer to store the X part of the position, or \c NULL
// 	 * \param y A pointer to store the Y part of the position, or \c NULL
// 	 * \param radius A pointer to store the controller radius, or \C NULL
// 	 *
// 	 * \return The age of the sensor reading in milliseconds, or -1 on error
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern int psmove_tracker_get_position(IntPtr tracker,
// 	        IntPtr move, ref float x, ref float y, ref float radius);
// 	
// 	/**
// 	 * \brief Get the camera image size for the tracker
// 	 *
// 	 * This function can be used to obtain the real camera image size used
// 	 * by the tracker. This is useful to convert the absolute position and
// 	 * radius values to values relative to the image size if a camera is
// 	 * used for which the size is now known. By default, the PS Eye camera
// 	 * is used with an image size of 640x480.
// 	 *
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 * \param width A pointer to store the width of the camera image
// 	 * \param height A pointer to store the height of the camera image
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern void psmove_tracker_get_size(IntPtr tracker,
// 	        ref int width, ref int height);
// 	
// 	/**
// 	 * \brief Calculate the physical distance (in cm) of the controller
// 	 *
// 	 * Given the radius of the controller in the image (in pixels), this function
// 	 * calculates the physical distance of the controller from the camera (in cm).
// 	 *
// 	 * By default, this function's parameters are set up for the PS Eye camera in
// 	 * wide angle view. You can set different parameters using the function
// 	 * psmove_tracker_set_distance_parameters().
// 	 *
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 * \param radius The radius for which the distance should be calculated, the
// 	 *               radius is returned by psmove_tracker_get_position()
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern float psmove_tracker_distance_from_radius(IntPtr tracker,
// 	        float radius);
// 	
// 	/**
// 	 * \brief Set the parameters for the distance mapping function
// 	 *
// 	 * This function sets the parameters for the Pearson VII distribution
// 	 * function that's used to map radius values to distance values in
// 	 * psmove_tracker_distance_from_radius(). By default, the parameters are
// 	 * set up so that they work well for a PS Eye camera in wide angle mode.
// 	 *
// 	 * The function is defined as in: http://fityk.nieto.pl/model.html
// 	 *
// 	 * distance = height / ((1+((radius-center)/hwhm)^2 * (2^(1/shape)-1)) ^ shape)
// 	 *
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 * \param height The height parameter of the Pearson VII distribution
// 	 * \param center The center parameter of the Pearson VII distribution
// 	 * \param hwhm The hwhm parameter of the Pearson VII distribution
// 	 * \param shape The shape parameter of the Pearson VII distribution
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern void psmove_tracker_set_distance_parameters(IntPtr tracker,
// 	        float height, float center, float hwhm, float shape);
// 	
// 	/**
// 	 * \brief Destroy an existing tracker instance and free allocated resources
// 	 *
// 	 * This will shut down the tracker, clean up all state information for
// 	 * tracked controller as well as close the camera device. Return values
// 	 * for functions returning data pointing to internal tracker data structures
// 	 * will become invalid after this function call.
// 	 *
// 	 * \param tracker A valid \ref PSMoveTracker handle
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern void psmove_tracker_free(IntPtr tracker);
// 	
// 	// fusion tracker
// 		
// 	/**
// 	 * \brief Create a new PS Move Fusion object
// 	 *
// 	 * Creates and returns a new \ref PSMoveFusion object.
// 	 *
// 	 * \param tracker The \ref PSMoveTracker instance from which position
// 	 *                information should be obtained
// 	 * \param z_near The Z coordinate of the near clipping plane
// 	 * \param z_far The Z coordinate of the far clipping plane
// 	 *
// 	 * \return A new \ref PSMoveFusion handle or \c NULL on error
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern IntPtr psmove_fusion_new(IntPtr tracker, float z_near, float z_far);
// 	
// 	/**
// 	 * \brief Get a pointer to the 4x4 projection matrix
// 	 *
// 	 * This function returns the OpenGL projection matrix for the camera
// 	 * used. Usually the return value can be loaded directly into the
// 	 * GL_PROJECTION matrix of the user application using glLoadMatrix().
// 	 *
// 	 * \param fusion A valid \ref PSMoveFusion handle
// 	 *
// 	 * \return A pointer to a 16-item (4x4) float array representing
// 	 *         the current projection matrix. The return value is only
// 	 *         valid as long as the \ref PSMoveFusion object exists, the
// 	 *         caller MUST NOT free() the return value.
// 	 **/
// 	//[DllImport("libpsmoveapi_tracker")]
// 	//public static extern float * psmove_fusion_get_projection_matrix(IntPtr fusion);
// 	
// 	/**
// 	 * \brief Get a pointer to the 4x4 model-view matrix for a controller
// 	 *
// 	 * This function returns the OpenGL model-view matrix for one motion
// 	 * controller. The coordinate system origin is at the center of the
// 	 * sphere, aligned with the controller. The returned matrix therefore
// 	 * describes both the position and orientation of the controller in 3D
// 	 * space. Usually the return value can be loaded directly into the
// 	 * GL_MODELVIEW matrix of the user application using glLoadMatrix().
// 	 *
// 	 * \param fusion A valid \ref PSMoveFusion handle
// 	 * \param move A valid \ref PSMove handle
// 	 *
// 	 * \return A pointer to a 16-item (4x4) float array representing
// 	 *         the modelview matrix for the controller. The return value
// 	 *         is only valid as long as the \ref PSMoveFusion object
// 	 *         exists, the caller MUST NOT free() the return value.
// 	 **/
// 	//public static extern float * psmove_fusion_get_modelview_matrix(IntPtr fusion, IntPtr move);
// 	
// 	/**
// 	 * \brief Get the 3D position of a controller
// 	 *
// 	 * This function returns the 3D position (relative to the camera)
// 	 * of the motion controller, based on the current projection matrix.
// 	 *
// 	 * \param fusion A valid \ref PSMoveFusion handle
// 	 * \param move A valid \ref PSMove handle
// 	 * \param x A pointer to store the X part of the position vector
// 	 * \param y A pointer to store the Y part of the position vector
// 	 * \param z A pointer to store the Z part of the position vector
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern void psmove_fusion_get_position(IntPtr fusion, IntPtr move,
// 	        ref float x, ref float y, ref float z);
// 	
// 	/**
// 	 * \brief Destroy an existing fusion instance and free allocated resources
// 	 *
// 	 * \param fusion A valid \ref PSMoveFusion handle
// 	 **/
// 	[DllImport("libpsmoveapi_tracker")]
// 	public static extern void psmove_fusion_free(IntPtr fusion);
// 	
// 	#endregion
// }
//
