using System.Collections;
using System.Collections.Generic;
using System.Text;

public class PlayerData : BaseData
{
    public string name;
    public int atk;
    public int lv;
    public override int GetBytesNum()
    {
        return sizeof(int) + Encoding.UTF8.GetBytes(name).Length +sizeof(int)+sizeof(int);
    }

    public override int Reading(byte[] bytes, int beginIndex = 0)
    {
        int index = beginIndex;
        name =  ReadString(bytes, ref index);
        atk =  ReadInt(bytes,ref index);
        lv =  ReadInt(bytes,ref index);
        return index - beginIndex;
    }

    public override byte[] Writing()
    {
        int index = 0;
        byte[] bytes = new byte[GetBytesNum()];
        WriteString(bytes, name, ref index);
        WriteInt(bytes,atk,ref index);
        WriteInt(bytes,lv,ref index);
        return bytes;
    }
}
