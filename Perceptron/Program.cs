﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perceptron
{
    class Program
    {
        static List<double[]> entrada = new List<double[]>();
        static List<double[]> salida= new List<double[]>();
        static int numentradas=2;
        static int numsalidas=1;
        static String ruta = @"D:/Dano/Escritorio/Dataset-Draw/datasetPrueba.csv";
        static String rutasalida = @"D:/Dano/Escritorio/Dataset-Draw/salida.csv";
        static String rutaneurona = @"D:/Dano/Escritorio/Dataset-Draw/neurona.bin";
        static double maxentr=40;
        static double minentrada=0;
        static double minsal=2;
        static double maxsal=0;
        static bool guardarred=false;
        static bool cargarred = true;

        static double Normalizar(double valor, double min, double max)
        {
            return (valor - min) / (max - min);
        }
        static double desnormalizado(double valor, double min, double max)
        {
            return valor * (max - min) + min;
        }
        static void leerDatos()
        {
            string datos = System.IO.File.ReadAllText(ruta).Replace("\r", "");
            string[] fila = datos.Split(Environment.NewLine.ToCharArray());

            for(int i=0; i<fila.Length; i++)
            {
                string[] filadatos = fila[i].Split(';');
                double[] entradas = new double[numentradas];
                double[] salidas = new double[numsalidas];
                for(int j=0; j<filadatos.Length; j++)
                {
                    if (j < numentradas)
                    {
                        entradas[j] =Normalizar( double.Parse(filadatos[j]), minentrada, maxentr);
                    }
                    else
                    {
                        salidas[j - numentradas] =Normalizar( double.Parse(filadatos[j]), minsal, maxsal);
                    }
                }
                entrada.Add(entradas);
                salida.Add(salidas);
            }
        }
        static void peticionsalida(Perceptron p)
        {
            while (true)
            {
                double[] val = new double[numentradas];
                for (int i = 0; i < numentradas; i++)
                {
                    Console.WriteLine("inserta valor: " + i + ": ");
                    val[i] = Normalizar(double.Parse(Console.ReadLine()), minentrada, maxentr);
                }
                double[] sal = p.activacion(val);
                for (int i = 0; i < numsalidas; i++)
                {
                    Console.WriteLine("respuesta " + i + ": " + desnormalizado(sal[i], minsal, maxsal) + " ");

                }
                Console.WriteLine("");

            }
        }

        static void evaluar(Perceptron p, double inicio, double fin, double salto)
        {
            string salida = "";
            for(double i = inicio; i< fin; i += salto)
            {
                double res = p.activacion(new double[] { Normalizar(i, minentrada, maxentr) })[0];
                salida += i + ";" + desnormalizado(res, minsal, maxsal) + "\n";
                Console.WriteLine(i + ";" + res + "\n");
            }
            System.IO.File.WriteAllText(rutasalida, salida);
        }
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
           Application.SetCompatibleTextRenderingDefault(false);
           Application.Run(new WindowRecognition());
            
            /**
            Perceptron p;
            

            if (!cargarred)
            {
                leerDatos();
                 p = new Perceptron(new int[] { entrada[0].Length, 8, 8, salida[0].Length });
                while (!p.aprender(entrada, salida, 0.05, 0.01, 5000))
                {
                    p = new Perceptron(new int[] { entrada[0].Length, 8, 8, salida[0].Length });
                }
                if (guardarred)
                {
                    FileStream fs = new FileStream(rutaneurona, FileMode.Create);
                    BinaryFormatter formatter = new BinaryFormatter();
                    try
                    {
                        formatter.Serialize(fs, p);
                    }
                    catch (SerializationException e)
                    {
                        Console.WriteLine("Fallo la serializacion: " + e.Message);
                        throw;
                    }
                    finally
                    {
                        fs.Close();
                    }
                }
            }
            else
            {
                FileStream fs = new FileStream(rutaneurona, FileMode.Open);
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    p = (Perceptron)formatter.Deserialize(fs);
                }
                catch(SerializationException e)
                {
                    Console.WriteLine("fallo: "+e);
                    throw;
                }
                finally
                {
                    fs.Close();
                }
            }
            peticionsalida(p);
           // evaluar(p, 0, 5, 0.1); */
        }
    }
    [Serializable]
    class Perceptron
    {
        public List<Lista> Lista;
        public Perceptron(int[] numeroneuronas)
        {
            Lista = new List<Lista>();
            Random r = new Random();
            for (int i = 0; i < numeroneuronas.Length; i++)
            {
                Lista.Add(new Lista(numeroneuronas[i], i == 0 ? numeroneuronas[i] : numeroneuronas[i - 1], r));
            }
        }

        public double[] activacion(double[] entradas)
        {
            double[] salidas = new double[0];
            for (int i = 0; i < Lista.Count; i++)
            {
                salidas = Lista[i].activacion(entradas);
                entradas = salidas;
            }
            return salidas;
        }

        public double errorindividual(double[] salidareal, double[] salidadeseada)
        {
            double err = 0;
            for (int i = 0; i < salidareal.Length; i++)
            {
                err +=  Math.Pow(salidareal[i] - salidadeseada[i], 2);
            }
            return err;
        }

        public double errorGeneral(List<double[]> entradas, List<double[]> salidasdeseadas)
        {
            double err = 0;
            for (int i = 0; i < entradas.Count; i++)
            {
                err += errorindividual(activacion(entradas[i]), salidasdeseadas[i]);
            }
            return err;
        }
        List<String> log;
        public bool aprender(List<double[]> ejementradas, List<double[]> ejemsalidas, double alpha, double maxerror,int numiteraciones)
        {
            double err = 99999;
            log = new List<string>();
            while (err > maxerror)
            {
                numiteraciones--;
                if (numiteraciones <=0)
                {
                    Console.WriteLine("-----------minimo local-----------");
                    return false;
                }
                if (Console.KeyAvailable)
                {
                    Console.WriteLine("-----------escape-----------");
                    System.IO.File.WriteAllLines(@"graf.txt", log.ToArray());
                    return true;
                }
                 
                aplicarBackPropagation(ejementradas,ejemsalidas,alpha);
                err = errorGeneral(ejementradas, ejemsalidas);
                log.Add(err.ToString());
                Console.WriteLine(err);
            }
            System.IO.File.WriteAllLines(@"graf.txt", log.ToArray());
            return true;
        }

        List<double[]> sigmas;
        List<double[,]> deltas;
        void setSigmas(double[] salidasdeseadas)
        {

            sigmas = new List<double[]>();
            for (int i = 0; i < Lista.Count; i++)
            {
                sigmas.Add(new double[Lista[i].numneuronas]);
            }
            for (int i = Lista.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < Lista[i].numneuronas; j++)
                {
                    if (i == Lista.Count - 1)
                    {
                        double y = Lista[i].neuronas[j].ultimaactivacion;
                        sigmas[i][j] = (neurona.Sigmoide(y) - salidasdeseadas[j]) * neurona.SigmoideDerivada(y);
                    }
                    else
                    {
                        double sum = 0;
                        for (int k = 0; k < Lista[i + 1].numneuronas; k++)
                        {
                            sum += Lista[i + 1].neuronas[k].pesos[j] * sigmas[i + 1][k];
                        }
                        sigmas[i][j] = neurona.SigmoideDerivada(Lista[i].neuronas[j].ultimaactivacion) * sum;
                    }
                }
            }
        }

        public void resetDeltas()
        {
            deltas = new List<double[,]>();
            for (int i = 0; i < Lista.Count; i++)
            {
                deltas.Add(new double[Lista[i].numneuronas, Lista[i].neuronas[0].pesos.Length]);

            }
        }
        public void setpesos(double alpha)
        {
            for (int i = 0; i < Lista.Count; i++)
            {
                for (int j = 0; j < Lista[i].numneuronas; j++)
                {
                    for (int k = 0; k < Lista[i].neuronas[j].pesos.Length; k++)
                    {
                        Lista[i].neuronas[j].pesos[k] -= alpha * deltas[i][j, k];
                    }
                }
            }
        }

        public void setumbral(double alpha)
        {
            for (int i = 0; i < Lista.Count; i++)
            {
                for (int j = 0; j < Lista[i].numneuronas; j++)
                {
                    Lista[i].neuronas[j].umbral -= alpha * sigmas[i][j];
                }
            }
        }

        
        //l
        void agregarDelta()
        {
            for(int i=1; i < Lista.Count; i++)
            {
                for(int j=0; j < Lista[i].numneuronas; j++)
                {
                    for(int k=0; k<Lista[i].neuronas[j].pesos.Length; k++)
                    {
                        deltas[i][j, k] += sigmas[i][j] * neurona.Sigmoide(Lista[i-1].neuronas[k].ultimaactivacion);
                    }
                }
            }
        }
        public void aplicarBackPropagation(List<double[]> entradas, List<double[]> salidasdeseadas, double alpha)
        {
            resetDeltas();
            for(int i=0; i<entradas.Count; i++)
            {
                activacion(entradas[i]);
                setSigmas(salidasdeseadas[i]);
                setumbral(alpha);
                agregarDelta();
                
            }
            setpesos(alpha);
        }

    }
    [Serializable]
    class Lista
    {
        public List<neurona> neuronas;
        public double[] salidas;
        public int numneuronas;
        public Lista(int _numneuronas,int entradas, Random r)
        {
            numneuronas = _numneuronas;
            neuronas = new List<neurona>();
            for(int i =0; i<numneuronas; i++)
            {
                neuronas.Add(new neurona(entradas, r));
            }
        }

        public double[] activacion(double[] entradas)
        {
            //salidas = new double[neuronas.Count];
            List<double> salida = new List<double>();
            for(int i=0; i < numneuronas; i++)
            {
                salida.Add(neuronas[i].activacion(entradas));
                //salidas[i] = neuronas[i].activacion(entradas);
            }
            salidas = salida.ToArray();
            return salida.ToArray();
        }
       
    }
    [Serializable]
    class neurona
    {
        public double[] pesos;
        public double umbral;
        public double ultimaactivacion;
        public neurona(int entradas,Random r)
        {
            umbral = 10* r.NextDouble()-5;
            pesos = new double[entradas];
            for(int i=0; i < entradas; i++)
            {
                pesos[i] = 10* r.NextDouble() - 5;
            }
        }

     
        public static double Sigmoide(double entrada)
        {
            return 1 / (1 + Math.Exp(-entrada));
        }
        public static double SigmoideDerivada(double entrada)
        {
            double y = Sigmoide(entrada);
            return y * (1 - y);
        }
        public double activacion(double[] entradas)
        {
            double activacion = umbral;
            //ultimaactivacion = umbral;
            for (int i = 0; i < pesos.Length; i++)
            {
                activacion += pesos[i] * entradas[i];
            }
            ultimaactivacion = activacion;
            return Sigmoide(activacion);
        }
    }


}
