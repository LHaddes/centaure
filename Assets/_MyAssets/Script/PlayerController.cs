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
    private Vector3 _rotationDir;

    
     private void Awake()
        {
            Instance = this;
        }
    
     void Start()
        {
            //On récupère tous les components dont on a besoin
            _rb = GetComponent<Rigidbody>();
            _playerInput = GetComponent<PlayerInput>();

        }
    
        public void Move(InputAction.CallbackContext context)
        {
            Vector2 v = context.ReadValue<Vector2>();
            //Récupération Input pour se déplacer (ZQSD ou Joystick gauche)
            _movementDir = new Vector3(v.x, 0, v.y);
            
        }

        
    
        private void FixedUpdate()
        {
            #region Movement
    
            //Déplacement à vitesse normale
            _rb.MovePosition(_rb.position + _movementDir * speed * Time.fixedDeltaTime);

            #endregion

            #region Direction
           
    
            //_rotationDir = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()); NE FONCTIONNE PAS => RENVOIE LA POSITION DE LA CAMERA
            // ESSAYEZ SOIT: RAYCAST AVEC LA CAMERA, CONTINUEZ SUR CETTE METHODE EN TROUVANT LES BONNES VAR, ...
            
            //Debug.Log(_rotationDir);

           // Vector3 frontDir = new Vector3(_rotationDir.x - transform.position.x, 0f,
                //_rotationDir.y - transform.position.z);
                
            
            
            //float angleRadians = Mathf.Atan2(frontDir.y, frontDir.x) * Mathf.Rad2Deg - 90f;
            //_rb.rotation = Quaternion.Euler(0f, 0f, angleRadians);

            #endregion

        }
}
