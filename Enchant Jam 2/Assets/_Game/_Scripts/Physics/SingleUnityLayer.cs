using UnityEngine;

[System.Serializable]
public class SingleUnityLayer
{ 
    [SerializeField] private int _layerIndex = 0;
    public int Index
    {
        get { return _layerIndex; }
    }

    public void Set(int index)
    {
        if (index > 0 && index < 32)
        {
            _layerIndex = index;
        }
    }

    public int Mask
    {
        get { return 1 << _layerIndex; }
    }
}