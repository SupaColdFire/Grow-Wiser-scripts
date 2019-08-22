using System.Linq;
using KG.ScriptableObjects;
using KG.Utility;
using UnityEngine;

namespace KG.Gameplay
{
    [RequireComponent(typeof(InputSystem))]
    [RequireComponent(typeof(AudioManager))]
    [RequireComponent(typeof(ParticleController))]
    public class InteractableObjectsController : MonoBehaviour
    {
        [SerializeField] private InteractablesScriptableObject interactableObjects;
        [SerializeField] private Transform[]                   startingPositions;

        private InputSystem                  _input;
        private AudioManager                 _audioManager;
        private ParticleController           _particleController;
        private InteractableObjectMovement   _activeObject;
        private InteractableObjectMovement[] _activeObjects;
        private bool                         _holdingAnObject;

        public int InteractableObjectCount { get; private set; }

        private void Awake()
        {
            _input = GetComponent<InputSystem>();
            _audioManager = GetComponent<AudioManager>();
            _particleController = GetComponent<ParticleController>();
        }


        private void Start()
        {
            InstantiateInteractableObjects();
        }

        private void InstantiateInteractableObjects()
        {
            InteractableObjectCount = interactableObjects.objectArray.Length;
            _activeObjects = new InteractableObjectMovement[InteractableObjectCount];
            var interactableObjectShuffle =
                new FisherYatesShuffle<GameObject>(interactableObjects.objectArray.ToList());
            for (var i = 0; i < InteractableObjectCount; i++)
            {
                var position = startingPositions[i].position;
                var obj      = Instantiate(interactableObjectShuffle.GetRandomValue(), position, Quaternion.identity);
                _activeObjects[i] = obj.GetComponent<InteractableObjectMovement>();
            }
        }

        public void MoveAndPlaceInteractableObjects()
        {
            if (_input.IsPointerPressed())
            {
                if (!_holdingAnObject)
                {
                    FindAndSetActiveObject();
                }
                else
                {
                    _activeObject.MoveTo(_input.GetPointerPosition());
                }
            }

            else if (_holdingAnObject)
            {
                DropActiveObject();
            }
        }

        private void DropActiveObject()
        {
            if (_activeObject.IsInCorrectPosition())
            {
                PlaceActiveObjectInCorrectPosition();
            }
            else
            {
                _activeObject.MoveTo(_activeObject.GetStartingPosition());
            }

            _activeObject = null;
            _holdingAnObject = false;
        }

        private void FindAndSetActiveObject()
        {
            foreach (var interactableObject in _activeObjects)
            {
                var sqrDistance = (_input.GetPointerPosition() - interactableObject.transform.position)
                    .sqrMagnitude;
                var inRange = sqrDistance < interactableObject.Offset * interactableObject.Offset;
                if (!inRange || interactableObject.IsInCorrectPosition()) continue;
                _holdingAnObject = true;
                _activeObject = interactableObject;
                break;
            }
        }

        private void PlaceActiveObjectInCorrectPosition()
        {
            _activeObject.MoveTo(_activeObject.GetCorrectPosition());
            InteractableObjectCount--;
            _particleController.SpawnParticlesOnObject(_activeObject.GetCorrectPosition());
            _audioManager.PlayCorrectPositionAudio();
        }
    }
}