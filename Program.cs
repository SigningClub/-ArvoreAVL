using System;
using System.Collections.Generic;
 
public class Node 
{ 
    
    public int key, height; 
    public Node left, right; 
  
    public Node(int d) 
    { 
        key = d; 
        height = 1; 
    }
    public void PrintPretty(string indent, bool last)
        {
 
            Console.Write(indent);
            if (last)
            {
                Console.Write("└─");
                indent += "  ";
            }
            else
            {
                Console.Write("├─");
                indent += "| ";
            }
            Console.WriteLine(key);
 
            var children = new List<Node>();
            if (this.left != null)
                children.Add(this.left);
            if (this.right != null)
                children.Add(this.right);
 
            for (int i = 0; i < children.Count; i++)
                children[i].PrintPretty(indent, i == children.Count - 1);
 
        }
 
} 
  
public class AVLTree 
{ 
    Node root; 
  
     
    int height(Node N) 
    { 
        if (N == null) 
            return 0; 
        return N.height; 
    } 
  
     
    int max(int a, int b) 
    { 
        return (a > b) ? a : b; 
    } 
  
     
    Node rightRotate(Node y) 
    { 
        Node x = y.left; 
        Node T2 = x.right; 
  
         
        x.right = y; 
        y.left = T2; 
  
         
        y.height = max(height(y.left), height(y.right)) + 1; 
        x.height = max(height(x.left), height(x.right)) + 1; 
  
         
        return x; 
    } 
  
     
    Node leftRotate(Node x) 
    { 
        Node y = x.right; 
        Node T2 = y.left; 
  
         
        y.left = x; 
        x.right = T2; 
  
         
        x.height = max(height(x.left), height(x.right)) + 1; 
        y.height = max(height(y.left), height(y.right)) + 1; 
  
         
        return y; 
    } 
  
    
    int getBalance(Node N) 
    { 
        if (N == null) 
            return 0; 
        return height(N.left) - height(N.right); 
    } 
  
    Node insert(Node node, int key) 
    { 
        
        if (node == null) 
            return (new Node(key)); 
  
        if (key < node.key) 
            node.left = insert(node.left, key); 
        else if (key > node.key) 
            node.right = insert(node.right, key); 
        else  
            return node; 
  
        
        node.height = 1 + max(height(node.left), 
                            height(node.right)); 
  
        
        int balance = getBalance(node); 
  
        
        if (balance > 1 && key < node.left.key)
        {
           Console.WriteLine("Rotação direita simples");
           return rightRotate(node); 
        }
             
  
         
        if (balance < -1 && key > node.right.key)
        {
            Console.WriteLine("Rotação Esquerda simples");
            return leftRotate(node);
        } 
             
  
         
        if (balance > 1 && key > node.left.key) 
        { 
            Console.WriteLine("Rotação Direita Dupla");
            node.left = leftRotate(node.left); 
            return rightRotate(node); 
        } 
  
         
        if (balance < -1 && key < node.right.key) 
        { 
            Console.WriteLine("Rotação Esquerda Dupla");
            node.right = rightRotate(node.right); 
            return leftRotate(node); 
        } 
  
        
        return node; 
    } 
  
    
    Node minValueNode(Node node) 
    { 
        Node current = node; 
  
        
        while (current.left != null) 
        current = current.left; 
  
        return current; 
    } 
  
    Node deleteNode(Node root, int key) 
    { 
         
        if (root == null) 
            return root; 
  
         
        if (key < root.key) 
            root.left = deleteNode(root.left, key); 
  
        
        else if (key > root.key) 
            root.right = deleteNode(root.right, key); 
  
         
        else
        { 
  
             
            if ((root.left == null) || (root.right == null)) 
            { 
                Node temp = null; 
                if (temp == root.left) 
                    temp = root.right; 
                else
                    temp = root.left; 
  
                 
                if (temp == null) 
                { 
                    temp = root; 
                    root = null; 
                } 
                else 
                    root = temp;  
            } 
            else
            { 
  
                 
                Node temp = minValueNode(root.right); 
  
                 
                root.key = temp.key; 
  
                 
                root.right = deleteNode(root.right, temp.key); 
            } 
        } 
  
         
        if (root == null) 
            return root; 
  
         
        root.height = max(height(root.left), 
                    height(root.right)) + 1; 
  
         
        int balance = getBalance(root); 
  
         
        if (balance > 1 && getBalance(root.left) >= 0) 
            return rightRotate(root); 
  
         
        if (balance > 1 && getBalance(root.left) < 0) 
        { 
            root.left = leftRotate(root.left); 
            return rightRotate(root); 
        } 
  
         
        if (balance < -1 && getBalance(root.right) <= 0) 
            return leftRotate(root); 
  
         
        if (balance < -1 && getBalance(root.right) > 0) 
        { 
            root.right = rightRotate(root.right); 
            return leftRotate(root); 
        } 
  
        return root; 
    } 
  
    
    void preOrder(Node node) 
    { 
        if (node != null) 
        { 
            Console.Write(node.key + " "); 
            preOrder(node.left); 
            preOrder(node.right); 
        } 
    }
    void posOrder(Node atual) 
    {
        if (atual != null) 
        {
          posOrder(atual.left);
          posOrder(atual.right);
          Console.Write(atual.key + " ");
        }
      }
    void inOrder(Node atual) 
    {
    if (atual != null) 
    {
      inOrder(atual.left);
      Console.Write(atual.key + " ");
      inOrder(atual.right);
    }
    }
    void caminhar() 
    {
    Console.Write("Exibindo em in-ordem: ");
    inOrder(root);
    Console.Write("\nExibindo em pós-ordem: ");
    posOrder(root);
    Console.Write("\nExibindo em pré-ordem: ");
    preOrder(root);
    
  }
 
    Node buscar(Double chave) {
    
 
 
    if (root == null) return null; 
    Node atual = root; 
    while (atual.key != chave) { 
      if(chave < atual.key ) atual = atual.left; 
      else atual = atual.right; 
      if (atual == null){
        return null;
 
      }  
    } 
    Console.WriteLine("Item encontrado: "+atual.key);
    return atual; 
  }
  static void printUtil(Node root, int space) 
{ 
    int COUNT = 10;
     
    if (root == null) 
        return; 
  
     
    space += COUNT; 
  
     
    printUtil(root.right, space); 
  
     
    Console.Write("\n"); 
    for (int i = COUNT; i < space; i++) 
        Console.Write(" "); 
    Console.Write(root.key + "\n"); 
  
     
    printUtil(root.left, space); 
} 
 
void rotaçãoDireitaSimples(Node node)
{
    while (true)
    {
        if (node.right!=null)
        {
            node = node.right;
        }
        else
        {
            deleteNode(root,node.key);
            insert(root,node.key);
            break;

        }
    }
 
}
 
  
 
static void print(Node root) 
{ 
     
    printUtil(root, 0); 
} 
 
void rotaçãoEsquerdaSimples(Node node)
{
    Node insertion;
    
    insertion = leftRotate(node);
    insert(node.left,insertion.key);
}
void rotaçãoDireitaDupla(Node node)
{
    Node insertion;
    insertion = leftRotate(node);
    insert(node.left,insertion.key);
    insertion = rightRotate(node);
    insert(node.right,insertion.key);
 
}
void rotaçãoEsquerdaDupla(Node node)
{
    Node insertion;
    insertion = rightRotate(node);
    insert(node.right,insertion.key);
    insertion = leftRotate(node);
    insert(node.left,insertion.key);
 
}
 
void selectingRotation(Node node)
{
    int caso;
    Console.Write("A árvore está desbalanceada, qual rotação deseja executar ?"
    +"\n1 - Rotação Direita Simples, 2 - Rotação Esquerda Simples\n3 - Rotação Direita Dupla, 4 - Rotação Esquerda Dupla: ");
    string input = Console.ReadLine();
    caso = Convert.ToInt32(input);
    switch (caso)
    {
        case 1:
        rotaçãoDireitaSimples(node);
        Console.WriteLine("Rotação Direita Simples executada com sucesso!");
 
        break;
        case 2:
        rotaçãoEsquerdaSimples(node);
        break;
        case 3:
        rotaçãoDireitaDupla(node);
        break;
        case 4:
        rotaçãoEsquerdaDupla(node);
        break;
        default:
        Console.WriteLine("Número inválido, tente de novo");
        selectingRotation(node);
        break;
    }
 
}
    public static void Main() 
    { 
        AVLTree tree = new AVLTree(); 
  
        tree.root = tree.insert(tree.root, 20);
        tree.root = tree.insert(tree.root, 15);
        tree.root = tree.insert(tree.root, 25);
        tree.root = tree.insert(tree.root, 12);
        tree.root = tree.insert(tree.root, 17);
        tree.root = tree.insert(tree.root, 24);
        tree.root = tree.insert(tree.root, 30);
        tree.root = tree.insert(tree.root, 10);
        tree.root = tree.insert(tree.root, 14);
        tree.root = tree.insert(tree.root, 13);
        tree.root.PrintPretty("",true);
        Console.Write("Selecione um valor para rotação: ");
        int valorRotação = Convert.ToInt32(Console.ReadLine());
        tree.selectingRotation(tree.buscar(valorRotação));
        tree.root.PrintPretty("",true);
        Console.Write("Selecione um valor para rotação: ");
        valorRotação = Convert.ToInt32(Console.ReadLine());
        tree.selectingRotation(tree.buscar(valorRotação));
        tree.root.PrintPretty("",true);
 
 
  
        
        
        
    } 
}
 
 
 
 
 
