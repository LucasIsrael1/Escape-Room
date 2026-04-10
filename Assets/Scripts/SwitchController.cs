using UnityEngine;

public class SwitchController : MonoBehaviour
{
    [SerializeField] private int neededSwitches;
    [SerializeField] private MovableBlock block;
    private int pressedSwitches = 0;

    public void SwitchPressed()
    {
        pressedSwitches += 1;
        if (pressedSwitches >= neededSwitches)
        {
            block.Activate();
        }
    }

    public void SwitchUnpressed()
    {
        if (pressedSwitches == neededSwitches)
        {
            block.Deactivate();
        }
        pressedSwitches -= 1;
    }
}
