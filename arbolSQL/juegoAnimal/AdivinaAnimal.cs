using arbolSQL.ArbolBinario;
using arbolSQL.conexionDB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbolSQL.juegoAnimal
{
    class AdivinaAnimal
    {
        public static Nodo raiz;
        public static String nuevoA;
        public static Nodo nodo1;
        public static Nodo nodo2;
        public static String pregunta;

        public AdivinaAnimal()
        {
            raiz = new Nodo("Elefante");
        }

        public void jugar()
        {
            Nodo nodo = raiz;

            while (nodo != null) //se usa cuando hay una pregunta
            {
                if (nodo.izquierda != null) //se usa cuando existe una pregunta
                {
                    Console.WriteLine(nodo.valorNodo());
                    nodo = (respuesta()) ? nodo.izquierda : nodo.derecha;
                }
                else
                {
                    Console.WriteLine($"Ya se, es un {nodo.valorNodo()}?");
                    if (respuesta())
                    {
                        Console.WriteLine("Gane!!! :)");
                    }
                    else
                    {
                        animalNuevo(nodo);
                        Agregar();
                    }
                    nodo = null;
                    return;
                }//fin if
            }//fin while
        }//fin jugar

        public bool respuesta()
        {
            while (true)
            {
                String resp = Console.ReadLine().ToLower().Trim();
                if (resp.Equals("si")) return true;
                if (resp.Equals("no")) return false;
                Console.WriteLine("La respuesta debe ser: si/no");
            }

        }//fin de respuesta

        public void animalNuevo(Nodo nodo)
        {
            String animalNodo = (String)nodo.valorNodo();
            Console.WriteLine("cual es tu animal pues?");
            nuevoA = Console.ReadLine();
            Console.WriteLine($"Que pregunta con respuesta si / no puedo hacer para poder decir que es un {nuevoA}");
            pregunta = Console.ReadLine();
            nodo1 = new Nodo(animalNodo);
            nodo2 = new Nodo(nuevoA);
            Console.WriteLine($"Para un (a) {nuevoA} la respuesta es si / no?");
            nodo.nuevoValor(pregunta + "?");

            if (respuesta())
            {
                nodo.izquierda = nodo2;
                nodo.derecha = nodo1;
            }
            else
            {
                nodo.izquierda = nodo1;
                nodo.derecha = nodo2;
            }
        }//fin de animalNuevo

        public void Agregar()
        {
            String nuevoAsql = nuevoA;
            String preguntasql = pregunta;

            String sql = "INSERT INTO tbanimalitos (nuevoA, pregunta) VALUES ('" + nuevoAsql + "','" + preguntasql + "')";
            MySqlConnection conexionBD = ConexionDB.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                Console.WriteLine("Animal Guardado");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al guardar el Animal: " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }

        }//fin del metodo agregar

        public void Buscar()
        {
            MySqlDataReader reader;
            String nuevoAsql = nuevoA;
            String preguntasql = pregunta;

            String sql = "SELECT idtbanimalitos, nuevoA, pregunta FROM tbanimalitos";
            MySqlConnection conexionBD = ConexionDB.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        String animalNuevosql = reader.GetString(1);
                        String preguntaNueva = reader.GetString(2);
                        Console.WriteLine("Animal Almacenado:\n" + "id: " + id + "; nombre del animal: " + animalNuevosql + "; pregunta/respuesta: " + preguntaNueva + " " + "\n");
                    }
                }
                else
                {
                    Console.WriteLine("No se encontraron registros");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al buscar: " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }

        }//fin del metodo buscar

    }
}
