using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI diamanteTexto; //Referencia a quantidade de diamantes que o jogador pegou, na cena.
    public TextMeshProUGUI timerTexto; //Referencia o timer na cena.
    public SpawnarDiamante spawnarDiamante; //// Referência ao script de spawn dos diamantes.

    

    // Update vai ataulizando as informações em todo frame.
    void Update()
    {
        //Atualiza o texto do diamante.
        diamanteTexto.text = "Diamantes: " + spawnarDiamante.diamantesColetados.ToString();

        //Atualiza o timer.
        timerTexto.text = string.Format("{0:00}", spawnarDiamante.timer);
            //spawnarDiamante.timer.ToString("F2");

    }
}
