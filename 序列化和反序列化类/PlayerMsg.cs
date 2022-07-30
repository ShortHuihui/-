using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMsg : BaseMsg
{
    public int playerID;
    public PlayerData playerData;
    public override int GetBytesNum()
    {
        //添加一个消息ID的长度
        //添加一个消息体的长度
        return 4 + 4 + 4 + playerData.GetBytesNum();

    }
    public override byte[] Writing()
    {
        int index = 0;
        int bytesNum = GetBytesNum();
        byte[] bytes = new byte[bytesNum];
        //先写消息ID
        WriteInt(bytes, GetID(), ref index);
        //在写消息体长度(长度不包含消息ID和消息体长度这两个数据)
        WriteInt(bytes,bytesNum - 8,ref index);
        //在写消息的成员变量
        WriteInt(bytes,playerID,ref index);
        WriteData(bytes, playerData, ref index);
        return bytes;
    }

    public override int Reading(byte[] bytes, int beginIndex = 0)
    {
        //因为在反序列化之前就解析出了ID，用来判断使用哪一个类进行反序列化
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
