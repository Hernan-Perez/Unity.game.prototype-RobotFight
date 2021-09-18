using UnityEngine;
using System.Collections;


public static class UTIL
{
	public static int TextoProporcion(int size)
	{
		size = (int)((float)size * ((float)Screen.height/750.0f));
		return size;
	}

    public static bool valorEnRango(float value, float min, float max)
    {
        return (value > min) && (value <= max);
    }

    public static GameObject getChildGameObjectByTag(GameObject go, string tag)
    {
        GameObject aux = null;

        for (int i = 0; i < go.transform.childCount; i++)
        {
            //si el tag coincide
            if (go.transform.GetChild(i).tag == tag)
            {
                aux = go.transform.GetChild(i).gameObject;
            }
            else
            {
                //llama a la misma funcion en forma recursiva para ver los hijos de los hijos si es que los hay
                aux = getChildGameObjectByTag(aux, tag);
            }

            if (aux != null)
                break;
        }

        return aux;
    }
}
