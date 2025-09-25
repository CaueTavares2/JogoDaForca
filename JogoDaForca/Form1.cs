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
        // Instância da classe JogoDaForca, que contém toda a lógica do jogo.
        private JogoDaForca jogo;

        // Construtor do formulário.
        public Form1()
        {
            // Inicializa os componentes visuais gerados pelo designer do Windows Forms.
            InitializeComponent();

            // Inicia um novo jogo assim que o formulário é carregado.
            IniciarNovoJogo();
        }

        // Método para iniciar um novo jogo.
        private void IniciarNovoJogo()
        {
            try
            {
                // Cria uma nova instância da classe JogoDaForca.
                jogo = new JogoDaForca();

                // Sorteia uma palavra do banco de dados para o novo jogo.
                jogo.SortearPalavra();

                // Atualiza a interface do usuário com o estado inicial do jogo.
                AtualizarInterface();
            }
            catch (Exception ex)
            {
                // Se ocorrer um erro ao carregar a palavra (ex: banco de dados offline),
                // exibe uma mensagem de erro para o usuário.
                MessageBox.Show("Erro ao carregar palavra: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para atualizar todos os elementos visuais do jogo.
        private void AtualizarInterface()
        {
            // Exibe a palavra com as letras escondidas.
            lblPalavra.Text = jogo.PalavraEscondida;

            // Exibe o número de tentativas restantes.
            lblTentativas.Text = $"Tentativas restantes: {jogo.TentativasRestantes}";

            // Exibe as letras que já foram tentadas, separadas por vírgula.
            lblLetrasTentadas.Text = "Letras tentadas: " + string.Join(", ", jogo.LetrasTentadas);

            // Limpa a caixa de texto de entrada e move o foco para ela.
            txtLetra.Clear();
            txtLetra.Focus();
        }

        // Evento de clique no botão "Tentar".
        private void btnTentar_Click(object sender, EventArgs e)
        {
            // Obtém o texto da caixa de entrada, removendo espaços.
            string input = txtLetra.Text.Trim();

            // Valida a entrada do usuário: deve ser uma única letra.
            if (string.IsNullOrEmpty(input) || input.Length != 1 || !char.IsLetter(input[0]))
            {
                MessageBox.Show("Digite uma única letra!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLetra.Clear();
                txtLetra.Focus();
                return;
            }

            // Obtém a letra da entrada do usuário.
            char letra = input[0];

            // Chama o método 'TentarLetra' da classe JogoDaForca para processar a tentativa.
            bool acertou = jogo.TentarLetra(letra);

            // Atualiza a interface após a tentativa.
            AtualizarInterface();

            // Verifica se o jogo foi vencido.
            if (jogo.VerificarVitoria())
            {
                MessageBox.Show("Parabéns! Você venceu!", "Vitória", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IniciarNovoJogo();
            }
            // Verifica se o jogo foi perdido.
            else if (jogo.VerificarDerrota())
            {
                MessageBox.Show($"Você perdeu! A palavra era: {jogo.PalavraSorteada.Texto}", "Derrota", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IniciarNovoJogo();
            }
        }

        // Evento de clique no botão "Novo Jogo".
        private void btnNovoJogo_Click(object sender, EventArgs e)
        {
            // Simplesmente chama o método que inicia um novo jogo.
            IniciarNovoJogo();
        }

        // Evento acionado sempre que o usuário pressiona uma tecla dentro da caixa de texto "txtLetra".
        // Serve para melhorar a experiência do usuário, permitindo apenas letras.
        private void txtLetra_KeyPress(object sender, KeyPressEventArgs e)
        {
            // char.IsControl(e.KeyChar) permite teclas de controle (como Backspace, Delete, setas).
            // char.IsLetter(e.KeyChar) verifica se é uma letra (A-Z, a-z, incluindo acentuadas em alguns casos).
            // Se NÃO for controle E NÃO for letra, então é um caractere inválido.
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                // Define Handled = true para cancelar a digitação desse caractere.
                e.Handled = true;
            }
        }

        private void txtLetra_TextChanged(object sender, EventArgs e)
        {
        }

        private void lblPalavra_Click(object sender, EventArgs e)
        {
        }

        private void lblTentativas_Click(object sender, EventArgs e)
        {
        }

        private void lblLetrasTentadas_Click(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
