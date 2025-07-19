using AbilitySystem;

public class WhileEffect : Effect
{
    private void Start()
    {
        _text.text = "while"; 
    }
    
    protected override void OnAddEffect()
    {
        AbilityManager.Instance.Shields++;
    }
}
