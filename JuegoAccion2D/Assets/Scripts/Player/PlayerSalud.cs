using UnityEngine;

public class PlayerSalud : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private ConfiguracionPlayer configPlayer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RecibirDa�o(1f);
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

    public void RecibirDa�o(float cantidad)
    {
        if(configPlayer.Armadura > 0)
        {
            float da�oRestante = cantidad - configPlayer.Armadura;
            configPlayer.Armadura = Mathf.Max(configPlayer.Armadura - cantidad, 0f);
            if(da�oRestante > 0)
            {
                configPlayer.SaludActual = Mathf.Max(configPlayer.SaludActual - da�oRestante, 0f);
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
