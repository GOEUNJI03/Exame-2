using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    [SerializeField]private AudioSource jump;
    [SerializeField]private AudioSource walk;

    public float CurrentVolumen { get {  return jump.volume; } set { jump.volume = value; walk.volume = value; } }

    public void PlayJump()
    {
        Debug.Log("saltosfx");
        jump.Play();
    }
    public void PlayWalk()
    {
        Debug.Log("caminarsfx");
        walk.Play();
    }
    public void StopWalk()
    {
        Debug.Log("caminarsfxstop");
        walk.Stop();
    }

    /// <summary>
    /// Agregando La abilidad de cambiar el volumen de los effectos de Sonido
    /// </summary>
    public void CambioVolumen(float volumen) 
    {
        jump.volume = volumen;
        walk.volume = volumen;
    }
}
