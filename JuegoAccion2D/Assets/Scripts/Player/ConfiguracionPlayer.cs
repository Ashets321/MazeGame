using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ConfiguracionPlayer : ScriptableObject
{
    [Header("Datos")]
    public int Nivel;
    public string Nombre;
    public Sprite icono;

    [Header("Valores")]
    public float SaludActual;
    public float SaludMax;
    public float Armadura;
    public float ArmaduraMax;
    public float Energia;
    public float EnergiaMax;
    public float ChanceCritico;
    public float DañoCritico;

}
