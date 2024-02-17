using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class InteractableObject : MonoBehaviour, IInteractable
{

    [SerializeField] private SpriteRenderer _interactSprite;

    private Transform _playerTransform;

    private const float INTERACT_DISTANCE = 1f;

    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && IsWithinInteractDistance())
        {
            //interact
            Interact();
        }

        if(_interactSprite.gameObject.activeSelf && !IsWithinInteractDistance())
        {
            _interactSprite.gameObject.SetActive(false);
        } else if(!_interactSprite.gameObject.activeSelf && IsWithinInteractDistance()) {
            _interactSprite.gameObject.SetActive(true) ;
        }
    }

    //making it abstract so we can override it in other script because we may want different interacting logic
    public abstract void Interact();


    //checking distance player to interactable object
    private bool IsWithinInteractDistance()
    {
        if (Vector2.Distance(_playerTransform.position, transform.position) < INTERACT_DISTANCE)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
