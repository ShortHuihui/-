using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMsg : BaseMsg
{
    public int playerID;
    public PlayerData playerData;
    public override int GetBytesNum()
    {
        //���һ����ϢID�ĳ���
        //���һ����Ϣ��ĳ���
        return 4 + 4 + 4 + playerData.GetBytesNum();

    }
    public override byte[] Writing()
    {
        int index = 0;
        int bytesNum = GetBytesNum();
        byte[] bytes = new byte[bytesNum];
        //��д��ϢID
        WriteInt(bytes, GetID(), ref index);
        //��д��Ϣ�峤��(���Ȳ�������ϢID����Ϣ�峤������������)
        WriteInt(bytes,bytesNum - 8,ref index);
        //��д��Ϣ�ĳ�Ա����
        WriteInt(bytes,playerID,ref index);
        WriteData(bytes, playerData, ref index);
        return bytes;
    }

    public override int Reading(byte[] bytes, int beginIndex = 0)
    {
        //��Ϊ�ڷ����л�֮ǰ�ͽ�������ID�������ж�ʹ����һ������з����л�
        int index = beginIndex;
        playerID = ReadInt(bytes,ref index);
        playerData = ReadData<PlayerData>(bytes, ref index);
        return index - beginIndex;
    }
    public override int GetID()
    {
        return 1001;
    }
}
