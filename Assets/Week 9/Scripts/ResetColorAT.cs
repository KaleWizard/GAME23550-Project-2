using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    public class ResetColorAT : ActionTask
    {
        public BBParameter<Renderer> renderer;
        public BBParameter<Color> defaultColor;
        protected override string OnInit()
        {
            defaultColor.value = renderer.value.material.color;
            return null;
        }

        protected override void OnExecute()
        {
            renderer.value.material.color = defaultColor.value;
            EndAction(true);
        }
    }
}