using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    private enum Menu { Main, Career};
    private Menu currentMenu = Menu.Main;

    private BackgroundAnimado bg;
    private Texture titulo;
    private WindowsAnimada wa;
    private Font font;
    private GUIStyle label, button;
    private AudioClip buttonPress;
    //private AudioClip buttonHover;
    private AudioSource aSo;

	// Use this for initialization
	void Start () {
        bg = new BackgroundAnimado();
        titulo = Resources.Load("Images/title") as Texture;
        //wa = new WindowsAnimada(new Rect(Screen.width * 0.30f, Screen.height * 0.25f, Screen.width * 0.40f, Screen.height * 0.70f));
        wa = new WindowsAnimada(new Rect(Screen.width * 0f, Screen.height * 0f, Screen.width, Screen.height));
        font = Resources.Load("Fonts/robotech-gp/ROBOTECH_GP") as Font;

        label = new GUIStyle("label");
        label.font = font;
        button = new GUIStyle("button");
        button.normal.background = Resources.Load("Images/Button/button0") as Texture2D;
        button.hover.background = Resources.Load("Images/Button/button0_hover") as Texture2D;
        button.active.background = Resources.Load("Images/Button/button0_action") as Texture2D;
        button.font = font;
        button.alignment = TextAnchor.MiddleCenter;
        button.normal.textColor = Color.black;
        button.fontSize = UTIL.TextoProporcion(38);

        buttonPress = Resources.Load("Sounds/Button_6_Pack2") as AudioClip;
        aSo = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        //bg.Update();
        
	}

    private void FixedUpdate()
    {
        bg.FixedUpdate();
        wa.FixedUpdate();
    }

    private void OnGUI()
    {
        bg.Draw();
        wa.Draw();

        GUI.DrawTexture(new Rect(Screen.width * 0.30f, Screen.height * 0.075f, Screen.width * 0.4f, Screen.height * 0.165f), titulo);//, ScaleMode.ScaleAndCrop);

        switch (currentMenu)
        {
            case Menu.Main:

                if (GUI.Button(new Rect(Screen.width * 0.38f, Screen.height * 0.30f, Screen.width * 0.24f, Screen.height * 0.075f), "Career Mode", button))
                {
                    PlaySound(0);
                    currentMenu = Menu.Career;
                }
                if (GUI.Button(new Rect(Screen.width * 0.38f, Screen.height * 0.40f, Screen.width * 0.24f, Screen.height * 0.075f), "Quick Fight", button))
                {
                    PlaySound(0);
                    SceneManager.LoadScene(1);
                }
                if (GUI.Button(new Rect(Screen.width * 0.38f, Screen.height * 0.50f, Screen.width * 0.24f, Screen.height * 0.075f), "Tutorial", button))
                {
                    PlaySound(0);
                }
                if (GUI.Button(new Rect(Screen.width * 0.38f, Screen.height * 0.60f, Screen.width * 0.24f, Screen.height * 0.075f), "Options", button))
                {
                    PlaySound(0);
                }
                if (GUI.Button(new Rect(Screen.width * 0.38f, Screen.height * 0.70f, Screen.width * 0.24f, Screen.height * 0.075f), "Help", button))
                {
                    PlaySound(0);
                }
                if (GUI.Button(new Rect(Screen.width * 0.38f, Screen.height * 0.80f, Screen.width * 0.24f, Screen.height * 0.075f), "Exit", button))
                {
                    PlaySound(0);
                    Application.Quit();
                }
                break;
            case Menu.Career:

                if (GUI.Button(new Rect(Screen.width * 0.38f, Screen.height * 0.30f, Screen.width * 0.24f, Screen.height * 0.075f), "Tournaments", button))
                {
                    PlaySound(0);
                }
                if (GUI.Button(new Rect(Screen.width * 0.38f, Screen.height * 0.40f, Screen.width * 0.24f, Screen.height * 0.075f), "Practice", button))
                {
                    PlaySound(0);
                }
                if (GUI.Button(new Rect(Screen.width * 0.38f, Screen.height * 0.50f, Screen.width * 0.24f, Screen.height * 0.075f), "My Robots", button))
                {
                    PlaySound(0);
                }
                if (GUI.Button(new Rect(Screen.width * 0.38f, Screen.height * 0.60f, Screen.width * 0.24f, Screen.height * 0.075f), "Profile", button))
                {
                    PlaySound(0);
                }
                if (GUI.Button(new Rect(Screen.width * 0.38f, Screen.height * 0.80f, Screen.width * 0.24f, Screen.height * 0.075f), "Back", button))
                {
                    PlaySound(0);
                    currentMenu = Menu.Main;
                }
                break;
        }
        
    }

    private void PlaySound(int index)
    {
        switch (index)
        {
            case 0:
                aSo.PlayOneShot(buttonPress);
                break;

        }
    }
}
