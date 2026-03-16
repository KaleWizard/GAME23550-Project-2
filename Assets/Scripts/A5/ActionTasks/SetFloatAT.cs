using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Actions {

	public class SetFloatAT : ActionTask {

		public BBParameter<float> variableBBP;
		public BBParameter<float> valueBBP;

		protected override void OnExecute() {
			variableBBP.value = valueBBP.value;
			EndAction(true);
		}
	}
}