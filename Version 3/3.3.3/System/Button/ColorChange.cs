using UnityEngine;
using UnityEngine.UI;
public class ColorChange : MonoBehaviour
{
    [SerializeField] private Image Window;
    [SerializeField] [Range(0.0f, 1.0f)] private float _colorRed;
    [SerializeField] [Range(0.0f, 1.0f)] private float _colorGreen;
    [SerializeField] [Range(0.0f, 1.0f)] private float _colorBlue;
    [SerializeField] [Range(0.0f, 1.0f)] private float _colorAlfa = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Window.color = new Color(_colorRed,_colorGreen,_colorBlue,_colorAlfa);
    }
}
