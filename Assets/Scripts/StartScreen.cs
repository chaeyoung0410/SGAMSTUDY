using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    private GUIStyle titleStyle;
    private GUIStyle instructionStyle;

    private void OnGUI()
    {
        if (titleStyle == null)
        {
            titleStyle = new GUIStyle(GUI.skin.label);
            titleStyle.fontSize = 42;
            titleStyle.alignment = TextAnchor.MiddleCenter;
            titleStyle.normal.textColor = Color.white;

            instructionStyle = new GUIStyle(titleStyle);
            instructionStyle.fontSize = 24;
        }

        GUI.Label(new Rect(0f, Screen.height * 0.32f, Screen.width, 70f), "SHOOTING GAME", titleStyle);
        GUI.Label(new Rect(0f, Screen.height * 0.52f, Screen.width, 50f), "화면을 클릭하면 게임 시작", instructionStyle);

        if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
