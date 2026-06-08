using System;
using System.Drawing;

namespace arbori
{
    public partial class Form1 : Form
    {
        private int caut = -1;
        public class AVLnode
        {
            public int val, h;
            public AVLnode st, dr; //? - can be null
            public AVLnode(int a) { val = a; h = 1; }

        }
        public class AVLtree
        {
            public AVLnode radacina; //radacina
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
            public int getBF(AVLnode nod)
            {
                return (nod.st != null ? nod.st.h : 0) - (nod.dr != null ? nod.dr.h : 0);
            }
            public void adaug(int val)
            {
                AVLnode nou = new AVLnode(val);
                if (radacina == null) radacina = new AVLnode(val);
                else radacina = inserare(radacina, nou);
            }

            private AVLnode inserare(AVLnode curent, AVLnode nod)
            {
                if (curent == null)
                    return nod;
                else if (nod.val < curent.val)
                    curent.st = inserare(curent.st, nod);
                else if (nod.val > curent.val)
                    curent.dr = inserare(curent.dr, nod);

                updateHeight(curent);
                curent = balanceTree(curent);
                return curent;
            }

            private AVLnode balanceTree(AVLnode nod)
            {
                int bf = BF(nod);
                if (bf > 1) // caz L... (left heavy)
                {
                    if (BF(nod.st) > 0) nod = rotateLL(nod); //left heavy
                    else nod = rotateLR(nod); //right heavy
                }
                else if (bf < -1) // caz R... (right heavy)
                {
                    if (BF(nod.dr) > 0) nod = rotateRL(nod); //left heavy
                    else nod = rotateRR(nod); //right heavy
                }

                updateHeight(nod);
                return nod;
            }

            public void stergere(int val)
            {
                radacina = stergere(radacina, val);
            }

            private AVLnode stergere(AVLnode nod, int val)
            {
                AVLnode tata;
                if (nod == null) return null;
                //o iau la stanga si balansez
                if (val < nod.val)
                {
                    nod.st = stergere(nod.st, val);
                    if (BF(nod) == -2)
                    {
                        if (BF(nod.dr) <= 0) nod = rotateRR(nod);
                        else nod = rotateRL(nod);
                    }
                }
                //o iau la dreapta si balansez
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
            //rotation cases
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
            if (arbore.radacina == null) return;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            e.Graphics.DrawString($"Inaltime: {arbore.radacina.h - 1}", Font, Brushes.Black, 10, 10);
            e.Graphics.DrawString($"Noduri: {numarNoduri(arbore.radacina)}", Font, Brushes.Black, 10, 25);
            drawNode(e.Graphics, arbore.radacina, treePanel.Width / 2, 40, treePanel.Width / 4);
        }

        private int numarNoduri(AVLnode nod)
        {
            if (nod == null) return 0;
            return 1 + numarNoduri(nod.st) + numarNoduri(nod.dr);
        }
        private void drawNode(Graphics g, AVLnode nod, int x, int y, int offset)
        {
            int raza = 25;
            //muchii si urm noduri
            if (nod.st != null)
            {
                g.DrawLine(Pens.Black, x, y, x - offset, y + 60);
                drawNode(g, nod.st, x - offset, y + 60, offset / 2);
            }
            if (nod.dr != null)
            {
                g.DrawLine(Pens.Black, x, y, x + offset, y + 60);
                drawNode(g, nod.dr, x + offset, y + 60, offset / 2);
            }

            Brush fill = (nod.val == caut) ? Brushes.Goldenrod : Brushes.SteelBlue;
            //noduri
            g.FillEllipse(fill, x - raza, y - raza, raza * 2, raza * 2);
            g.DrawEllipse(Pens.Black, x - raza, y - raza, raza * 2, raza * 2);

            string label = $"{nod.val} / {arbore.getBF(nod)}";

            SizeF size = g.MeasureString(label, Font); //to center label
            g.DrawString(label, Font, Brushes.White, x - size.Width / 2, y - size.Height / 2);

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtValue.Text, out int val))
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
            if (int.TryParse(txtValue.Text, out int val))
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            arbore.radacina = null;
            caut = -1;
            treePanel.Invalidate();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtValue.Text, out int val))
            {
                caut = val;
                treePanel.Invalidate();
            }
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            arbore.radacina = null;
            var rand = new Random();
            for (int i = 0; i < 10; i++)
                arbore.adaug(rand.Next(1, 100));
            treePanel.Invalidate();
        }
    }
}
