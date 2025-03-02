using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamante : MonoBehaviour
{
    void OnTriggerEnter2D(collider2D other)
    {
        if (other.CompareTag("Jogador")) //Verifica se foi o jogador que tocou no diamante.
        {
            FindObjectType<SpawnarDiamante>().DiamantesColetados(); //Notifica o spawner que coletou um diamante.
            Destroy(gameObject); //Destroi o diamante coletado.
        }
    }
}
