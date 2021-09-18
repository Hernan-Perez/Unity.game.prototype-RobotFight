using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsAnimada
{
    private static string path1 = "Images/SciFi/CGY_4K_UltraHD_Interface_1A";
    private static string path2 = "Images/SciFi/CGY_4K_UltraHD_Interface_1A_Glow_1";
    private static string path3 = "Images/SciFi/CGY_4K_UltraHD_Interface_1A_Glow_2";

    private Texture[] bg;
    private Rect r;
    private const float velCambio = 1f;
    private float timer;
    private int fase;

    public WindowsAnimada(Rect _r)
    {
        bg = new Texture[3];
        bg[0] = Resources.Load(path1) as Texture;
        bg[1] = Resources.Load(path2) as Texture;
        bg[2] = Resources.Load(path3) as Texture;
        r = _r;
        timer = 0;
        fase = 0;
    }

    /// <summary>
    /// Actualiza la posicion del background animado.
    /// </summary>
    /*public void Update()
    {

    }*/

    /// <summary>
    /// Actualiza la posicion del background animado.
    /// </summary>
    public void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer > velCambio)
        {
            timer -= velCambio;
            fase++;
            if (fase > 2)
                fase = 0;
        }
    }

    /// <summary>
    /// Dibuja el background animado. Llamar desde OnGUI().
    /// </summary>
    public void Draw()
    {
        //GUI.Box(r, "");
        GUI.Box(r, "");
        GUI.DrawTexture(r, bg[fase], ScaleMode.StretchToFill);
    }
}
