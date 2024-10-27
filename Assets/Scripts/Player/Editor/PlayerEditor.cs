using UnityEditor;

namespace Assets.Scripts.Player.Editor
{
    [CustomEditor(typeof(PlayerManager))]
    public class PlayerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI() 
        {
            base.OnInspectorGUI();
        }
    }
}
