namespace cv_lab_1
{
    public partial class Form1 : Form
    {
        int top = -1, current = -1;
        public List<Bitmap> history;
        Bitmap tmpImage;
        public Form1()
        {
            InitializeComponent();
            history = new List<Bitmap>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void îòêğûòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files|*.png;*.jpg;*.bmp|All files(*.*)|*.*";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap image = new Bitmap(openFileDialog.FileName);
                if (current != top)
                {
                    history.RemoveRange(current + 1, top - current);
                    top = current;
                }
                history.Add(image);
                top++;
                current++;                
                pictureBox1.Image = history[current];
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void èíâåğñèÿToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertFilter filter = new InvertFilter();
            backgroundWorker.RunWorkerAsync(filter);/*
            Bitmap resultImage = filter.processImage(image);
            
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filter)e.Argument).processImage(history[current], backgroundWorker);
            if (backgroundWorker.CancellationPending != true)
            {
                tmpImage = newImage;
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if(!e.Cancelled)
            {
                if (current != top)
                {
                    history.RemoveRange(current + 1, top - current);
                    top = current;
                }
                history.Add(tmpImage);
                top++;
                current++;
                pictureBox1.Image = history[current];
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
        }

        private void ğàçìûòèåToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new BlurFilter();
            backgroundWorker.RunWorkerAsync(filter);
        }

        private void ôèëüòğÃàóññàToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new BlurFilter();
            backgroundWorker.RunWorkerAsync(filter);
        }

        private void ÷åğíîáåëûéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new GrayScaleFilter();
            backgroundWorker.RunWorkerAsync(filter);
        }

        private void ñåïèÿToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new SepiaFilter();
            backgroundWorker.RunWorkerAsync(filter);
        }

        private void ôèëüòğÑîáåëÿXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new SobelFilterX();
            backgroundWorker.RunWorkerAsync(filter);
        }

        private void îòìåíèòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (current > 0)
            {
                current--;
                pictureBox1.Image = history[current];
                pictureBox1.Refresh();
            }
        }

        private void ïîâòîğèòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (current < top)
            {
                current++;
                pictureBox1.Image = history[current];
                pictureBox1.Refresh();
            }
        }

        private void ôèëüòğÑîáåëÿYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new SobelFilterY();
            backgroundWorker.RunWorkerAsync(filter);
        }
    }
}