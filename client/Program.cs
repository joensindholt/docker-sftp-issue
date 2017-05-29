using System;
using System.IO;
using System.Threading;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client started");

            var sftpClient = new Renci.SshNet.SftpClient("localhost", 2228, "foo", "pass");
            var sourceRoot = "files/";

            sftpClient.Connect();

            var files = new string[]
            {
                "20MB.zip",
                "50MB.zip"
            };

            var runs = 20;
            for (var i = 0; i < runs; i++)
            {
                Console.WriteLine("Run: " + (i + 1));

                foreach (var file in files)
                {
                    var source = sourceRoot + file;
                    Console.WriteLine("Source: " + source);
                    
                    var dest = "/upload/" + file;
                    Console.WriteLine("Destination: " + dest);

                    using (var stream = File.Open(source, FileMode.Open))
                    {
                        sftpClient.UploadFile(stream, dest, value =>
                        {
                            Console.Write("*");
                        });
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
