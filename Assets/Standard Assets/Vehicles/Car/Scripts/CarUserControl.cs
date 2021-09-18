using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        private Rigidbody rb;
        private GUIStyle estilo;
        public Vector3 resetPosition = new Vector3(328.8939f, 17.25f, 388.5278f);
        private GameObject gancho;
        private bool ganchoActivado;
        private bool ganchoVolviendo;
        private float rotacionGancho;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            rb = GetComponent<Rigidbody>();
            estilo = new GUIStyle();
            estilo.normal.textColor = Color.black;
            estilo.fontSize = 36;
            gancho = getChildGameObjectByTag(this.gameObject, "Gancho");// GameObject.FindGameObjectWithTag("Gancho");
        }


        private void FixedUpdate()
        {

            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            if (Math.Abs(v) < 0.1f) v = 0f;
            //Debug.Log(v);
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");

            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif

            if (CrossPlatformInputManager.GetAxis("Reset") != 0f)
            {
                transform.position = resetPosition;
                transform.rotation = new Quaternion();
                rb.angularVelocity = new Vector3();
                rb.velocity = new Vector3();
            }

            if (CrossPlatformInputManager.GetAxis("Fire1") != 0f && gancho != null && !ganchoActivado)
            {
                ganchoActivado = true;
                ganchoVolviendo = false;
                rotacionGancho = 0f;
            }
            float step;
            float valor;

            if (ganchoActivado)
            {
                if (!ganchoVolviendo)
                {
                    step = 500f * Time.deltaTime;
                    valor = rotacionGancho + step;

                    if (valor > 160f)
                    {
                        //step -= valor - 160f;
                        ganchoVolviendo = true;
                        //ganchoActivado = false;
                    }
                    gancho.transform.Rotate(step, 0, 0);
                    rotacionGancho += step;
                }
                else
                {
                    step = 250f * Time.deltaTime;
                    valor = rotacionGancho - step;
                    if (valor < 0f)
                    {
                        step -= valor; 
                        ganchoActivado = false;
                        //Debug.Log(gancho.transform.rotation.eulerAngles.x);
                    }
                    gancho.transform.Rotate(-step, 0, 0);
                    rotacionGancho -= step;

                    if (!ganchoActivado)
                    {
                        gancho.transform.localEulerAngles = new Vector3();
                    }
                }
                //Debug.Log(gancho.transform.rotation.eulerAngles.x);
            }
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(20, 20, 500, 50), (rb.velocity.magnitude * 3.6f).ToString("#0.00") + " km/h", estilo);
        }

        private GameObject getChildGameObjectByTag(GameObject go, string tag)
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
                    aux = getChildGameObjectByTag(go.transform.GetChild(i).gameObject, tag);
                }

                if (aux != null)
                    break;
            }
            return aux;
        }
        
        
    }
}
