using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;


namespace Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature
{
	public class TransformRotationSystem : IInitializableSystem, IUpdatableSystem
	{
		private ReactiveVariable<Vector3> _moveDirection;
		private Transform _transform;

		public void OnInit (Entity entity)
		{
			_moveDirection = entity.MoveDirection;
			_transform     = entity.Transform;
		}

		public void OnUpdate (float deltaTime)
		{
			if (_moveDirection.Value != Vector3.zero)
			{
				_transform.rotation = Quaternion.LookRotation(_moveDirection.Value);
			}
		}
	}
}
