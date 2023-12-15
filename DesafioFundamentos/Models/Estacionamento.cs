namespace DesafioFundamentos.Models
{
	public class Estacionamento
	{
		private decimal precoInicial = 0;
		private decimal precoPorHora = 0;
		private List<string> veiculos = new List<string>();

		public Estacionamento(decimal precoInicial, decimal precoPorHora)
		{
			this.precoInicial = precoInicial;
			this.precoPorHora = precoPorHora;
		}

		public void AdicionarVeiculo()
		{
			Console.WriteLine("Digite a placa do veículo para estacionar:");
			string placa = Console.ReadLine();
			if (!VeiculoEstaEstacionado(placa))
			{
				veiculos.Add(placa);
				Console.WriteLine($"O veículo {placa} foi estacionado");
			}
			else
			{
				Console.WriteLine("Veículo já estacionado");
			}
		}

		public void RemoverVeiculo(decimal precoInicial, decimal precoHora)
		{
			Console.WriteLine("Digite a placa do veículo para remover:");
			string placa = Console.ReadLine();

			// Verifica se o veículo existe
			if (VeiculoEstaEstacionado(placa))
			{
				Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
				bool horasValidas = int.TryParse(Console.ReadLine(), out int horas);

				while (!horasValidas)
				{
					Console.WriteLine("Quantidade inválida, tente novamente:");
					horasValidas = int.TryParse(Console.ReadLine(), out horas);
				}

				decimal valorTotal = precoInicial + precoHora * horas;

				veiculos.Remove(placa);
				Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: {valorTotal:C}");
			}
			else
			{
				Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
			}
		}

		public void ListarVeiculos()
		{
			// Verifica se há veículos no estacionamento
			if (veiculos.Any())
			{
				Console.WriteLine("Os veículos estacionados são:");
				for (int i = 0; i < veiculos.Count; i++)
				{
					Console.WriteLine($"{i + 1} - {veiculos[i]}");
				}
			}
			else
			{
				Console.WriteLine("Não há veículos estacionados.");
			}
		}

		private bool VeiculoEstaEstacionado(string placa)
		{
			return veiculos.Any(x => x.ToUpper() == placa.ToUpper());
		}

	}
}
