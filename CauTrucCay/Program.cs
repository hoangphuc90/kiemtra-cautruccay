using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
  MSSV:2421160027
  Ho va ten:Phạm Hoàng Phúc
 */

namespace CauTrucCay
{

   //cau 1
    interface ITree
    {
        void ThemNut(ref TNode root, int x);
        void TaoCay();
        void LNR(TNode root);
        int DemSoNut(TNode root);
        int DemSoNutLa(TNode root);
        int TinhTong(TNode root);
        int TimMin(TNode root);
    }
    class TNode
    {
        public int data;
        public TNode left;
        public TNode right;

        public TNode(int x)
        {
            //viết code thực hiện khỏi tạo nút
            data = x;
            left = null;
            right = null;
        }
    }
    class BST : ITree
    {
        public TNode root;
        public BST()
        {
            this.root = null;
        }

        //viet code cho cac phuong thuc sau 
        public void ThemNut(ref TNode root, int x)
        {
            if (root == null)
            {
                root = new TNode(x);
                return;
            }
            if (x < root.data)
                ThemNut(ref root.left, x);
            else
                ThemNut(ref root.right, x);
        }
        public void TaoCay()
        {
            int[] keys = { 30, 12, 17, 49, 22, 65, 51, 56, 70, 68 };
            foreach (int key in keys)
                ThemNut(ref root, key);
        }

        public void LNR(TNode root)  //duyet cay theo thu tu giua
        {
            if (root != null)
            {
                LNR(root.left);
                Console.Write(root.data + " ");
                LNR(root.right);
            }
        }
        public int DemSoNut(TNode root)
        {

            if (root == null) return 0;
            return 1 + DemSoNut(root.left) + DemSoNut(root.right);
        }

        public int DemSoNutLa(TNode root)
        {
            if (root == null) return 0;
            if (root.left == null && root.right == null) return 1;
            return DemSoNutLa(root.left) + DemSoNutLa(root.right);
        }       

        public int TimMin(TNode root)
        {
            if (root == null) throw new Exception("Cây rỗng");
            while (root.left != null)
                root = root.left;
            return root.data;
        }

        public int TinhTong(TNode root)
        {
            if (root == null) return 0;
            return root.data + TinhTong(root.left) + TinhTong(root.right);
        }
    }


    //cau 2
    class Program
    {
        static void Main(string[] args)
        {
            BST bst = new BST();
            bst.TaoCay();

            Console.Write("Duyet cay theo LNR: ");
            bst.LNR(bst.root);
            Console.WriteLine();

            Console.WriteLine("Tong so nut trong cay: " + bst.DemSoNut(bst.root));
            Console.WriteLine("So nut la: " + bst.DemSoNutLa(bst.root));
            Console.WriteLine("Tong gia tri cac nut: " + bst.TinhTong(bst.root));
            Console.WriteLine("Gia tri nho nhat trong cay: " + bst.TimMin(bst.root));
            Console.ReadLine();
        }
    }
}
