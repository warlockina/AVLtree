using System;
using System.Drawing;

namespace arbori
{
    public partial class Form1 : Form
    {
        public class AVLnode
        {
            public int val;
            public AVLnode st, dr; //? - can be null
            public int h;
            public AVLnode(int a) { val = a; h = 1; }

            //insert/delete/rotate/balance
        }
        public class AVLtree
        {
            public AVLnode r; //radacina
            private int height(AVLnode nod)
            {
                return (nod != null ? nod.h : 0);
            }

            private void updateHeight(AVLnode nod) //root has the highest value, leaves have h=1
            {
                int a = height(nod.st);
                int b = height(nod.dr);
                nod.h = 1 + Math.Max(a, b);
            }

            private int BF(AVLnode nod)
            {
                if (nod == null) return 0;
                return height(nod.st) - height(nod.dr);
            }

            public void adaug(int val)
            {
                AVLnode nou = new AVLnode(val);
                if (r == null) r = nou;
                else r = inserare(r, nou);
            }

            private AVLnode inserare(AVLnode current, AVLnode nod)
            {
                if (current == null)
                {
                    current = nod;
                    return current;
                }

                else if (nod.val < current.val)
                    current.st = inserare(current.st, nod);
                else if (nod.val > current.val)
                    current.dr = inserare(current.dr, nod);

                updateHeight(current);
                current = balanceTree(current);
                return current;
            }

            private AVLnode balanceTree(AVLnode current)
            {
                int bf = BF(current);
                if (bf > 1) // caz L... (left heavy)
                {
                    if (BF(current.st) > 0) current = rotateLL(current); //left heavy
                    else current = rotateLR(current); //right heavy
                }
                else if (bf < -1) // caz R... (right heavy)
                {
                    if (BF(current.dr) > 0) current = rotateRL(current); //left heavy
                    else current = rotateRR(current); //right heavy
                }

                updateHeight(current);
                return current;
            }

            public void stergere(int val)
            {
                r = stergere(r, val);
            }

            private AVLnode stergere(AVLnode nod, int val)
            {
                AVLnode tata;
                if (nod == null) return null;
                //o iau la stanga
                if (val < nod.val)
                {
                    nod.st = stergere(nod.st, val);
                    if (BF(nod) == -2)
                    {
                        if (BF(nod.dr) <= 0) nod = rotateRR(nod);
                        else nod = rotateRL(nod);
                    }
                }
                //o iau la dreapta
                else if (val > nod.val)
                {
                    nod.dr = stergere(nod.dr, val);
                    if (BF(nod) == 2)
                    {
                        if (BF(nod.st) >= 0) nod = rotateLL(nod);
                        else nod = rotateLR(nod);
                    }
                }
                //daca am gasit
                else
                {
                    if (nod.dr != null)
                    {
                        tata = nod.dr;
                        while (tata.st != null) tata = tata.st;
                        nod.val = tata.val;
                        nod.dr = stergere(nod.dr, tata.val);
                        if (BF(nod) == 2) //rebalance
                        {
                            if (BF(nod.st) >= 0) nod = rotateLL(nod);
                            else nod = rotateLR(nod);
                        }
                    }
                    else return nod.st;
                }
                return nod;
            }

            private AVLnode rotateRR(AVLnode tata)
            {
                AVLnode pivot = tata.dr;
                tata.dr = pivot.st;
                pivot.st = tata;
                updateHeight(tata);
                updateHeight(pivot);
                return pivot;
            }

            private AVLnode rotateLL(AVLnode tata)
            {
                AVLnode pivot = tata.st;
                tata.st = pivot.dr;
                pivot.dr = tata;
                updateHeight(tata);
                updateHeight(pivot);
                return pivot;
            }

            private AVLnode rotateLR(AVLnode tata)
            {
                AVLnode pivot = tata.st;
                tata.st = rotateRR(pivot);
                return rotateLL(tata);
            }

            private AVLnode rotateRL(AVLnode tata)
            {
                AVLnode pivot = tata.dr;
                tata.dr = rotateLL(pivot);
                return rotateRR(tata);
            }
        }

        private AVLtree arbore = new AVLtree();

        public Form1()
        {
            InitializeComponent();
            treePanel.Paint += treePanel_Paint;
        }

        private void treePanel_Paint(object sender, PaintEventArgs e)
        {
            if (arbore.r == null) return;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            drawNode(e.Graphics, arbore.r, treePanel.Width / 2, 40, treePanel.Width / 4);
        }

        private void drawNode(Graphics g, AVLnode nod, int x, int y, int offset)
        {
            int raza = 20;
            //muchii
            if(nod.st != null)
            {
                g.DrawLine(Pens.Black, x, y, x - offset, y + 60);
                drawNode(g, nod.st, x - offset, y + 60, offset / 2);
            }
            if (nod.dr != null)
            {
                g.DrawLine(Pens.Black, x, y, x + offset, y + 60);
                drawNode(g, nod.dr, x + offset, y + 60, offset / 2);
            }

            //noduri
            g.FillEllipse(Brushes.SteelBlue, x - raza, y - raza, raza * 2, raza * 2);
            g.DrawEllipse(Pens.Black, x - raza, y - raza, raza * 2, raza * 2);

            string label = nod.val.ToString();
            SizeF size = g.MeasureString(label, Font);
            g.DrawString(label, Font, Brushes.White, x - size.Width / 2, y - size.Height / 2);

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if(int.TryParse(txtValue.Text, out int val))
            {
                arbore.adaug(val);
                treePanel.Invalidate(); //repaint
                txtValue.Clear();
            }
            else
            {
                MessageBox.Show("Introduceti un numar valid.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(int.TryParse(txtValue.Text, out int val))
            {
                arbore.stergere(val);
                
                treePanel.Invalidate();//repaint
                txtValue.Clear();
            }
            else
            {
                MessageBox.Show("Introduceti un numar valid.");
            }
        }


    }
}
