using System;

class Node
{
    public int Data;
    public Node Left, Right;

    public Node(int data)
    {
        Data = data;
        Left = Right = null;
    }
}

class BinaryTree
{
    public Node Root;

    public void Insert(int data)
    {
        Root = InsertRec(Root, data);
    }

    private Node InsertRec(Node root, int data)
    {
        if (root == null)
        {
            root = new Node(data);
            return root;
        }

        if (data < root.Data)
            root.Left = InsertRec(root.Left, data);
        else if (data > root.Data)
            root.Right = InsertRec(root.Right, data);

        return root;
    }

    public void PreOrder(Node node)
    {
        if (node == null)
            return;
        Console.Write(node.Data + " ");
        PreOrder(node.Left);
        PreOrder(node.Right);
    }

    public void InOrder(Node node)
    {
        if (node == null)
            return;
        InOrder(node.Left);
        Console.Write(node.Data + " ");
        InOrder(node.Right);
    }

    public void PostOrder(Node node)
    {
        if (node == null)
            return;
        PostOrder(node.Left);
        PostOrder(node.Right);
        Console.Write(node.Data + " ");
    }
}

class Program
{
    static void Main()
    {
        BinaryTree tree = new BinaryTree();
        int[] values = { 10, 5, 15, 3, 9, 12, 20 };

        foreach (int val in values)
        {
            tree.Insert(val);
        }

        Console.WriteLine("ağaç veri yapısı");
        Console.Write("preOrder   : "); tree.PreOrder(tree.Root);
        Console.Write("\ninOrder    : "); tree.InOrder(tree.Root);
        Console.Write("\npostOrder  : "); tree.PostOrder(tree.Root);
        Console.WriteLine();
    }
}
