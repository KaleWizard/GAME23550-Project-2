using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions {

	public class CompareFloatCT : ConditionTask {

		public BBParameter<float> aBBP;
		public BBParameter<float> bBBP;
		public bool isGreater = false;

		protected override bool OnCheck() {
			return isGreater?
				aBBP.value > bBBP.value :
				aBBP.value < bBBP.value;
		}
	}
}