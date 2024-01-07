using TMPro;

namespace SevenDwarfs.Kamishibai
{
    public class TextController
    {
        private readonly TextMeshProUGUI textMesh;

        public TextController(TextMeshProUGUI textMesh)
        {
            this.textMesh = textMesh;
        }

        public void ReadScenario(ScenarioData data)
        {
            textMesh.text = data.text;
        }
    }
}
