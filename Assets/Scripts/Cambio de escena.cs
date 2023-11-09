using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambiodeescena : MonoBehaviour
{

    public void ChangeSceneMainMenu()
    {
        SceneManager.LoadScene(0); //Menú principal
    }

    public void ChangeSceneGame() //Escena del juego, indice 1
    {
        SceneManager.LoadScene(1);
    }
}
