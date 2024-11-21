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
    private Vector2 _rotationDir;

    
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
            
            Vector3 mousePos = Mouse.current.position.ReadValue(); //On récupère la position de la souris
            
            Ray ray = Camera.main.ScreenPointToRay(mousePos); //On envoie un raycast depuis la position de la souris
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                Vector2 hitPos = new Vector2(hit.point.x - _rb.position.x, -(hit.point.z - _rb.position.z)); //On récupère l'endroit où le raycast a touché quelque chose. On retire ensuite la position du joueur pour en faire l'origine du vecteur (il part du joueur pour aller vers le point où le raycast a touché). Obligé de passer y en négatif car sinon le player tourne dans le mauvais sens
                
                float angle = Mathf.Atan2(hitPos.y, hitPos.x) * Mathf.Rad2Deg + 90f; //On récupère l'angle du vecteur par rapport à l'origine
                _rb.rotation = Quaternion.Euler(0, angle , 0); //On ajoute l'angle récupéré plus tôt
            }

            #endregion

        }
}
