using System;
using System.Collections;
using System.Collections.Generic;
using Camera;
using MySql.Data.MySqlClient;
using Players;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuActions : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject SettingsMenu;
    [SerializeField] private GameObject LoadingMenu;
    [SerializeField] private GameObject InscriptionMenu;
    
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SfxSlider;
    [SerializeField] private Slider LoadingSlider;


    [SerializeField] private Button player1Red;
    [SerializeField] private Button player1Blue;
    [SerializeField] private Button player1Green;
    [SerializeField] private Button player1Pink;
    [SerializeField] private Button player1Orange;
    [SerializeField] private Button player1Yellow;
    [SerializeField] private Button player1Black;
    [SerializeField] private Button player1White;
    [SerializeField] private Button player1Magenta;
    [SerializeField] private Button player1Brown;
    [SerializeField] private Button player1Cyan;
    [SerializeField] private Button player1Lime;
    
    [SerializeField] private Button player2Red;
    [SerializeField] private Button player2Blue;
    [SerializeField] private Button player2Green;
    [SerializeField] private Button player2Pink;
    [SerializeField] private Button player2Orange;
    [SerializeField] private Button player2Yellow;
    [SerializeField] private Button player2Black;
    [SerializeField] private Button player2White;
    [SerializeField] private Button player2Magenta;
    [SerializeField] private Button player2Brown;
    [SerializeField] private Button player2Cyan;
    [SerializeField] private Button player2Lime;
    
    
    [SerializeField] private Image player1SelectedIcon;
    [SerializeField] private Image player2SelectedIcon;
    
    
    
    [SerializeField] private TextMeshProUGUI LoadingText;

    private bool settings = false;
    private bool inscription = false;

    private int player1Color = 1;
    private int player2Color = 2;

    public static int id1;
    public static int id2;

    public static int musicVolume;
    public static int sfxVolume;

    private List<Button> player1Buttons;
    private List<Button> player2Buttons;

    private void Awake()
    {
        player1Buttons = new List<Button>();
        player1Buttons.Add(player1Red);
        player1Buttons.Add(player1Blue);
        player1Buttons.Add(player1Green);
        player1Buttons.Add(player1Pink);
        player1Buttons.Add(player1Orange);
        player1Buttons.Add(player1Yellow);
        player1Buttons.Add(player1Black);
        player1Buttons.Add(player1White);
        player1Buttons.Add(player1Magenta);
        player1Buttons.Add(player1Brown);
        player1Buttons.Add(player1Cyan);
        player1Buttons.Add(player1Lime);
        
        player2Buttons = new List<Button>();
        player2Buttons.Add(player2Red);
        player2Buttons.Add(player2Blue);
        player2Buttons.Add(player2Green);
        player2Buttons.Add(player2Pink);
        player2Buttons.Add(player2Orange);
        player2Buttons.Add(player2Yellow);
        player2Buttons.Add(player2Black);
        player2Buttons.Add(player2White);
        player2Buttons.Add(player2Magenta);
        player2Buttons.Add(player2Brown);
        player2Buttons.Add(player2Cyan);
        player2Buttons.Add(player2Lime);
        
        // Initialisation de l'affichage sur plusieurs écrans
        print("Intitialisation de l'affichage multiple...");
        gameObject.AddComponent<MultiDisplay>();
    }

    public void StartGame()
    {
        StartCoroutine(LoadGame());
    }

    private IEnumerator LoadGame()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Scenes/Map");

        InscriptionMenu.SetActive(false);
        LoadingMenu.SetActive(true);
        GetData();
        
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            LoadingSlider.value = progress;
            LoadingText.text = (int)(progress * 100f) + "%";
            
            yield return null;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Settings()
    {
        if (settings)
        {
            MainMenu.SetActive(true);
            SettingsMenu.SetActive(false);
            settings = false;
        }
        else
        {
            MainMenu.SetActive(false);
            SettingsMenu.SetActive(true);
            settings = true;

            MusicSlider.value = musicVolume;
            SfxSlider.value = sfxVolume;
        }
    }
    
    public void Inscription()
    {
        if (inscription)
        {
            MainMenu.SetActive(true);
            InscriptionMenu.SetActive(false);
            inscription = false;
        }
        else
        {
            MainMenu.SetActive(false);
            InscriptionMenu.SetActive(true);
            inscription = true;
        }
    }
    
    public void ChangeMusicVolume()
    {
        musicVolume = (int)MusicSlider.value;
    }

    public void ChangeSFXVolume()
    {
        sfxVolume = (int)SfxSlider.value;
    }


    public void SetName1(string s)
    {
        id1 = Int32.Parse(s);
    }

    public void SetName2(string s)
    {
        id2 = Int32.Parse(s);
    }
    
    public void GetData()
    {
    
        string connStr =
            "Database=lacourseauxtrophees;Server=127.0.0.1;Uid=root;Password=Admlocal1;pooling=false;CharSet=utf8;port=3306";
        MySqlConnection conn = new MySqlConnection(connStr);
    
        try
        {
        
            conn.Open();
            MySqlCommand Player1 = conn.CreateCommand();
            Player1.CommandText = "SELECT name_player FROM tb_player WHERE identifiant_player = " + id1 + ";";
            object name1 = Player1.ExecuteScalar();
            
            /*/////////////////////////////////////////////////*/
            
            MySqlCommand Player2 = conn.CreateCommand();
            Player2.CommandText = "SELECT name_player FROM tb_player WHERE identifiant_player = " + id2 + ";";
            object name2 = Player2.ExecuteScalar();
            
            Player.SetPlayerNames(name1.ToString(), name2.ToString());
            
            /*/////////////////////////////////////////////////*/
            
            MySqlCommand Color1 = conn.CreateCommand();
            Color1.CommandText = "SELECT color_player FROM tb_player WHERE identifiant_player = " + id1 + ";";
            object color1 = Color1.ExecuteScalar();
            
            /*/////////////////////////////////////////////////*/
            
            MySqlCommand Color2 = conn.CreateCommand();
            Color2.CommandText = "SELECT color_player FROM tb_player WHERE identifiant_player = " + id2 + ";";
            object color2 = Color2.ExecuteScalar();
            
            Player.SetPlayerColors(Int32.Parse(color1.ToString()), Int32.Parse(color2.ToString()));
        }
        catch (Exception ex)
        {
            print("Id Incorrecte - " + ex);
        }
        conn.Close();
        print("Done.");
    
    }
    
    /* --------- Personnalisation du joueur --------- */

    public void ChangePlayer1Color(int color)
    {
        
        player2Buttons[player1Color - 1].interactable = true;
        player1Color = color;
        player2Buttons[player1Color - 1].interactable = false;
        player1SelectedIcon.rectTransform.localPosition = player1Buttons[player1Color - 1].gameObject.GetComponent<RectTransform>().localPosition;
    }
    
    public void ChangePlayer2Color(int color)
    {
        player1Buttons[player2Color - 1].interactable = true;
        player2Color = color;
        player1Buttons[player2Color - 1].interactable = false;
        player2SelectedIcon.rectTransform.localPosition = player2Buttons[player2Color - 1].gameObject.GetComponent<RectTransform>().localPosition;
    }
    
}
