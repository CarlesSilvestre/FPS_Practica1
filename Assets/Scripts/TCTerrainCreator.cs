using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCTerrainCreator : MonoBehaviour
{
    public Texture2D m_heightMap;
    public Vector3 m_TerrainSize;
    public Vector2 m_resolution;
    public MeshFilter mf;
    public MeshRenderer mr;

    private void Start()
    {
        mf = GetComponent<MeshFilter>();
        mr = GetComponent<MeshRenderer>();
    }
    private Vector3 GetVertexPosition(int x, int z) {
        return new Vector3(x, GetHeight(GetUVs(x, z)), z);
    }

    private float GetHeight(Vector2 uv)
    {
        int pixelX = Mathf.FloorToInt(uv.x * m_heightMap.width);
        int pixelY = Mathf.FloorToInt(uv.y * m_heightMap.height);
        return m_heightMap.GetPixel(pixelX, pixelY).grayscale;
    }
    Vector2 GetUVs(int x,int z)
    {
        return new Vector2(x / (float)m_TerrainSize.x, z / (float)m_TerrainSize.y);
    }
    private Vector3 GetNormal (Vector3 v1, Vector2 v2)
    {
        v1.Normalize();
        v2.Normalize();
        Vector3 calculatedNormal = Vector3.Cross(v1, v2);

        if (calculatedNormal.y < 0.0f)
            Debug.Log("error");

        return calculatedNormal;
    }

    Vector3 GetNormal(int x, int z)
    {
        Vector3 l_Normal = Vector3.zero;

        Vector3 Center = GetVertexPosition(x, z);
        bool DerValid = x < m_resolution.x;
        Vector3 Der = DerValid ? GetVertexPosition(x + 1, z) : Vector3.zero;
        bool DownValid = z < m_resolution.y;
        Vector3 Down = DownValid ? GetVertexPosition(x, z + 1) : Vector3.zero;
        bool IzqValid = x > 0;
        Vector3 Izq = IzqValid ? GetVertexPosition(x - 1, z) : Vector3.zero;
        bool UpValid = z > 0;
        Vector3 Up = UpValid ? GetVertexPosition(x, z - 1) : Vector3.zero;

        if(DerValid && DownValid)
        {
            l_Normal += GetNormal(Der - Center,Down - Center);
        }
        if (DownValid && IzqValid)
        {
            l_Normal += GetNormal(Down - Center,Izq - Center);
        }
        if (IzqValid && UpValid)
        {
            l_Normal += GetNormal(Izq - Center,Up - Center);
        }
        if (UpValid && DerValid)
        {
            l_Normal += GetNormal(Up - Center,Der - Center);
        }
        l_Normal.Normalize();
        return l_Normal;
    }

    private void GenerateMesh()
    {
        //Mesh l_mesh = Mesh.


    }
}
