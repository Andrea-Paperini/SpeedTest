namespace prova
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            //apro un thread per un MessageBox che ti mostra il messaggio di attesa
            Thread t = new Thread(() => MessageBox.Show("Test in corso, perfavore aspettare un minuto", "Attenzione"));
            t.Start();
            //creo un file temporaneo
            const string tempfile = "tempfile.tmp";
            System.Net.WebClient webClient = new();
            //inizio a contare il tempo e scarico un file per misurare il tempo
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            webClient.DownloadFile("https://download.visualstudio.microsoft.com/download/pr/14ccbee3-e812-4068-af47-1631444310d1/3b8da657b99d28f1ae754294c9a8f426/dotnet-sdk-5.0.408-win-x64.exe", tempfile);
            sw.Stop();
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(tempfile);
            long speed = fileInfo.Length / sw.Elapsed.Seconds;
            string tempoDownload = "Durata del download: " + sw.Elapsed.ToString("mm\\:ss\\.ff") + " minuti / secondi \r\n";
            //faccio la conversione da bit a Megabit
            double dimensionebit = fileInfo.Length / 1000000.0;
            double dimensioneMb = Math.Round(dimensionebit, 2);
            string dimensione = "Dimensione: " + dimensioneMb;
            double velocita = (speed / 100000.0);
            velocita = Math.Round(velocita, 2);
            //mostro il risultato che contiene il tempo di download, la dimensione del file e la sua velocità
            string risultato = tempoDownload  + dimensione + " Mb" + "\r\n" + velocita +" Mb/s";
            textBox1.Text = risultato.ToString();
            //operatore ternario per controllare se la velocità supera i 100 Mbps lo imposto a 100 per evitare
            //    errori nella barra della velocità
            _ = (velocita > 100) ? velocita = 100 : velocita;
            progressBar1.Value = (int)velocita;
            //chiudo l'avviso dopo aver terminato il test
            SendKeys.SendWait("{Enter}");//or Esc
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}