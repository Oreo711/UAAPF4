using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay
{
    public class TestGameplay : MonoBehaviour
    {
        private DIContainer _container;
        private EntitiesFactory _entitiesFactory;

        private Entity _rigidbodyEntity;
        private Entity _characterControllerEntity;

        private bool _isRunning;

        public void Initialize(DIContainer container)
        {
            _container = container;
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
        }

        public void Run()
        {
            _rigidbodyEntity = _entitiesFactory.CreateRigidbodyEntity(new Vector3(-1, 0, 0));
            _characterControllerEntity = _entitiesFactory.CreateCharacterControllerEntity(new Vector3(1, 0, 0));
            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false)
                return;

            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            _rigidbodyEntity.MoveDirection.Value = input;
            _characterControllerEntity.MoveDirection.Value = input;
        }
    }
}
