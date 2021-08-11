using System;
using System.Collections;
using System.Collections.Generic;
using Init;
using Mouvements.Orientation;
using TMPro;
using UnityEngine;

public class DebugScreen : MonoBehaviour
{
    public GameObject debugMenuUi;
    public TextMeshProUGUI frameRate;
    public TextMeshProUGUI stamina1;
    public TextMeshProUGUI stamina2;
    public TextMeshProUGUI isParade1;
    public TextMeshProUGUI isParade2;
    public TextMeshProUGUI isReady1;
    public TextMeshProUGUI isReady2;
    public TextMeshProUGUI paradeTimer1;
    public TextMeshProUGUI paradeTimer2;
    public TextMeshProUGUI cooldownTimer1;
    public TextMeshProUGUI cooldownTimer2;
    public TextMeshProUGUI psMoveOrientation1;
    public TextMeshProUGUI psMoveOrientation2;
    public TextMeshProUGUI katanaOrientation1;
    public TextMeshProUGUI katanaOrientation2;
    public TextMeshProUGUI screenCountText;
    
    public static int screenCount;

    private float time = 0.0f;
    private int frame;
    private int fps;
    private bool isDebugMenuOn = false;

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.F3))
        // {
        //     if (!isDebugMenuOn)
        //         LoadDebugMenu();
        //     else
        //         UnloadDebugMenu();
        // }
        //
        // KatanaOrientation orientation1 = GameInit.getKatanaPlayer1();
        // KatanaOrientation orientation2 = GameInit.getKatanaPlayer2();
        //
        // stamina1.text = Player.getStamina(Player.Joueur.P1).ToString();
        // stamina2.text = Player.getStamina(Player.Joueur.P2).ToString();
        //
        // isParade1.text = orientation1.getParade().getParade().ToString();
        // isParade2.text = orientation2.getParade().getParade().ToString();
        //
        // isReady1.text = orientation1.getParade().getReady().ToString();
        // isReady2.text = orientation2.getParade().getReady().ToString();
        //
        // paradeTimer1.text = orientation1.getParade().getParadeTimer().ToString();
        // paradeTimer2.text = orientation2.getParade().getParadeTimer().ToString();
        // //
        // // cooldownTimer1.text = orientation1.getParade().getCooldownTimer().ToString();
        // // cooldownTimer2.text = orientation2.getParade().getCooldownTimer().ToString();
        //
        // katanaOrientation1.text = orientation1.getCurrentQuaternion().ToString();
        // katanaOrientation2.text = orientation2.getCurrentQuaternion().ToString();
        //
        // frameRate.text = fps.ToString();
        //
        // if (time > 1.0f)
        // {
        //     fps = frame;
        //     frame = 0;
        //     time = 0;
        // }
        // else
        // {
        //     time += Time.deltaTime;
        //     frame++;
        // }
    }

    private void Awake()
    {
        screenCountText.text = Display.displays.Length.ToString();
    }

    private void LoadDebugMenu()
    {
        debugMenuUi.SetActive(true);
        isDebugMenuOn = true;
    }

    private void UnloadDebugMenu()
    {
        debugMenuUi.SetActive(false);
        isDebugMenuOn = false;
    }
}
