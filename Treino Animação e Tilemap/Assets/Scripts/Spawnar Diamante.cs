using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnarDiamante : MonoBehaviour
{
    public GameObject diamantePrefab; //Prefab do diamante.
    public int contadorDiamantes = 10; //Quantidade inicial de diamantes na cena.
    public float tempoLimite = 60f; //Tempo inicial de jogo.
    public float timer; //Timer onde aparece o tempo
    private int diamantesColetados = 0; //Registro de quantos diamantes foram pegos.

    void Start()
    {
        SpawnarDiamantes();
        timer = tempoLimite;
        StartCoroutine(CountdownTimer()); 
    }

    void SpawnarDiamantes()
    {
        for (int i = 0; i < contadorDiamantes; i++)
        {
            Vector2 randomPosition = GetRandomPosition();
            Instantiate(diamantePrefab, randomPosition, Quaternion.identity);
        }
    }


    private Vector2 GetRandomPosition()
    {
        //Pega a área do BoxCollider2D para spawnar novos diamantes na cena.
        Bounds bounds = GetComponent<BoxCollider2D>().bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        return new Vector2(x, y);
    }

    //Cuida do tempo de coleta do diamante.
    IEnumerator CountdownTimer()
    {
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        GameOver();
    }

    //Verifica de todos os diaamantes na cena foram coletados
    public void DiamantesColetados()
    {
        diamantesColetados++;
        if (diamantesColetados >= contadorDiamantes)
        {
            //Se coletou todos os diamantes  antes do tempo acabar
            contadorDiamantes += 5;
            tempoLimite -= 10;
            diamantesColetados = 0;
            timer = tempoLimite;
            SpawnarDiamantes();  
        }
    }

    //Referência o game over
    void GameOver()
    {
        Debug.Log("Game Over !!! Criar tela depois.");
        //Depois chamar a tela de game over.
    }
        

}
