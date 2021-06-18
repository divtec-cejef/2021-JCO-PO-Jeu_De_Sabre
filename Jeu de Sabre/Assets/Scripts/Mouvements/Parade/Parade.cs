using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class Parade
{
    private Player.Joueur player;
    
    /* Si le joueur est en parade */
    private bool isParade;
    /* Si sa parade à été annulé */
    private bool isCanceled;
    /* Si le joueur est prêt pour une nouvelle parade */
    private bool isReady = true;

    private GameObject FXParade_1;
    private GameObject FXParade_2;
    private GameObject FXParadePos;

    private GameObject katanaAxis;

    private Vector3 defaultPos;
    private Vector3 tremblement;
    
    private float timerParade;
    private float cooldownParade;

    private GameObject fxEffect1;
    private GameObject fxEffect2;
    
    
    public Parade(float timerParade, float cooldownParade, GameObject fx1, GameObject fx2, GameObject fxPos, GameObject katanaAxis, Player.Joueur player)
    {
        this.timerParade = timerParade;
        this.cooldownParade = cooldownParade;
        FXParade_1 = fx1;
        FXParade_2 = fx2;
        FXParadePos = fxPos;
        this.katanaAxis = katanaAxis;
        this.player = player;
    }

    /// <summary>
    /// Vérification et activation de la parade, active aussi tout les effets secondaires liés à la parade
    /// </summary>
    /// <param name="quaternion">Quaternion représentant l'orientation du sabre</param>
    /// <param name="axeX">AxeX de l'orientation du PSMove</param>
    /// <param name="axeZ">AxeZ de l'orientation du PSMove</param>
    /// <param name="axeY">AxeZ de l'orientation du PSMove</param>
    /// <param name="ow">Orientation W du PSMove</param>
    public void onParadeEnabled(ref Quaternion quaternion, float axeX, float axeZ, float axeY, float ow, Color parryColor)
    {
        if (!isCanceled && isReady)
        {
            if (!isParade)
            {
               PSMoveUtils.setLED(player, parryColor);
               var rotation = FXParadePos.transform.rotation;
               var position = FXParadePos.transform.position;
               fxEffect1 = MonoBehaviour.Instantiate(FXParade_1, position, rotation);
               fxEffect2 = MonoBehaviour.Instantiate(FXParade_2, position, rotation);

               quaternion = new Quaternion(axeX, axeZ, axeY, ow);
               katanaAxis.transform.rotation = quaternion;
               
               PSMoveUtils.setVibration(player, 255);
               defaultPos = katanaAxis.transform.position;
            }

            //MonoBehaviour.print("Parade " + quaternion);
            
            // katanaAxis.transform.position = tremblement;
            //
            // if (tremblement.magnitude <= katanaAxis.transform.position.magnitude + 0.1 &&
            //     tremblement.magnitude >= katanaAxis.transform.position.magnitude - 0.1)
            // {
            //     katanaAxis.transform.position = Random.insideUnitSphere * 0.025f;
            // }
            //
            // tremblement.x = Mathf.SmoothStep(tremblement.x, katanaAxis.transform.position.x, Time.deltaTime * 200.0f);
            // tremblement.y = Mathf.SmoothStep(tremblement.y, katanaAxis.transform.position.y, Time.deltaTime * 200.0f);
            // tremblement.z = Mathf.SmoothStep(tremblement.z, katanaAxis.transform.position.z, Time.deltaTime * 200.0f);
            //
            updateParadeTimer();
            isParade = true;
        }
    }

    /// <summary>
    /// Met à jour le timer
    /// </summary>
    private void updateParadeTimer()
    {
        /* Si le timer n'est pas terminé, décompte du timer */
        if (timerParade > 1.0f)
        {
            timerParade -= Time.deltaTime;

            if (!Player.decreaseStamina(player, 0.2f))
            {
                timerParade = 0;
            }
        }
        /* Si le timer est terminé, annulation de la parade et réinitialisation du timer */
        else
        {
            isCanceled = true;
            timerParade = 3.0f;
            isReady = false;
        }
    }

    
    public void onParadeDisabled()
    {
        if (isParade)
        {
            PSMoveUtils.setLED(player, Color.green);
            timerParade = 3.0f;
            isCanceled = false;
            PSMoveUtils.setVibration(player, 0);
            MonoBehaviour.Destroy(fxEffect1);
            MonoBehaviour.Destroy(fxEffect2);
            isReady = false;
            katanaAxis.transform.position = defaultPos;
        }
        isParade = false;
    }

    public void updateParadeCooldown()
    {
        /* Si le joueur n'est pas prêt à executer une parade et qu'un n'est pas déjà en parade */
        if (!isReady && !isParade)
        {
            /* Si le timer n'est pas terminé, décompte du timer */
            if (cooldownParade > 1.0f)
            {
                cooldownParade -= Time.deltaTime;
            }
            /* Si le timer est terminé, réactivation de la parade et réinitialisation du cooldown*/
            else
            {
                isReady = true;
                cooldownParade = 5.0f;
            }
        }
    }

    public bool getParade()
    {
        return isParade;
    }
    
    public bool getCanceled()
    {
        return isCanceled;
    }
    public bool getReady()
    {
        return isReady;
    }
}
