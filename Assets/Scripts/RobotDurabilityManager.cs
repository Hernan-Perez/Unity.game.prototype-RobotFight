using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotDurabilityManager : MonoBehaviour {

    public enum tipoCollider {Chasis, Front, Back };
    public tipoCollider _tipoCollider = tipoCollider.Chasis;

    public int hp, hpMax;
    public float coeficienteDestruccion = 1f;


	// Use this for initialization
	void Start () {
        hpMax = 100;
        hp = hpMax;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(_tipoCollider + ":  " + collision.collider.tag + "  " + collision.impulse.magnitude);
    }
}
