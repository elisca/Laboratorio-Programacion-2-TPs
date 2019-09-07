//Convierte mal de decimal a binario
//No habilitar mas de una vez consecutiva los botones de conversión de sistemas numéricos
//Comentar el proyecto completo
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Vacía todo el string a mostrar del label de resultado, ambos textboxes y el combobox
        /// </summary>
        private void Limpiar()
        {
            this.lblResultado.Text = "";
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
        }

        /// <summary>
        /// Toma ambos números y el operador seleccionado en el formulario, para llamar a la calculadora y realizar la operación matemática
        /// </summary>
        /// <param name="numero1">Número 1</param>
        /// <param name="numero2">Número 2</param>
        /// <param name="operador">Operación a realizar</param>
        /// <returns>Resultado de la operación matemática</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado;
            Numero n1 = new Numero(numero1);//Asigna el número ingresado al primer objeto número
            Numero n2 = new Numero(numero2);//Asigna el número ingresado al segundo objeto número

            //Realiza la operación matemática llamando a la calculadora y devuelve el resultado
            resultado = Calculadora.Operar(n1, n2, operador);
            return resultado;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            double auxNum;

            if (double.TryParse(this.lblResultado.Text, out auxNum))
            {
                this.lblResultado.Text = Numero.DecimalBinario(auxNum);
            }
            else
            {
                this.lblResultado.Text = "Valor inválido";
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            double auxNum;

            if (double.TryParse(this.lblResultado.Text, out auxNum))
            {
                this.lblResultado.Text = Numero.BinarioDecimal(this.lblResultado.Text);
            }
            else
            {
                this.lblResultado.Text = "Valor inválido";
            }
        }
    }
}
