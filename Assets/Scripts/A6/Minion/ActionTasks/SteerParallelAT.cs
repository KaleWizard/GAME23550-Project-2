using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SteerParallelAT : ActionTask {

        public BBParameter<CharacterControllerInput> controllerBBP;
        public float distance = 2f;

        protected override void OnUpdate()
        {
            Vector3 direction = PlayerManager.PlayerTransform.forward;

            Vector2 input = (new Vector2(direction.x, direction.z)).normalized;
            controllerBBP.value.input = input;
        }
    }
}