using UnityEngine;

public class PlayerSalud : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private ConfiguracionPlayer configPlayer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RecibirDaņo(1f);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            RecuperarSalud(1f);
        }
    }

    public void RecuperarSalud(float cantidad)
    {
        configPlayer.SaludActual += cantidad;
        if(configPlayer.SaludActual > configPlayer.SaludMax)
        {
            configPlayer.SaludActual = configPlayer.SaludMax;
        }
    }

    public void RecibirDaņo(float cantidad)
    {
        if(configPlayer.Armadura > 0)
        {
            float daņoRestante = cantidad - configPlayer.Armadura;
            configPlayer.Armadura = Mathf.Max(configPlayer.Armadura - cantidad, 0f);
            if(daņoRestante > 0)
            {
                configPlayer.SaludActual = Mathf.Max(configPlayer.SaludActual - daņoRestante, 0f);
            }
        }
        else
        {
            configPlayer.SaludActual = Mathf.Max(configPlayer.SaludActual - cantidad, 0f);
        }
        if(configPlayer.SaludActual <= 0)
        {
            PlayerDerrotado();
        }
    }

    private void PlayerDerrotado()
    {
        Destroy(gameObject);
    }
}
