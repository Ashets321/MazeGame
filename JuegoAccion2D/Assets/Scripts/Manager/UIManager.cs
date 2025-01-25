using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [Header("Temp")]
    [SerializeField] private ConfiguracionPlayer configPlayer;

    [Header("UI Player")]
    [SerializeField] private Image barraSaludPlayer;
    [SerializeField] private TextMeshProUGUI textoSaludPlayer;
    [SerializeField] private Image barraArmaduraPlayer;
    [SerializeField] private TextMeshProUGUI textoArmaduraPlayer;
    [SerializeField] private Image barraEnergiaPlayer;
    [SerializeField] private TextMeshProUGUI textoEnergiaPlayer;

    private void Update()
    {
        ActualizarUI();
    }
    private void ActualizarUI()
    {
        barraSaludPlayer.fillAmount = Mathf.Lerp(barraSaludPlayer.fillAmount, configPlayer.SaludActual / configPlayer.SaludMax, 10*Time.deltaTime);
        barraArmaduraPlayer.fillAmount = Mathf.Lerp(barraArmaduraPlayer.fillAmount, configPlayer.Armadura / configPlayer.ArmaduraMax, 10*Time.deltaTime);
        barraEnergiaPlayer.fillAmount = Mathf.Lerp(barraEnergiaPlayer.fillAmount, configPlayer.Energia / configPlayer.EnergiaMax, 10*Time.deltaTime);

        textoSaludPlayer.text = $"{configPlayer.SaludActual}/{configPlayer.SaludMax}";
        textoArmaduraPlayer.text = $"{configPlayer.Armadura}/{configPlayer.ArmaduraMax}";
        textoEnergiaPlayer.text = $"{configPlayer.Energia}/{configPlayer.EnergiaMax}";
    }
}
