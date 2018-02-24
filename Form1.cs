using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Byts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int a = 0;
            a = Convert.ToInt32(txtDec.Text);//numero ingresado

            int b = 0;//contador

            string cad1 = "";
            string texto = "";
            char letter;
            cad1 = Convert.ToString(a, 2);//convirtiendo los datos a binario Guardados como cadena
            string newCadena = cad1;
            int tamaño = cad1.Length;
            int con = 0;

            if (a<256)
            {
                for (int c = tamaño; c <= 7; c++)
                {
                    con++;
                    texto += "0";
                }
                texto = texto + "" + newCadena;
                lblThree.Text = texto;
                string cad2y3 = "";
                string cad4al6 = "";

                for (b = 0; b <= 7; b++)
                {
                    letter = texto[b];
                    if (b == 2 || b == 3)
                    {
                        cad2y3 += texto[b];//cadena del tanque
                    }
                    else if (b >= 4 && b < 7)
                    {
                        cad4al6 += texto[b];//cadena de las dirrecciones
                    }

                    if (b == 0)//Pocicion 7
                    {
                        if (letter == '1')
                        {
                            picPaloma.Image = Byts.Properties.Resources.paloma;
                        }
                        else if (letter == '0')
                        {
                            picPaloma.Image = Byts.Properties.Resources.x_one;
                        }
                    }
                    else if (b == 1)//Pocicion 6
                    {
                        if (letter == '1')
                        {
                            picPaloma1.Image = Byts.Properties.Resources.paloma;
                        }
                        else if (letter == '0')
                        {
                            picPaloma1.Image = Byts.Properties.Resources.x_one;
                        }
                    }
                }

                //Nivel de Tanque
                if (cad2y3 == "00")
                {
                    //Vacio
                    picTanque.Image = Byts.Properties.Resources.Vacio;
                }
                else if (cad2y3 == "01")
                {
                    //Medio
                    picTanque.Image = Byts.Properties.Resources.Medio;
                }
                else if (cad2y3 == "10")
                {
                    //Lleno
                    picTanque.Image = Byts.Properties.Resources.Lleno;
                }
                else if (cad2y3 == "11")
                {
                    //Llenando
                    picTanque.Image = Byts.Properties.Resources.Llenando;
                }

                //Direcciones
                if (cad4al6 == "000")
                {
                    picDireccion.Image = Byts.Properties.Resources.norte;
                }
                else if (cad4al6 == "001")
                {
                    picDireccion.Image = Byts.Properties.Resources.noreste;
                }
                else if (cad4al6 == "010")
                {
                    picDireccion.Image = Byts.Properties.Resources.este;
                }
                else if (cad4al6 == "011")
                {
                    picDireccion.Image = Byts.Properties.Resources.sureste;
                }
                else if (cad4al6 == "100")
                {
                    picDireccion.Image = Byts.Properties.Resources.sur;
                }
                else if (cad4al6 == "101")
                {
                    picDireccion.Image = Byts.Properties.Resources.suroeste;
                }
                else if (cad4al6 == "110")
                {
                    picDireccion.Image = Byts.Properties.Resources.oeste;
                }
                else if (cad4al6 == "111")
                {
                    picDireccion.Image = Byts.Properties.Resources.noroeste;
                }
            }
            else
            {
                txtBin.Text = "Ingrese un numero menor a 256";
            }
        }

        private void btnFecha_Click(object sender, EventArgs e)
        {
            DateTime Fecha = dataFecha.Value;
            int año = Fecha.Year;
            int mes = Fecha.Month;
            int dia = Fecha.Day;

            int tamañoAño, tamañoMes, tamañoDia;

            año = año - 1900;

            string año1 = Convert.ToString(año, 2);//Maximo numero 7
            string mes1 = Convert.ToString(mes, 2);//Maximo numero 4
            string dia1 = Convert.ToString(dia, 2);//Maximo numero 5
            string FechaNumero="";

            tamañoAño = año1.Length;
            tamañoMes = mes1.Length;
            tamañoDia = dia1.Length;

            int[] cont = new int[3];

            cont[0] = 7 - tamañoAño;
            cont[1] = 4 - tamañoMes;
            cont[2] = 5 - tamañoDia;

            int con = 0;
            string texto = "";
            string texto1 = "";
            string texto2 = "";
            //string letter = "";

            for (int c = tamañoAño; c < 7; c++)
            {
                con++;
                texto += "0";
            }

            for (int c = tamañoMes; c < 4; c++)
            {
                con++;
                texto1 += "0";
            }

            for (int c = tamañoDia; c < 5; c++)
            {
                con++;
                texto2 += "0";
            }
            
            año1 = texto + "" + año1;
            mes1 = texto1 + "" + mes1;
            dia1 = texto2 + "" + dia1;
            FechaNumero = año1 + "" + mes1 + "" + dia1;

            int n = 0;
            string bin = "";


            for (int x = FechaNumero.Length-1, y=0; x >= 0; x--, y++)
            {
                if (FechaNumero[x]=='0' || FechaNumero[x]=='1')
                {
                    n += (int)(int.Parse(FechaNumero[x].ToString()) * Math.Pow(2,y));
                }
            }
            txtFechaNum.Text = n.ToString();
            lblPrueba.Text = n+"---"+FechaNumero;
        }
    }
}
