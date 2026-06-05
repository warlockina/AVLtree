using System;

namespace arbori
{
    public class AVLnode
    {
        public int val;
        public AVLnode st, dr;
        public int h;

        //see if you need to use BALANCE FACTOR = {-1; 0; 1}

        public AVLnode(int a) {  val = a; h = 1; }

        //insert/delete/rotate/balance
    }
    public class AVLtree
    {
        public AVLnode r; //radacina
        private int height(AVLnode nod)
        {
            return (nod != null ? nod.h : 0);
        }

        private void updateHeight (AVLnode nod)
        {
            int a = height(nod.st);
            int b = height(nod.dr);
            nod.h = 1 + Math.Max(a, b);
        }

        private int BF (AVLnode nod)
        {
            int a = height(nod.st);
            int b = height(nod.dr);
            return (nod != null ? 0 : (a - b));
        }

        private AVLnode inserare (AVLnode nod, int val)
        {
            return null;
        }

        private AVLnode stergere (AVLnode nod, int val)
        {
            return null;
        }

    }
    public partial class Form1 : Form
    {
        private AVLtree arbore = new AVLtree();

        public Form1()
        {
            InitializeComponent();
        }
    }
}
