using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SortLines {
    public partial class Form1 : Form {

        #region Vars

        int[] arry = new int[50];
        int numVals = 50;
        int sortType = 0;
        int sleepTime = 100;
        RadioButton[] rads = new RadioButton[4];
        Random ran = new Random();

        private delegate void dUpdatePanel();

        #endregion

        #region Constructor & Events

        public Form1() {
            InitializeComponent();
            reset();

            rads[0] = radBubble;
            rads[1] = radInsertion;
            rads[2] = radCocktail;
            rads[3] = radOddEven;

            cboStyle.SelectedIndex = 0;
        }

        private void tbSpeed_Scroll(object sender, EventArgs e) {
            gbxSpeed.Text = "Speed (" + tbSpeed.Value.ToString() + " hz)";
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            int offset = 0;
            int width = pnlMain.Width / numVals;

            for (int x = 0; x < arry.Length; x++) {
                int height = Convert.ToInt32(Convert.ToDouble(pnlMain.Height) * (Convert.ToDouble(arry[x])/ 100));

                if (cboStyle.SelectedIndex == 0) { // Lines
                    g.FillRectangle(Brushes.ForestGreen,
                        new Rectangle(offset, pnlMain.Height - height, width, height));

                } else if (cboStyle.SelectedIndex == 1) { // Boxes
                    g.FillRectangle(Brushes.ForestGreen,
                        new Rectangle(offset, pnlMain.Height - height, width, width));

                } else if (cboStyle.SelectedIndex == 2) { // ?????
                    g.FillRectangle(Brushes.ForestGreen,
                        new Rectangle(offset, pnlMain.Height - height, width, ran.Next(1, height)));

                }

                offset += width;
            }
        }

        private void btnSort_Click(object sender, EventArgs e) {

            if (!bgwMain.IsBusy) {
                for (int x = 0; x < rads.Length; x++) {
                    if (rads[x].Checked) {
                        sortType = x;
                        break;
                    }
                }

                btnReset.Hide();
                btnSort.Hide();
                gbxType.Hide();
                bgwMain.RunWorkerAsync();
            }
        }

        private void reset() {
            for (int x = 0; x < arry.Length; x++) {
                arry[x] = ran.Next(1, 101);
            }

            pnlMain.Refresh();
        }

        private void btnReset_Click(object sender, EventArgs e) {
            reset();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e) {
            pnlMain.Invalidate();
        }

        #endregion

        #region Sorting

        private void swap(ref int a, ref int b) {
            int temp = a;
            a = b;
            b = temp;
        }

        private void insertionSort(int[] a) {

            for (int x = 1; x < a.Length; x++) {
                int iPoint = x;
                while (iPoint > 0 && a[iPoint - 1] > a[iPoint]) {
                    swap(ref a[iPoint], ref a[iPoint - 1]);
                    iPoint--;

                    updateGraph();
                }
            }
        }

        private void bubbleSort(int[] a) {
            bool switched = true;

            while (switched) {
                switched = false;
                for (int x = 1; x < a.Length; x++) {
                    if (a[x - 1] > a[x]) {
                        swap(ref a[x], ref a[x - 1]);
                        switched = true;

                        updateGraph();
                    }
                }
            }
        }

        private void coctailShakerSort(int[] a) {
            bool swapped;
            do {
                swapped = false;

                for (int x = 0; x < a.Length - 2; x++) {
                    if (a[x] > a[x + 1]) {
                        swap(ref a[x], ref a[x + 1]);
                        swapped = true;

                        updateGraph();
                    }
                }

                if (!swapped) {
                    break;
                }

                for (int x = a.Length - 2; x >= 0; x--) {
                    if (a[x] > a[x + 1]) {
                        swap(ref a[x], ref a[x + 1]);
                        swapped = true;

                        updateGraph();
                    }
                }

            } while (swapped);
        }

        private void oddEvenSort(int[] a) {
            bool sorted = false;

            while (!sorted) {
                sorted = true;

                for (int x = 0; x < a.Length - 1; x += 2) {
                    if (a[x] > a[x + 1]) {
                        swap(ref a[x], ref a[x + 1]);
                        sorted = false;

                        updateGraph();
                    }
                }

                for (int x = 1; x < a.Length - 1; x += 2) {
                    if (a[x] > a[x + 1]) {
                        swap(ref a[x], ref a[x + 1]);
                        sorted = false;

                        updateGraph();
                    }
                }
            }
        }

        #endregion

        #region BGW & Related

        private void updateGraph() {
            pnlMain.Invoke(new dUpdatePanel(updatePanel));
            System.Threading.Thread.Sleep(sleepTime);
        }

        private void updatePanel() {
            pnlMain.Invalidate();
            sleepTime = 1000 / tbSpeed.Value;
        }

        private void bgwMain_DoWork(object sender, DoWorkEventArgs e) {
            switch (sortType) {
                case 0:
                    bubbleSort(arry);
                    break;
                case 1:
                    insertionSort(arry);
                    break;
                case 2:
                    coctailShakerSort(arry);
                    break;
                case 3:
                    oddEvenSort(arry);
                    break;
            }
        }

        private void bgwMain_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            btnReset.Show();
            btnSort.Show();
            gbxType.Show();
        }

        #endregion
    }
}
