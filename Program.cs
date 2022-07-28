using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SqlServerColumnstoreSample
{
    class Program 
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Conectando con sqlserver desde c# ");
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost";
            builder.UserID = "sa";
            builder.Password = "Nemesis28;";
            builder.InitialCatalog = "master";
            Console.WriteLine("Conectando con sqlserver");
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                            void MuestraDatos()
                            {
                                SqlDataAdapter adaptador = new SqlDataAdapter("Select * from inventario",connection);
                                DataTable dt = new DataTable();
                                adaptador.Fill(dt);
                                Console.WriteLine(">>> Mostrando contenido de la tabla inventario <<<");
                                Console.WriteLine("ID    -|- Nombre          -|- Cantidad");
                                Console.WriteLine("--------------------------------------");
                                foreach (DataRow item in dt.Rows)
                                {
                                    Console.WriteLine(item["id"].ToString() + "     -|- "+item["nombre"].ToString() + "        -|- " + item["cantidad"]);
                                }
                                Console.WriteLine(">>> Fin del contenido de la tabla inventario <<< ");
                                Console.WriteLine("Pulse una tecla para continuar");
                                Console.ReadKey(true);

                            }
                            void RegistraDatos()
                            {
                                String sql = "";
                                Console.WriteLine("Preparando insercición de registros en inventario");
                                sql="Use TestDB; Insert Into inventario values (1,'Manzanas',300);";
                                SqlCommand command = new SqlCommand(sql,connection);
                                command.ExecuteNonQuery();
                                Console.WriteLine("Registro insertado con éxito");
                                MuestraDatos();
                            }
                            void ActualizaDatos()
                            {
                                String sql = "";
                                Console.WriteLine("Cambiar el nombre Manzanas por Sandias");
                                sql="Use TestDB; Update inventario set nombre = 'Sandias' where id=1";
                                SqlCommand commandA = new SqlCommand(sql,connection);
                                commandA.ExecuteNonQuery();
                                Console.WriteLine("Registro Actualizado con éxito");
                                MuestraDatos();
                            }
                            void EliminaDatos()
                            {
                                String sql = "";
                                Console.WriteLine("Vaciar la tabla inventario");
                                sql="Use TestDB; Delete inventario";
                                SqlCommand commandE = new SqlCommand(sql,connection);
                                commandE.ExecuteNonQuery();
                                Console.WriteLine("Tabla inventario vaciada con éxito");
                                MuestraDatos();
                            }
                connection.Open();
                Console.WriteLine("Conexión establecida con exito");
                RegistraDatos();
                ActualizaDatos();
                EliminaDatos();                
            }
        }
    }
}