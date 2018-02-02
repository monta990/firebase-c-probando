using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace ConsoleApp6
{
	class Program
	{
		static void Main(string[] args)
		{

			while (true)
			{
				DateTime date = DateTime.Now;

				string Date = date.ToString("yyyy:MM:dd");
				string Time = date.ToString("HH:mm:ss");

				var json = JsonConvert.SerializeObject(new
				{
					Name = Time,
					Value = Date,
				});
				var request = WebRequest.CreateHttp("https://hola-mundo-c1fd2.firebaseio.com/.json");
				request.Method = "POST";
				request.ContentType = "application/json";
				var buffer = Encoding.UTF8.GetBytes(json);
				request.ContentLength = buffer.Length;
				request.GetRequestStream().Write(buffer, 0, buffer.Length);
				var repose = request.GetResponse();
				json = (new StreamReader(repose.GetResponseStream())).ReadToEnd();
			}
		}
	}
}
