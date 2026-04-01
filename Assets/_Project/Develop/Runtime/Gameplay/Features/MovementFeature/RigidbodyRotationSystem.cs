using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;


namespace Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
	public class RigidbodyRotationSystem : IInitializableSystem, IUpdatableSystem
	{
		private ReactiveVariable<Vector3> _moveDirection;
		private Rigidbody                 _rigidbody;

		public void OnInit (Entity entity)
		{
			_moveDirection = entity.MoveDirection;
			_rigidbody = entity.Rigidbody;
		}

		public void OnUpdate (float deltaTime)
		{
				if (_moveDirection.Value != Vector3.zero)
				{
						_rigidbody.MoveRotation(Quaternion.LookRotation(_moveDirection.Value));
				}
		}
	}
}
