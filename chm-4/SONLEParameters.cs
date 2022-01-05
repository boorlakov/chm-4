namespace chm_4;

public class SONLEParams
{
    public SONLEParams(int funcsNum, int varsNum, string systemName)
    {
        FuncsNum = funcsNum;
        VarsNum = varsNum;
        SystemName = systemName;
    }

    public int FuncsNum { get; }

    public string SystemName { get; }

    public int VarsNum { get; }
}