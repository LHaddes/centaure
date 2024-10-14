using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;
    
    private Rigidbody _rb;

    public static PlayerController Instance;
    
    [Header("Parameters - Movement")]
    [Tooltip("Normal speed")] public float speed;

    private Vector3 _movementDir;

    
     private void Awake()
        {
            Instance = this;
        }
    
     void Start()
        {
            //On récupère tous les components dont on a besoin
            _rb = GetComponent<Rigidbody>();
            _playerInput = GetComponent<PlayerInput>();

            //Debug.Log(_playerInput.actions.controlSchemes);
        }
    
        public void Move(InputAction.CallbackContext context)
        {
            Vector2 v = context.ReadValue<Vector2>();
            //Récupération Input pour se déplacer (ZQSD ou Joystick gauche)
            _movementDir = new Vector3(v.x, 0, v.y);
            Debug.Log("movement");
        }
        
    
        private void FixedUpdate()
        {
            #region Movement
    
            //Déplacement à vitesse normale
            _rb.MovePosition(_rb.position + _movementDir * speed * Time.fixedDeltaTime);
            //rb.velocity = _movementDir * speed;

            #endregion
            
        }
}
