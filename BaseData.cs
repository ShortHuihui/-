using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public abstract class BaseData
{
    public abstract int GetBytesNum();
    public abstract int Reading(byte [] bytes,int beginIndex = 0);
    public abstract byte []  Writing();

    protected void WriteInt(byte [] bytes,int value,ref int index)
    {
        BitConverter.GetBytes(value).CopyTo(bytes,index);
        index += sizeof(int);
    }

    protected void WriteFloat(byte [] bytes,float value,ref int index)
    {
        BitConverter.GetBytes(value).CopyTo(bytes,index);
        index += sizeof(float);
    }

    protected void WriteBool(byte []bytes,bool value,ref int index)
    {
        BitConverter.GetBytes(value).CopyTo(bytes,index);
        index += sizeof(bool);
    }

    protected void WriteString(byte [] bytes,string value,ref int index)
    {
        //��д�ֽ�����ĳ���
        byte[] strBytes = Encoding.UTF8.GetBytes(value);
        WriteInt(bytes,strBytes.Length, ref index);
        //��д���ֽ����鱾��(һ���ַ�ռһ���ֽ�)
        strBytes.CopyTo(bytes,index);
        index += strBytes.Length;
    }

    protected  void WriteData(byte [] bytes,BaseData data,ref int index)
    {
        data.Writing().CopyTo(bytes,index);
        index += data.GetBytesNum();
    }

    protected int ReadInt(byte [] bytes,ref int index)
    {
        int value =  BitConverter.ToInt32(bytes, index);
        index += sizeof(int);
        return value;
    }
    protected float ReadFload(byte [] bytes,ref int index)
    {
        float value = BitConverter.ToSingle(bytes,index);
        index += sizeof(float);
        return value;
    }
    protected bool ReadBool(byte [] bytes, ref int index)
    {
        bool value = BitConverter.ToBoolean(bytes,index);
        index += sizeof(bool);
        return value;
    }
    protected string ReadString(byte [] bytes,ref int index)
    {
        //�ȶ�ȡ�ֽ����鳤��
        int strLength = ReadInt(bytes, ref index);
        //�ڶ�ȡ�ֽ����鱾��
        string value = Encoding.UTF8.GetString(bytes, index, strLength);
        index += strLength;
        return value;
    }

    protected T ReadData<T>(byte [] bytes,ref int index) where T :BaseData,new ()
    {
        T value = new T();
        index += value.Reading(bytes, index);
        return value;
    }
}
