using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnimado
{
    //private static string path = "Images/tex/metal4";
    private static string path = "Images/tex/circuit";

    private Texture bg;
    private Rect r1, r2;
    private const float factorMov = 15f;

    public BackgroundAnimado()
    {
        bg = Resources.Load(path) as Texture;
        r1 = new Rect(0f, 0f, Screen.width, Screen.height);
        r2 = new Rect(Screen.width, 0f, Screen.width, Screen.height);
    }

    /// <summary>
    /// Actualiza la posicion del background animado.
    /// </summary>
    /*public void Update()
    {
        float desp = factorMov * Time.deltaTime;
        r1.x -= desp;
        r2.x -= desp;

        if (r1.x < -Screen.width)
            r1.x += Screen.width;

        if (r2.x < -Screen.width)
            r2.x += Screen.width;
    }*/


    /// <summary>
    /// Actualiza la posicion del background animado.
    /// </summary>
    public void FixedUpdate()
    {
        float desp = factorMov * Time.fixedDeltaTime;
        r1.x -= desp;
        r2.x -= desp;

        if (r1.x < -Screen.width)
            r1.x = r2.xMax;

        if (r2.x < -Screen.width)
            r2.x = r1.xMax;
    }

    /// <summary>
    /// Dibuja el background animado. Llamar desde OnGUI().
    /// </summary>
    public void Draw()
    {
        GUI.DrawTexture(r1, bg);//, ScaleMode.ScaleToFit);
        GUI.DrawTexture(r2, bg);//, ScaleMode.ScaleToFit);
    }
}
