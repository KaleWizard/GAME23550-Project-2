using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class IncreaseTimerAT : ActionTask {

		public BBParameter<float> timerBBP;

		protected override void OnUpdate() {
			timerBBP.value += Time.deltaTime;
		}
	}
}