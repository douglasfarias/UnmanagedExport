using System;
using System.Runtime.InteropServices;

using Dapper;

using Npgsql;

using RGiesecke.DllExport;


namespace ClassLibrary
{
    public class FooService
    {
        [DllExport("AddFoo", CallingConvention.StdCall)]
        public static void AddFoo(IntPtr ptr)
        {
            try
            {
                var foo = Marshal.PtrToStructure<Foo>(ptr);

                using(var connection = new NpgsqlConnection("Host=192.168.0.150;Username=postgres;Password=secret;Database=test"))
                {
                    connection.Execute("INSERT INTO foo (bar) VALUES (@Value)", new { value = foo.Value });
                }

                Console.WriteLine("Valor inserido com sucesso!");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro ao inserir valor: {ex.Message}");
            }
        }
    }
}
