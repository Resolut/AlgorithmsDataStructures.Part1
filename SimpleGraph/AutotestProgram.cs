﻿using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Vertex
    {
        public int Value;
        public Vertex(int val)
        {
            Value = val;
        }
    }

    public class SimpleGraph
    {
        public Vertex[] vertex;
        public int[,] m_adjacency;
        public int max_vertex;

        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int[size, size];
            vertex = new Vertex[size];
        }

        public void AddVertex(int value)
        {
            // ваш код добавления новой вершины 
            // с значением value 
            // в свободную позицию массива vertex
            int index = Array.IndexOf(vertex, 0);
            if (index != -1)
                vertex[index] = new Vertex(value);
        }

        // здесь и далее, параметры v -- индекс вершины
        // в списке  vertex
        public void RemoveVertex(int v)
        {
            // ваш код удаления вершины со всеми её рёбрами
            int index = Array.IndexOf(vertex, v);
            if (index != -1)
            {
                vertex[index] = null; // удаление вершины
                int rows = vertex.GetUpperBound(0) + 1;
                for (int i = 0; i < rows; i++)
                {
                    m_adjacency[v, i] = 0; // удаление рёбер
                    m_adjacency[i, v] = 0;
                }
            }
        }

        public bool IsEdge(int v1, int v2)
        {
            // true если есть ребро между вершинами v1 и v2
            if (vertex[v1] != null && vertex[v2] != null)
                if (m_adjacency[v1, v2] == 1 && m_adjacency[v2, v1] == 1) return true;

            return false;
        }

        public void AddEdge(int v1, int v2)
        {
            // добавление ребра между вершинами v1 и v2
            if (vertex[v1] != null && vertex[v2] != null)
            {
                if ((v1 >= 0 && v1 < max_vertex) && (v2 >= 0 && v2 < max_vertex))
                {
                    m_adjacency[v1, v2] = 1;
                    m_adjacency[v2, v1] = 1;
                }
            }
        }

        public void RemoveEdge(int v1, int v2)
        {
            // удаление ребра между вершинами v1 и v2
            if (vertex[v1] != null && vertex[v2] != null)
            {
                if ((v1 >= 0 && v1 < max_vertex) && (v2 >= 0 && v2 < max_vertex))
                {
                    m_adjacency[v1, v2] = 0;
                    m_adjacency[v2, v1] = 0;
                }
            }
        }
    }
}