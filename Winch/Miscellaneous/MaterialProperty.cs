using System;
using System.Linq;
using UnityEngine.Rendering;

namespace UnityEngine;

public class MaterialProperty
{
    protected Shader sha;
    protected Material mat;
    protected int index;

    public Shader Shader => sha;
    public Material Material => mat;
    public int Index => index;
    public string Name => sha.GetPropertyName(index);
    public int NameID => sha.GetPropertyNameId(index);
    public string Description => sha.GetPropertyDescription(index);
    public string[] Attributes => sha.GetPropertyAttributes(index);

    public object Value
    {
        get
        {
            switch (Type)
            {
                case ShaderPropertyType.Color:
                    return mat.GetColor(Name);
                case ShaderPropertyType.Vector:
                    return mat.GetVector(Name);
                case ShaderPropertyType.Float:
                case ShaderPropertyType.Range:
                    return mat.GetFloat(Name);
                case ShaderPropertyType.Texture:
                    return mat.GetTexture(Name);
                case ShaderPropertyType.Int:
                    return mat.GetInteger(Name);
                default:
                    throw new NotSupportedException($"Getting value for type {Type} is not supported!");
            }
        }
    }

    public object DefaultValue
    {
        get
        {
            switch (Type)
            {
                case ShaderPropertyType.Color:
                case ShaderPropertyType.Vector:
                    return sha.GetPropertyDefaultVectorValue(Index);
                case ShaderPropertyType.Float:
                case ShaderPropertyType.Range:
                    return sha.GetPropertyDefaultFloatValue(Index);
                case ShaderPropertyType.Texture:
                    return sha.GetPropertyTextureDefaultValue(Index);
                //case ShaderPropertyType.Int:
                //    return sha.GetPropertyDefaultIntegerValue(Index);
                default:
                    throw new NotSupportedException($"Getting default value for type {Type} is not supported!");
            }
        }
    }

    public ShaderPropertyType Type => sha.GetPropertyType(index);
    public ShaderPropertyFlags Flags => sha.GetPropertyFlags(index);

    public MaterialProperty(int index, Material mat)
    {
        this.sha = mat.shader;
        this.mat = mat;
        this.index = index;
    }

    public override string ToString() => $"{Index}: {Name} ({Type}) ({NameID}) ({Description}){(Attributes.Any() ? $" ({string.Join(", ", Attributes)})" : string.Empty)}";
}

public class ColorProperty : VectorProperty
{
    public new Color Value
    {
        get => mat.GetColor(Name);
        set => mat.SetColor(Name, value);
    }

    public new Color DefaultValue => sha.GetPropertyDefaultVectorValue(index);

    public new Color GetValue() => mat.GetColor(Name);
    public void SetValue(Color val) => mat.SetColor(Name, val);

    public ColorProperty(int index, Material mat) : base(index, mat)
    {
        if (mat.shader.GetPropertyType(index) != ShaderPropertyType.Color)
            throw new NotSupportedException("property must be a color");
    }
}

public class TextureProperty : MaterialProperty
{
    public new Texture Value
    {
        get => mat.GetTexture(Name);
        set => mat.SetTexture(Name, value);
    }

    public string DefaultName => sha.GetPropertyTextureDefaultName(index);
    public new Texture2D DefaultValue => sha.GetPropertyTextureDefaultValue(index);

    public TextureDimension Dimension => sha.GetPropertyTextureDimension(index);
    public Vector2 Offset => mat.GetTextureOffset(Name);
    public Vector2 Scale => mat.GetTextureScale(index);

    public Texture GetValue() => mat.GetTexture(Name);
    public void SetValue(Texture val) => mat.SetTexture(Name, val);

    public TextureProperty(int index, Material mat) : base(index, mat)
    {
        if (Type != ShaderPropertyType.Texture)
            throw new NotSupportedException("property must be a texture");
    }
}

public class VectorProperty : MaterialProperty
{
    public new Vector4 Value
    {
        get => mat.GetVector(Name);
        set => mat.SetVector(Name, value);
    }

    public new Vector4 DefaultValue => sha.GetPropertyDefaultVectorValue(index);

    public Vector4 GetValue() => mat.GetVector(Name);
    public void SetValue(Vector4 val) => mat.SetVector(Name, val);

    public VectorProperty(int index, Material mat) : base(index, mat)
    {
        if (Type != ShaderPropertyType.Vector && Type != ShaderPropertyType.Color)
            throw new NotSupportedException("property must be a vector");
    }
}

public class FloatProperty : MaterialProperty
{
    public new float Value
    {
        get => mat.GetFloat(Name);
        set => mat.SetFloat(Name, value);
    }

    public int IntValue
    {
        get => mat.GetInt(Name);
        set => mat.SetInt(Name, value);
    }

    public bool BoolValue
    {
        get => mat.GetInt(Name) != 0;
        set => mat.SetInt(Name, value ? 1 : 0);
    }

    public new float DefaultValue => sha.GetPropertyDefaultFloatValue(index);

    public float GetValue() => mat.GetFloat(Name);
    public void SetValue(float val) => mat.SetFloat(Name, val);

    public bool IsToggle() => Attributes.Any(attribute => attribute.StartsWith("Toggle"));

    public FloatProperty(int index, Material mat) : base(index, mat)
    {
        if (Type != ShaderPropertyType.Float && Type != ShaderPropertyType.Range)
            throw new NotSupportedException("property must be a float");
    }
}

public class RangeProperty : FloatProperty
{
    public Vector2 RangeLimits => sha.GetPropertyRangeLimits(index);

    public RangeProperty(int index, Material mat) : base(index, mat)
    {
        if (Type != ShaderPropertyType.Range)
            throw new NotSupportedException("property must be a range");
    }
}

public class IntegerProperty : MaterialProperty
{
    public new int Value
    {
        get => mat.GetInteger(Name);
        set => mat.SetInteger(Name, value);
    }

    //public new int DefaultValue => sha.GetPropertyDefaultIntValue(index);

    public float GetValue() => mat.GetInteger(Name);
    public void SetValue(int val) => mat.SetInteger(Name, val);

    public IntegerProperty(int index, Material mat) : base(index, mat)
    {
        if (Type != ShaderPropertyType.Int)
            throw new NotSupportedException("property must be a integer");
    }
}