// Form1.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaForca
{
    public partial class Form1 : Form
    {
        private JogoDaForca jogo;

        public Form1()
        {
            InitializeComponent();
            IniciarNovoJogo();
        }

        // Método responsável por começar um novo jogo.
        private void IniciarNovoJogo()
        {
            try
            {
                jogo = new JogoDaForca();
                jogo.SortearPalavra();
                AtualizarInterface();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar palavra: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método que atualiza os componentes visuais com os dados atuais do jogo.
        private void AtualizarInterface()
        {
            lblPalavra.Text = jogo.PalavraEscondida;
            lblTentativas.Text = $"Tentativas restantes: {jogo.TentativasRestantes}";
            lblLetrasTentadas.Text = "Letras tentadas: " + string.Join(", ", jogo.LetrasTentadas);
            txtLetra.Clear();
            txtLetra.Focus();
        }

        // Evento acionado quando o usuário clica no botão "Tentar".
        private void btnTentar_Click(object sender, EventArgs e)
        {
            string input = txtLetra.Text.Trim();

            if (string.IsNullOrEmpty(input) || input.Length != 1 || !char.IsLetter(input[0]))
            {
                MessageBox.Show("Digite uma única letra!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLetra.Clear();
                txtLetra.Focus();
                return;
            }

            char letra = input[0];
            jogo.TentarLetra(letra);

            AtualizarInterface();

            if (jogo.VerificarVitoria())
            {
                MessageBox.Show("Parabéns! Você venceu!", "Vitória", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IniciarNovoJogo();
            }
            else if (jogo.VerificarDerrota())
            {
                MessageBox.Show($"Você perdeu! A palavra era: {jogo.PalavraSorteada.Texto}", "Derrota", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IniciarNovoJogo();
            }
        }

        // Evento acionado quando o usuário clica no botão "Novo Jogo".
        private void btnNovoJogo_Click(object sender, EventArgs e)
        {
            IniciarNovoJogo();
        }

        // Evento para restringir a entrada apenas a letras
        private void txtLetra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Métodos de evento vazios do template original, mantidos para compatibilidade.
        private void txtLetra_TextChanged(object sender, EventArgs e)
        { /* Não utilizado */ }

        private void lblPalavra_Click(object sender, EventArgs e)
        { /* Não utilizado */ }

        private void lblTentativas_Click(object sender, EventArgs e)
        { /* Não utilizado */ }

        private void lblLetrasTentadas_Click(object sender, EventArgs e)
        { /* Não utilizado */ }
    }
}