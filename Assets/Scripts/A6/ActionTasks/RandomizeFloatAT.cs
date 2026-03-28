using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class RandomizeFloatAT : ActionTask {

		public BBParameter<float> valueBBP;
		public float min, max;

		protected override void OnExecute() {
			valueBBP.value = Random.Range(min, max);
			EndAction(true);
		}
	}
}