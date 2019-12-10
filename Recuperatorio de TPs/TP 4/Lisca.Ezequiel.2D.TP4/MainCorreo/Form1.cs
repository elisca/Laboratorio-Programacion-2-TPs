using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    /// <summary>
    /// Formulario del programa
    /// </summary>
    public partial class FrmPpal : Form
    {
        Correo correo; //Guardara los paquetes que estaran contemplados en el circuito de envio 

        /// <summary>
        /// Inicializa componentes del formulario y una instancia de correo
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
        }

        /// <summary>
        /// Limpia todos los listbox y los carga nuevamente con informacion actualizada de los paquetes y sus estados
        /// </summary>
        void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();

            foreach (Paquete auxPaquete in this.correo.Paquetes)
            {
                if (auxPaquete.Estado == Paquete.EEstado.Ingresado)
                {
                    lstEstadoIngresado.Items.Add(auxPaquete.ToString());
                }
                else if (auxPaquete.Estado == Paquete.EEstado.EnViaje)
                {
                    lstEstadoEnViaje.Items.Add(auxPaquete.ToString());
                }
                else
                {
                    lstEstadoEntregado.Items.Add(auxPaquete.ToString());
                }
            }
        }

        /// <summary>
        /// Realiza todas las acciones necesarias para agregar un paquete al correo
        /// </summary>
        /// <param name="sender">-</param>
        /// <param name="e">-</param>
        private void btnAgregar_Click(object sender, EventArgs e) //Algunos cambios
        {
            Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text); //Instancia un nuevo paquete con informacion cargada
            paquete.EventoErrorBD += this.error_BD; //Suscribe un metodo al evento de error de servidor
            paquete.InformarEstado += paq_InformaEstado; //Suscribe un metodo al evento de informacion de estado

            try //Intenta agregar un paquete al correo y actualizar la informacion visible en el formulario
            {
                correo += paquete;
                ActualizarEstados();
            }
            catch (Exception excepcion) //En caso de error, muestra el mensaje al usuario
            {
                MessageBox.Show(excepcion.Message);
            }
        }

        /// <summary>
        /// Realiza todas las acciones por medio de este metodo para mostrar la informacion de todos los paquetes
        /// entregados en el richtextbox
        /// </summary>
        /// <param name="sender">-</param>
        /// <param name="e">-</param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// En caso de querer cerrar el programa pide confirmacion al usuario, y en ese caso cierra los hilos ocupados
        /// </summary>
        /// <param name="sender">-</param>
        /// <param name="e">-</param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("¿Desea cerrar el programa?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                correo.FinEntregas();
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Realiza todas las acciones necesarias para mostrar la informacion de los paquetes y guardarla en un archivo
        /// de texto
        /// </summary>
        /// <typeparam name="T">Recomendado Paquete o List<Paquete></typeparam>
        /// <param name="elemento">Paquete o Correo</param>
        void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //String con la ruta del escritorio

            if (elemento != null) //Si el elemento no es nulo, lo muestra en el richtextbox
            {
                rtbMostrar.Text = elemento.MostrarDatos(elemento);

                try //Intenta guardar la informacion en un archivo de texto
                {
                    GuardaString.Guardar(elemento.MostrarDatos(elemento), string.Format(@"{0}\Correo-sp-2017.txt", rutaEscritorio));
                    MessageBox.Show("El archivo fue guardado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception) //En caso de error informa al usuario
                {
                    MessageBox.Show("El archivo no se pudo guardar", "Mensaje", MessageBoxButtons.OK);
                }
            }
        }

        /// <summary>
        /// Interviene para mostrar informacion del estado de los paquetes
        /// </summary>
        /// <param name="sender">-</param>
        /// <param name="e">-</param>
        void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado delegadoEstado = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(
                    delegadoEstado,
                    new object[] 
                    { 
                        sender, e 
                    }
                    );
            }
            else
            {
                ActualizarEstados();
            }
        }

        /// <summary>
        /// Metodo manejador del evento de error con servidor
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar en caso de ocurrir evento de error de base de datos</param>
        void error_BD(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Menu contextual con clic derecho, muestra informacion del paquete seleccionado en el richtextbox
        /// </summary>
        /// <param name="sender">-</param>
        /// <param name="e">-</param>
        private void cmsListas_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)this.correo.Paquetes[lstEstadoEntregado.SelectedIndex]);
        }
    }
}
