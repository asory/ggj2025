using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI textMeshPro;
    private  Explotingbubbles scriptB;

    private int scoreBubble;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreBubble = Explotingbubbles.score;

        textMeshPro.text = scoreBubble.ToString();
    }
}
