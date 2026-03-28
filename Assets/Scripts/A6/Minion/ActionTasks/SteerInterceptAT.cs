using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SteerInterceptAT : ActionTask {

		public BBParameter<CharacterControllerInput> controllerBBP;
		public float distance = 2f;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			
		}

		protected override void OnUpdate() {
			Transform target = PlayerManager.PlayerTransform;
			Vector3 diff = target.position - agent.transform.position;

			Vector3 direction = diff.normalized / (diff.sqrMagnitude + 0.5f);

			// If behind the target, move in their direction of movement
			// Scale by distance from target (if close, move directly towards target)
			if (Vector3.Dot(diff, target.forward) > 0)
			{
				direction += target.forward * (diff.sqrMagnitude + 0.5f);
			}

			Vector2 input = (new Vector2(direction.x, direction.z)).normalized;
			controllerBBP.value.input = input;
		}
	}
}