using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovimiento : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float velocidadMovimiento;

    [Header("Dash")]
    [SerializeField] private float velocidadDash;
    [SerializeField] private float tiempodash;
    [SerializeField] private float transparencia;


    private Rigidbody2D rb2D;
    private PlayerAcciones acciones;
    private SpriteRenderer SpriteRenderer;

    private bool usandoDash;
    private float velocidadActual;
    private Vector2 direccionMovimiento;

    private void Awake()
    {
        acciones = new PlayerAcciones();
        rb2D = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponentInChildren<SpriteRenderer>();

    }

    private void Start()
    {
        velocidadActual = velocidadMovimiento;
        acciones.Movimiento.Dash.performed += ctx => Dash();
    }
    private void Update()
    {
        CapturarInput();
        RotarPlayer();
    }
    private void FixedUpdate()
    {
        MoverPlayer();
    }


    private void MoverPlayer()
    {
        rb2D.MovePosition(rb2D.position + direccionMovimiento * (velocidadActual * 
            Time.fixedDeltaTime));
    }

    private void Dash()
    {
        if (usandoDash)
        {
            return;
        }
        usandoDash = true;
        StartCoroutine(IEDash());
    }

    private IEnumerator IEDash()
    {
        velocidadActual = velocidadDash;
        ModificarSpriteRenderer(transparencia);
        yield return new WaitForSeconds(tiempodash);
        ModificarSpriteRenderer(1f);
        velocidadActual = velocidadMovimiento;
        usandoDash = false;

    }

    private void ModificarSpriteRenderer(float valor)
    {
        Color color = SpriteRenderer.color;
        color = new Color(color.r, color.g, color.b, valor);
        SpriteRenderer.color = color;
    }
    private void RotarPlayer()
    {
        if (direccionMovimiento.x >= 0.1f)
        {
            SpriteRenderer.flipX = false;
        }
        else if (direccionMovimiento.x < 0f)
        {
            SpriteRenderer.flipX = true;
        }
    }
    private void CapturarInput()
    {
        direccionMovimiento = acciones.Movimiento.Mover.ReadValue<Vector2>().normalized;
    }

    private void OnEnable()
    {
        acciones.Enable();
    }

    private void OnDisable()
    {
        acciones.Disable();
    }

}
